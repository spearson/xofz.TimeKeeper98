namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;

    public class TimestampManager : TimestampReader, TimestampWriter
    {
        public TimestampManager(MethodWeb web)
        {
            this.web = web;
            this.mainDirectory = "Data";
        }

        IEnumerable<DateTime> TimestampReader.Read()
        {
            while (Interlocked.CompareExchange(
                ref this.readingIf1, 1, 0) == 1)
            {
                Thread.Sleep(0);
            }

            var w = this.web;
            var trapper = w.Run<EnumerableTrapper<DateTime>>();
            var firstRead = false;
            if (Interlocked.CompareExchange(ref this.firstReadIf0, 1, 0) == 0)
            {
                firstRead = true;
                trapper.TrapNow(this.readAllTimestamps());
            }

            if (Interlocked.CompareExchange(ref this.needToTrapIf1, 0, 1) == 1)
            {
                if (!firstRead)
                {
                    trapper.TrapNow(this.readAllTimestamps());
                }                
            }

            Interlocked.CompareExchange(
                ref this.readingIf1, 0, 1);
            var tc = trapper.TrappedCollection;
            foreach (var timestamp in tc)
            {
                yield return timestamp;
            }
        }

        ICollection<DateTime> TimestampReader.ReadAll()
        {
            TimestampReader reader = this;
            foreach (var timestamp in reader.Read())
            {
                break;
            }

            var w = this.web;
            var trapper = w.Run<EnumerableTrapper<DateTime>>();
            return trapper.TrappedCollection;
        }

        protected virtual ICollection<DateTime> readAllTimestamps()
        {
            ICollection<DateTime> collection = new LinkedList<DateTime>();
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                Directory.CreateDirectory(md);
            }

            foreach (var filePath in Directory.GetFiles(md))
            {
                foreach (var tickCount in File.ReadAllLines(filePath))
                {
                    collection.Add(new DateTime(long.Parse(tickCount)));
                }
            }

            return collection;
        }

        void TimestampWriter.Write()
        {
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                Directory.CreateDirectory(md);
            }

            var w = this.web;
            var now = DateTime.Now;
            var calc = w.Run<DateCalculator>();
            var startOfWeek = calc.StartOfWeek();
            var fileName = startOfWeek.Year
                           + startOfWeek.Month.ToString().PadLeft(2, '0')
                           + startOfWeek.Day.ToString().PadLeft(2, '0');
            var times = new LinkedList<string>();
            var filePath = Path.Combine(md, fileName);
            if (File.Exists(filePath))
            {
                foreach(var time in File.ReadAllLines(filePath))
                {
                    times.AddLast(time);
                }
            }

            times.AddLast(now.Ticks.ToString());
            var serializableTimes = new string[times.Count];
            times.CopyTo(serializableTimes, 0);
            File.WriteAllLines(filePath, serializableTimes);
            Interlocked.CompareExchange(ref this.needToTrapIf1, 1, 0);
        }

        void TimestampWriter.EditLastTimestamp(DateTime newTimestamp)
        {
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                return;
            }

            var orderedPaths = EnumerableHelpers.OrderByDescending(
                Directory.GetFiles(md), 
                s => s);
            if (orderedPaths.Count == 0)
            {
                return;
            }

            var path = EnumerableHelpers.First(orderedPaths);
            var times = File.ReadAllLines(path);
            if (times.Length == 0)
            {
                return;
            }

            times[times.Length - 1]
                = newTimestamp.Ticks.ToString();
            File.WriteAllLines(path, times);
            Interlocked.CompareExchange(ref this.needToTrapIf1, 1, 0);
        }

        private long firstReadIf0, needToTrapIf1, readingIf1;
        private readonly MethodWeb web;
        private readonly string mainDirectory;
    }
}
