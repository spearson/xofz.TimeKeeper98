namespace xofz.TimeKeeper98.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class TimestampsPresenter : Presenter
    {
        public TimestampsPresenter(
            TimestampsUi ui, 
            ShellUi shell,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.shell = shell;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<EventSubscriber>(sub =>
            {
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.CurrentKeyTapped),
                    this.ui_CurrentKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.StatisticsRangeKeyTapped),
                    this.ui_StatisticsRangeKeyTapped);
                sub.Subscribe<bool>(
                    this.ui,
                    nameof(this.ui.ShowDurationChanged),
                    this.ui_ShowDurationChanged);
                w.Run<Navigator>(n =>
                {
                    var homeUi = n.GetUi<HomePresenter, HomeUi>();
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.InKeyTapped),
                        this.homeUi_InKeyTapped);
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.OutKeyTapped),
                        this.homeUi_OutKeyTapped);
                });
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);

            base.Start();

            this.startInternal();
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 0, 1);
        }

        private void startInternal()
        {
            var w = this.web;
            w.Run<Navigator>(n =>
            {
                var homeNavUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                UiHelpers.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = "Timestamps";
                    });
            });

            var showCurrent = Interlocked.Read(ref this.currentIf0) == 0;
            DateTime start = DateTime.Today, end = DateTime.Today;
            if (showCurrent)
            {
                w.Run<DateCalculator>(
                    calc =>
                    {
                        start = calc.StartOfWeek();
                        end = calc.EndOfWeek().AddDays(1);
                    });
                goto findAndSetTimesInRange;
            }

            w.Run<Navigator>(n =>
            {
                var statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
                start = UiHelpers.Read(
                    statsUi,
                    () => statsUi.StartDate);
                end = UiHelpers.Read(
                        statsUi,
                        () => statsUi.EndDate)
                    .AddDays(1);
            });

            findAndSetTimesInRange:
            w.Run<
                TimestampReader,
                Lotter,
                EnumerableSplitter>(
                (reader, lotter, splitter) =>
                {
                    var allTimes = reader.ReadAll();
                    var timesInRange = new LinkedList<DateTime>();
                    foreach (var time in allTimes)
                    {
                        if (time < start)
                        {
                            continue;
                        }

                        if (time > end)
                        {
                            continue;
                        }

                        timesInRange.AddLast(time);
                    }

                    if (timesInRange.Count % 2 == 1)
                    {
                        if (allTimes.Count % 2 == 1)
                        {
                            goto afterCheckClockedIn;
                            // clocked in currently, do nothing
                        }

                        
                        if (isInTime(EnumerableHelpers.First(timesInRange)))
                        {
                            // clocked in at end of week
                            timesInRange.AddLast(end.Date);
                            goto afterCheckClockedIn;
                        }

                        // clocked out now but was clocked in at start of week
                        timesInRange.AddFirst(start.Date);
                    }

                    afterCheckClockedIn:
                    var splitTimesThisWeek = splitter.Split(
                        timesInRange,
                        2);
                    var inTimes = splitTimesThisWeek[0];
                    var uiTimesIn = lotter.Materialize(
                        EnumerableHelpers.Select(
                            inTimes,
                            this.formatTimestamp));
                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.InTimes = uiTimesIn; });

                    var outTimes = splitTimesThisWeek[1];
                    var uiTimesOut = lotter.Materialize(
                        EnumerableHelpers.Select(
                            outTimes,
                            this.formatTimestamp));

                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.OutTimes = uiTimesOut; });

                    w.Run<EnumerableSplicer>(
                        splicer =>
                        {
                            var splicedTimes = splicer.Splice(
                                        new[]
                                        {
                                            inTimes,
                                            outTimes
                                        });
                            byte indexer = 0;
                            DateTime 
                                currentInTime = default(DateTime), 
                                currentOutTime = default(DateTime);
                            ICollection<TimeSpan> durations = new LinkedList<TimeSpan>();
                            foreach (var splicedTime in splicedTimes)
                            {
                                if (indexer == 0)
                                {
                                    // in time
                                    currentInTime = splicedTime;
                                    ++indexer;
                                    continue;
                                }

                                if (indexer == 1)
                                {
                                    // out time
                                    currentOutTime = splicedTime;
                                    durations.Add(currentOutTime - currentInTime);
                                    indexer = 0;
                                    continue;
                                }
                            }

                            var lot = lotter.Materialize(
                                EnumerableHelpers.Select(
                                    splicedTimes,
                                    this.formatTimestamp));
                            ICollection<string> newInOutTimes = new LinkedList<string>();
                            if (Interlocked.Read(ref this.showDurationsIf1) == 1)
                            {
                                w.Run<TimeSpanViewer>(v =>
                                {
                                    indexer = 0;
                                    var e = durations.GetEnumerator();
                                    foreach (var item in lot)
                                    {
                                        if (indexer % 2 == 1)
                                        {
                                            if (!e.MoveNext())
                                            {
                                                break;
                                            }

                                            newInOutTimes.Add(
                                                item
                                                + ' '
                                                + '('
                                                + v.ReadableString(e.Current)
                                                + ')');
                                            ++indexer;
                                            continue;
                                        }

                                        newInOutTimes.Add(item);
                                        ++indexer;
                                    }
                                });

                                lot = lotter.Materialize(newInOutTimes);
                            }

                            UiHelpers.Write(
                                this.ui,
                                () =>
                                {
                                    this.ui.SetSplicedInOutTimes(lot);
                                });
                        });
                });
        }

        private bool isInTime(DateTime timestamp)
        {
            var w = this.web;
            var inTime = false;
            w.Run<TimestampReader>(reader =>
            {
                long indexer = 0;
                foreach(var ts in reader.ReadAll())
                {
                    if (timestamp == ts)
                    {
                        inTime = indexer % 2 == 0;
                        break;
                    }

                    ++indexer;
                }
            });

            return inTime;
        }

        private void homeUi_InKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.startInternal();
            }
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.startInternal();
            }
        }

        private void ui_CurrentKeyTapped()
        {
            Interlocked.CompareExchange(ref this.currentIf0, 0, 1);
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.startInternal();
            }            
        }

        private void ui_StatisticsRangeKeyTapped()
        {
            Interlocked.CompareExchange(ref this.currentIf0, 1, 0);
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.startInternal();
            }
        }

        private void ui_ShowDurationChanged(bool shouldShow)
        {
            long oldValue = Interlocked.Read(
                ref this.showDurationsIf1);
            long newValue = shouldShow
                ? 1
                : 0;
            Interlocked.CompareExchange(
                ref this.showDurationsIf1, 
                newValue, 
                oldValue);
            this.startInternal();
        }

        private string formatTimestamp(DateTime timeStamp)
        {
            var w = this.web;
            string s = null;
            w.Run<GlobalSettingsHolder>(settings =>
            {
                s = timeStamp.ToString(
                    settings.TimestampFormat);
            });

            return s;
        }

        private long 
            setupIf1, 
            startedIf1,
            currentIf0,
            showDurationsIf1;
        private readonly TimestampsUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
