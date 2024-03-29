﻿namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using xofz.Framework;

    public class StatisticsCalculator
    {
        public StatisticsCalculator(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual bool ClockedIn()
        {
            return this.allTimes().Count % 2 == 1;            
        }

        public virtual TimeSpan TimeWorkedThisWeek()
        {
            var r = this.runner;
            var calc = r?.Run<DateCalculator>();
            var beginning = calc?.StartOfWeek();
            var end = calc?.EndOfWeek().AddDays(1);
            var max = DateTime.MaxValue;

            return this.TimeWorked(
                beginning ?? max, 
                end ?? max);
        }

        public virtual TimeSpan TimeWorkedToday()
        {
            var r = this.runner;
            var today = DateTime.Today;
            r?.Run<TimeProvider>(provider =>
            {
                today = provider.Now().Date;
            });

            var beginning = today;
            var end = today.AddDays(1);

            return this.TimeWorked(beginning, end);
        }

        public virtual TimeSpan TimeWorked(
            DateTime beginning, 
            DateTime end)
        {
            var r = this.runner;
            var allTimes = this.allTimes();
            var timeWorked = TimeSpan.Zero;
            var timesInRange = new XLinkedList<DateTime>();
            long timeCounter = 0;
            foreach (var time in allTimes)
            {
                if (time < beginning)
                {
                    ++timeCounter;
                    if (timeCounter < allTimes.Count)
                    {
                        continue;
                    }

                    goto checkIfClockedInBeforeFirst;
                }

                if (time > end)
                {
                    if (timesInRange.Count < 1 && timeCounter % 2 == 1)
                    {
                        // clocked in at beginning
                        timesInRange.AddTail(beginning);
                    }

                    if (timesInRange.Count % 2 == 1)
                    {
                        // clocked in at end
                        timesInRange.AddTail(end);
                    }

                    break;
                }

                checkIfClockedInBeforeFirst:
                if (timesInRange.Count < 1 && timeCounter % 2 == 1)
                {
                    // clocked in at start of range
                    timesInRange.AddHead(beginning);
                }

                if (timeCounter >= allTimes.Count)
                {
                    break;
                }

                timesInRange.AddTail(time);
            }

            var e = ((ICollection<DateTime>)timesInRange)
                .GetEnumerator();
            while (e?.MoveNext() ?? false)
            {
                var inTime = e.Current;
                if (!e.MoveNext())
                {
                    var now = DateTime.Now;
                    r?.Run<TimeProvider>(provider =>
                    {
                        now = provider.Now();
                    });

                    if (end.Date > now)
                    {
                        if (inTime < now)
                        {
                            timeWorked += now - inTime;
                        }
                        
                        break;
                    }

                    timeWorked += end.Date - inTime;
                    break;
                }

                var outTime = e.Current;
                timeWorked += outTime - inTime;
            }

            e.Dispose();

            return timeWorked;
        }

        public virtual TimeSpan AverageDailyTimeWorked(
            DateTime beginning, 
            DateTime end)
        {
            var totalTimeWorked = this.TimeWorked(beginning, end);
            var numberOfDays = (end - beginning).Days;
            if (numberOfDays == 0)
            {
                numberOfDays = 1;
            }

            return new TimeSpan(
                totalTimeWorked.Ticks / numberOfDays);
        }

        public virtual TimeSpan MinDailyTimeWorked(
            DateTime beginning, 
            DateTime end)
        {
            var zero = TimeSpan.Zero;
            if (beginning > end)
            {
                return zero;
            }

            var max = TimeSpan.MaxValue;
            var minTimeWorked = max;
            var currentDay = beginning;
            while (currentDay < end)
            {
                var nextDay = currentDay.AddDays(1);
                var timeWorked = this.TimeWorked(
                    currentDay, 
                    nextDay);
                if (timeWorked > zero &&
                    timeWorked < minTimeWorked)
                {
                    minTimeWorked = timeWorked;
                }

                currentDay = nextDay;
            }

            if (minTimeWorked == max)
            {
                return zero;
            }

            return minTimeWorked;
        }

        public virtual TimeSpan MaxDailyTimeWorked(
            DateTime beginning, 
            DateTime end)
        {
            var zero = TimeSpan.Zero;
            if (beginning > end)
            {
                return zero;
            }

            var maxTimeWorked = TimeSpan.Zero;
            var currentDay = beginning;
            while (currentDay < end)
            {
                var nextDay = currentDay.AddDays(1);
                var timeWorked = this.TimeWorked(
                    currentDay,
                    nextDay);
                if (timeWorked > maxTimeWorked)
                {
                    maxTimeWorked = timeWorked;
                }

                currentDay = nextDay;
            }

            return maxTimeWorked;
        }

        protected virtual ICollection<DateTime> allTimes()
        {
            var r = this.runner;
            return XLinkedList<DateTime>.Create(
                EnumerableHelpers.OrderBy(
                       r?.Run<TimestampReader>()
                           ?.ReadAll(),
                       ts => ts));
        }

        protected readonly MethodRunner runner;
    }
}
