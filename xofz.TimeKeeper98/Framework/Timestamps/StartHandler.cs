namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using System;
    using System.Collections.Generic;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampsUi ui)
        {
            var r = this.runner;
            r?.Run<UiReader>(reader =>
            {
                reader.ReadHomeNav(
                    out var homeNavUi);
                reader.ReadStatistics(
                    out var statsUi);
                this.Handle(
                    ui,
                    homeNavUi,
                    statsUi);
            });
        }

        public virtual void Handle(
            TimestampsUi ui,
            HomeNavUi homeNavUi,
            StatisticsUi statsUi)
        {
            var r = this.runner;
            r?.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = NavKeyLabels.Timestamps;
                    });
            });

            var showCurrent = true;
            r?.Run<SettingsHolder>(settings =>
            {
                showCurrent = settings.ShowCurrent;
            });
            var start = DateTime.Today;
            r?.Run<TimeProvider>(provider =>
            {
                start = provider.Now().Date;
            });

            var end = start.AddDays(1);
            if (showCurrent)
            {
                r?.Run<DateCalculator>(
                    calc =>
                    {
                        start = calc.StartOfWeek();
                        end = calc.EndOfWeek().AddDays(1);
                    });
                goto findAndSetTimesInRange;
            }

            r?.Run<UiReaderWriter>(uiRW =>
            {
                start = uiRW.Read(
                    statsUi,
                    () => statsUi.StartDate);
                end = uiRW.Read(
                        statsUi,
                        () => statsUi.EndDate)
                    .AddDays(1);
            });

            findAndSetTimesInRange:
            r?.Run<
                TimestampReader,
                Lotter,
                EnumerableSplitter,
                UiReaderWriter>(
                (reader, lotter, splitter, uiRW) =>
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

                    bool firstIn;
                    if (timesInRange.Count < 1)
                    {
                        firstIn = false;
                        goto checkAdd;
                    }

                    firstIn = this.isInTime(
                        EnumerableHelpers.FirstOrDefault(
                            timesInRange));

                    checkAdd:
                    var inNow = allTimes.Count % 2 == 1;
                    var oddTimesInRange = timesInRange.Count % 2 == 1;
                    if (oddTimesInRange)
                    {
                        if (inNow && firstIn)
                        {
                            var now = DateTime.Now;
                            r.Run<TimeProvider>(provider =>
                            {
                                now = provider.Now();
                            });

                            if (now > end.AddDays(1))
                            {
                                // was clocked in at end of range
                                timesInRange.AddLast(end);
                            }

                            // clocked in currently, do nothing
                            goto afterCheckClockedIn;
                        }

                        if (firstIn)
                        {
                            // clocked in at end of week
                            timesInRange.AddLast(end.Date);
                            goto afterCheckClockedIn;
                        }

                        // clocked out now but was clocked in at start of week
                        timesInRange.AddFirst(start.Date);
                        goto afterCheckClockedIn;
                    }

                    if (inNow && !firstIn && timesInRange.Count > 0)
                    {
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
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.InTimes = uiTimesIn;
                        });

                    var outTimes = splitTimesThisWeek[1];
                    var uiTimesOut = lotter.Materialize(
                        EnumerableHelpers.Select(
                            outTimes,
                            this.formatTimestamp));

                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.OutTimes = uiTimesOut;
                        });

                    r.Run<EnumerableSplicer>(
                        splicer =>
                        {
                            var splicedTimes = splicer.Splice(
                                        new[]
                                        {
                                            inTimes,
                                            outTimes
                                        });
                            short indexer = 0;
                            DateTime
                                currentInTime = default,
                                currentOutTime;
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
                                }
                            }

                            var lot = lotter.Materialize(
                                EnumerableHelpers.Select(
                                    splicedTimes,
                                    this.formatTimestamp));
                            
                            var showDurations = false;
                            r.Run<SettingsHolder>(settings =>
                            {
                                showDurations = settings.ShowDurations;
                            });

                            if (showDurations)
                            {
                                ICollection<string> newInOutTimes = new LinkedList<string>();
                                var closedLot = lot;
                                r.Run<TimeSpanViewer>(v =>
                                {
                                    indexer = 0;
                                    var e = durations.GetEnumerator();
                                    foreach (var item in closedLot)
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

                                    e.Dispose();
                                });

                                lot = lotter.Materialize(newInOutTimes);
                            }

                            uiRW.Write(
                                ui,
                                () =>
                                {
                                    ui.SetSplicedInOutTimes(lot);
                                });
                        });
                });
        }

        protected virtual bool isInTime(
            DateTime timestamp)
        {
            var r = this.runner;
            var inTime = false;
            r?.Run<TimestampReader>(reader =>
            {
                long indexer = 0;
                foreach (var ts in reader.Read())
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

        protected virtual string formatTimestamp(
            DateTime timeStamp)
        {
            var r = this.runner;
            string formattedTimestamp = null;
            r?.Run<GlobalSettingsHolder>(settings =>
            {
                formattedTimestamp = timeStamp.ToString(
                    settings.TimestampFormat);
            });

            return formattedTimestamp;
        }
        
        protected readonly MethodRunner runner;
    }
}
