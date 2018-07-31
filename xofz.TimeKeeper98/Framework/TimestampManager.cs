namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;

    public sealed class TimestampManager : TimestampReader, TimestampWriter
    {
        public TimestampManager(MethodWeb web)
        {
            this.web = web;
            this.mainDirectory = "Data";
        }

        IEnumerable<DateTime> TimestampReader.Read()
        {
            var w = this.web;

            if (Interlocked.CompareExchange(ref this.firstReadIf0, 1, 0) == 0)
            {
                var trapper = w.Run<EnumerableTrapper<DateTime>>();
                return trapper.Trap(this.readInternal());
            }

            if (Interlocked.CompareExchange(ref this.needToTrapIf1, 0, 1) == 1)
            {
                var trapper = w.Run<EnumerableTrapper<DateTime>>();
                return trapper.Trap(this.readInternal());
            }

            var timestamps = MaterializedEnumerable.Empty<DateTime>();
            w.Run<EnumerableTrapper<DateTime>>(
                trapper => timestamps = trapper.TrappedCollection);

            return timestamps;
        }

        private IEnumerable<DateTime> readInternal()
        {
            var ll = new LinkedList<DateTime>();
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                Directory.CreateDirectory(md);
            }

            foreach (var filePath in Directory.GetFiles(md))
            {
                foreach (var tickCount in File.ReadAllLines(filePath))
                {
                    ll.AddLast(new DateTime(long.Parse(tickCount)));
                }
            }

            return ll;
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
            var times = new List<string>();
            var filePath = md + @"\" + fileName;
            if (File.Exists(filePath))
            {
                times.AddRange(File.ReadAllLines(filePath));
            }

            times.Add(now.Ticks.ToString());
            var serializableTimes = new string[times.Count];
            times.CopyTo(serializableTimes);
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

            var orderedPaths = EnumerableHelpers.OrderByDescending<string, string>(
                Directory.GetFiles(md), s => s);
            if (orderedPaths.Count == 0)
            {
                return;
            }

            var path = orderedPaths[0];
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

        private int firstReadIf0;
        private int needToTrapIf1;
        private readonly MethodWeb web;
        private readonly string mainDirectory;
    }
}
