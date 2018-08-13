namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using xofz.Framework;

    public class StatisticsCalculator
    {
        public StatisticsCalculator(MethodWeb web)
        {
            this.web = web;
        }

        public virtual bool ClockedIn()
        {
            return this.allTimes().Count % 2 == 1;            
        }

        public virtual TimeSpan TimeWorkedThisWeek()
        {
            var w = this.web;
            var calc = w.Run<DateCalculator>();
            var beginning = calc.StartOfWeek();
            var end = calc.EndOfWeek().AddDays(1);

            return this.TimeWorked(beginning, end);
        }

        public TimeSpan TimeWorkedToday()
        {
            var today = DateTime.Today;
            var beginning = today;
            var end = today.AddDays(1);

            return this.TimeWorked(beginning, end);
        }

        public virtual TimeSpan TimeWorked(DateTime beginning, DateTime end)
        {
            var allTimes = this.allTimes();
            TimeSpan timeWorked = TimeSpan.Zero;
            var timesInRange = new LinkedList<DateTime>();
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
                    if (timesInRange.Count % 2 == 1)
                    {
                        // clocked in at end
                        timesInRange.AddLast(end);
                    }

                    break;
                }

                checkIfClockedInBeforeFirst:
                if (timesInRange.Count == 0 && timeCounter % 2 == 1)
                {
                    // clocked in at start of range
                    timesInRange.AddFirst(beginning);
                }

                if (timeCounter >= allTimes.Count)
                {
                    break;
                }

                timesInRange.AddLast(time);
            }

            var e = timesInRange.GetEnumerator();
            while (e.MoveNext())
            {
                var inTime = e.Current;
                if (!e.MoveNext())
                {
                    var now = DateTime.Now;
                    if (end.Date > now)
                    {
                        timeWorked += now - inTime;
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

        public virtual TimeSpan AverageDailyTimeWorked(DateTime beginning, DateTime end)
        {
            var totalTimeWorked = this.TimeWorked(beginning, end);
            var numberOfDays = (end - beginning).Days;
            if (numberOfDays == 0)
            {
                numberOfDays = 1;
            }

            return new TimeSpan(totalTimeWorked.Ticks / numberOfDays);
        }

        public virtual TimeSpan MinDailyTimeWorked(DateTime beginning, DateTime end)
        {
            if (beginning > end)
            {
                return TimeSpan.Zero;
            }

            var minTimeWorked = TimeSpan.MaxValue;
            var currentDay = beginning;
            while (currentDay < end)
            {
                var timeWorked = this.TimeWorked(
                    currentDay, 
                    currentDay.AddDays(1));
                if (timeWorked > TimeSpan.Zero && timeWorked < minTimeWorked)
                {
                    minTimeWorked = timeWorked;
                }

                currentDay = currentDay.AddDays(1);
            }

            if (minTimeWorked == TimeSpan.MaxValue)
            {
                return TimeSpan.Zero;
            }

            return minTimeWorked;
        }

        public virtual TimeSpan MaxDailyTimeWorked(DateTime beginning, DateTime end)
        {
            if (beginning > end)
            {
                return TimeSpan.Zero;
            }

            var maxTimeWorked = TimeSpan.Zero;
            var currentDay = beginning;
            while (currentDay < end)
            {
                var timeWorked = this.TimeWorked(
                    currentDay,
                    currentDay.AddDays(1));
                if (timeWorked > maxTimeWorked)
                {
                    maxTimeWorked = timeWorked;
                }

                currentDay = currentDay.AddDays(1);
            }

            return maxTimeWorked;
        }

        private ICollection<DateTime> allTimes()
        {
            var w = this.web;
            var reader = w.Run<TimestampReader>();
            return reader.ReadAll();
        }

        private readonly MethodWeb web;
    }
}
