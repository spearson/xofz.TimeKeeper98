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
            const byte one = 1;
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

            var end = start.AddDays(one);
            if (showCurrent)
            {
                r?.Run<DateCalculator>(
                    calc =>
                    {
                        start = calc.StartOfWeek();
                        end = calc.EndOfWeek().AddDays(one);
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
                    var timesInRange = new XLinkedList<DateTime>();
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

                        timesInRange.AddTail(time);
                    }

                    bool firstIn;
                    if (timesInRange.Count < one)
                    {
                        firstIn = false;
                        goto checkAdd;
                    }

                    firstIn = this.isInTime(
                        EnumerableHelpers.FirstOrDefault(
                            timesInRange));

                    checkAdd:
                    var inNow = allTimes.Count % two == one;
                    var oddTimesInRange = timesInRange.Count % two == one;
                    if (oddTimesInRange)
                    {
                        if (inNow && firstIn)
                        {
                            var now = DateTime.Now;
                            r.Run<TimeProvider>(provider =>
                            {
                                now = provider.Now();
                            });

                            if (now > end.AddDays(one))
                            {
                                // was clocked in at end of range
                                timesInRange.AddTail(end);
                            }

                            // clocked in currently, do nothing
                            goto afterCheckClockedIn;
                        }

                        if (firstIn)
                        {
                            // clocked in at end of week
                            timesInRange.AddTail(end.Date);
                            goto afterCheckClockedIn;
                        }

                        // clocked out now but was clocked in at start of week
                        timesInRange.AddHead(start.Date);
                        goto afterCheckClockedIn;
                    }

                    if (inNow && !firstIn && timesInRange.Count > zero)
                    {
                        timesInRange.AddHead(start.Date);
                    }

                    afterCheckClockedIn:
                    var splitTimesThisWeek = splitter.Split(
                        timesInRange,
                        two);
                    var inTimes = splitTimesThisWeek[zero];
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

                    var outTimes = splitTimesThisWeek[one];
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
                            short indexer = zero;
                            DateTime
                                currentInTime = default,
                                currentOutTime;
                            ICollection<TimeSpan> durations = new XLinkedList<TimeSpan>();
                            foreach (var splicedTime in splicedTimes)
                            {
                                if (indexer == zero)
                                {
                                    // in time
                                    currentInTime = splicedTime;
                                    ++indexer;
                                    continue;
                                }

                                if (indexer == one)
                                {
                                    // out time
                                    currentOutTime = splicedTime;
                                    durations.Add(currentOutTime - currentInTime);
                                    indexer = zero;
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
                                ICollection<string> newInOutTimes = new XLinkedList<string>();
                                var closedLot = lot;
                                r.Run<TimeSpanViewer>(v =>
                                {
                                    indexer = zero;
                                    var e = durations.GetEnumerator();
                                    foreach (var item in closedLot)
                                    {
                                        if (indexer % two == one)
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
                long indexer = zero;
                foreach (var ts in reader.Read())
                {
                    if (timestamp == ts)
                    {
                        inTime = indexer % two == zero;
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
        protected const byte
            zero = 0,
            two = 2;
    }
}
