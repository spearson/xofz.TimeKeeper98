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
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampsUi ui,
            HomeNavUi homeNavUi,
            StatisticsUi statsUi)
        {
            var w = this.web;
            w.Run<UiReaderWriter>((rw) =>
            {
                rw.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = "Timestamps";
                    });
            });

            var showCurrent = true;
            w.Run<SettingsHolder>(settings =>
            {
                showCurrent = settings.ShowCurrent;
            });
            DateTime start = DateTime.Today, end = start.AddDays(1);
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

            w.Run<UiReaderWriter>(rw =>
            {
                start = rw.Read(
                    statsUi,
                    () => statsUi.StartDate);
                end = rw.Read(
                        statsUi,
                        () => statsUi.EndDate)
                    .AddDays(1);
            });

            findAndSetTimesInRange:
            w.Run<
                TimestampReader,
                Lotter,
                EnumerableSplitter,
                UiReaderWriter>(
                (reader, lotter, splitter, rw) =>
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

                    var firstIn = this.isInTime(
                        EnumerableHelpers.First(
                            timesInRange));
                    var inNow = allTimes.Count % 2 == 1;
                    var oddTimesInRange = timesInRange.Count % 2 == 1;
                    if (oddTimesInRange)
                    {
                        if (inNow && firstIn)
                        {
                            goto afterCheckClockedIn;
                            // clocked in currently, do nothing
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

                    if (inNow && !firstIn)
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
                    rw.Write(
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

                    rw.Write(
                        ui,
                        () =>
                        {
                            ui.OutTimes = uiTimesOut;
                        });

                    w.Run<EnumerableSplicer>(
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
                                currentInTime = default(DateTime),
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
                                    continue;
                                }
                            }

                            var lot = lotter.Materialize(
                                EnumerableHelpers.Select(
                                    splicedTimes,
                                    this.formatTimestamp));
                            
                            var showDurations = false;
                            w.Run<SettingsHolder>(settings =>
                            {
                                showDurations = settings.ShowDurations;
                            });

                            if (showDurations)
                            {
                                ICollection<string> newInOutTimes = new LinkedList<string>();
                                var closedLot = lot;
                                w.Run<TimeSpanViewer>(v =>
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

                            rw.Write(
                                ui,
                                () =>
                                {
                                    ui.SetSplicedInOutTimes(lot);
                                });
                        });
                });
        }

        protected virtual bool isInTime(DateTime timestamp)
        {
            var w = this.web;
            var inTime = false;
            w.Run<TimestampReader>(reader =>
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

        protected virtual string formatTimestamp(DateTime timeStamp)
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
        
        protected readonly MethodWeb web;
    }
}
