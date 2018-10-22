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
            w.Run<Navigator, EventSubscriber>((n, subscriber) =>
            {
                var homeUi = n.GetUi<HomePresenter, HomeUi>();
                subscriber.Subscribe(
                    homeUi,
                    nameof(homeUi.InKeyTapped),
                    this.homeUi_InKeyTapped);
                subscriber.Subscribe(
                    homeUi,
                    nameof(homeUi.OutKeyTapped),
                    this.homeUi_OutKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.CurrentKeyTapped),
                    this.ui_CurrentKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.StatisticsRangeKeyTapped),
                    this.ui_StatisticsRangeKeyTapped);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
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
                    () => statsUi.EndDate);
            });

            findAndSetTimesInRange:
            w.Run<
                TimestampReader,
                Lotter,
                EnumerableSplitter>(
                (reader, mz, splitter) =>
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

                        // clocked out now but was clocked in at start of week
                        // thus, give them a free time at midnight on the start of the week
                        timesInRange.AddFirst(start.Date);
                    }

                    afterCheckClockedIn:
                    var splitTimesThisWeek = splitter.Split(
                        timesInRange,
                        2);
                    var inTimes = splitTimesThisWeek[0];
                    var uiTimesIn = mz.Materialize(
                        EnumerableHelpers.Select(
                            inTimes,
                            this.formatTimestamp));
                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.InTimes = uiTimesIn; });

                    var outTimes = splitTimesThisWeek[1];
                    var uiTimesOut = mz.Materialize(
                        EnumerableHelpers.Select(
                            outTimes,
                            this.formatTimestamp));

                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.OutTimes = uiTimesOut; });

                    w.Run<EnumerableSplicer, Lotter>(
                        (splicer, lotter) =>
                    {
                        var lot = lotter.Materialize(
                            EnumerableHelpers.Select(
                                splicer.Splice(
                                    new[]
                                    {
                                        inTimes,
                                        outTimes
                                    }),
                                this.formatTimestamp));

                        UiHelpers.Write(
                            this.ui,
                            () => { this.ui.SetSplicedInOutTimes(lot); });
                    });
                });

            base.Start();
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

        private long setupIf1, startedIf1, currentIf0;
        private readonly TimestampsUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
