namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;

    public class FileTimestampManager 
        : TimestampReader, TimestampWriter
    {
        public FileTimestampManager(MethodWeb web)
        {
            this.web = web;
            this.mainDirectory = DataDirectory;
        }

        public const string DataDirectory = @"Data";

        public const string DataFileName = @"AllData";

        public virtual bool ConvertToSingleFile()
        {
            var md = this.mainDirectory;
            try
            {
                if (!Directory.Exists(md))
                {
                    Directory.CreateDirectory(md);
                    return true;
                }
            }
            catch
            {
                return false;
            }

            try
            {
                var files = Directory.GetFiles(md);
                if (files.Length == 1 && 
                    files[0].Contains(DataFileName))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            ICollection<string> times = new LinkedList<string>();
            try
            {
                foreach (var file in Directory.GetFiles(md))
                {
                    foreach (var line in File.ReadAllLines(file))
                    {
                        times.Add(line);
                    }
                }
            }
            catch
            {
                return false;
            }

            try
            {
                File.WriteAllLines(
                    Path.Combine(md, DataFileName),
                    EnumerableHelpers.ToArray(
                        times));
                foreach (var file in Directory.GetFiles(md))
                {
                    if (file.Contains(DataFileName))
                    {
                        continue;
                    }

                    File.Delete(file);
                }
            }
            catch
            {
                return false;
            }

            return true;
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
            if (Interlocked.CompareExchange(
                    ref this.firstReadIf0, 
                    1, 
                    0) == 0)
            {
                firstRead = true;
                trapper.TrapNow(this.readAllTimestamps());
            }

            w.Run<FieldHolder>(holder =>
            {
                if (Interlocked.CompareExchange(
                        ref holder.needToTrapIf1, 
                        0, 
                        1) == 1)
                {
                    if (!firstRead)
                    {
                        trapper.TrapNow(this.readAllTimestamps());
                    }
                }
            });

            Interlocked.CompareExchange(
                ref this.readingIf1, 
                0, 
                1);
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
            return w.Run<EnumerableTrapper<DateTime>>()
                       ?.TrappedCollection
                   ?? new LinkedList<DateTime>();
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
                IEnumerable<string> lines;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch
                {
                    continue;
                }

                foreach (var line in lines)
                {
                    if (!long.TryParse(line, out var ticks))
                    {
                        continue;
                    }

                    collection.Add(new DateTime(ticks));
                }
            }

            return collection;
        }

        bool TimestampWriter.Write()
        {
            var w = this.web;
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                try
                {
                    Directory.CreateDirectory(md);
                }
                catch
                {
                    return false;
                }
            }

            var tickCount = DateTime.Now.Ticks;
            var filePath = Path.Combine(md, DataFileName);

            try
            {
                if (File.Exists(filePath))
                {
                    File.AppendAllText(
                        filePath,
                        Environment.NewLine + tickCount);
                    goto succeeded;
                }
            }
            catch
            {
                return false;
            }

            try
            {
                File.WriteAllText(filePath, tickCount.ToString());
            }
            catch
            {
                return false;
            }
            
            succeeded:
            w.Run<FieldHolder>(holder =>
            {
                Interlocked.CompareExchange(
                    ref holder.needToTrapIf1,
                    1,
                    0);
            });
            
            return true;
        }

        void TimestampWriter.EditLastTimestamp(DateTime newTimestamp)
        {
            var w = this.web;
            var md = this.mainDirectory;
            if (!Directory.Exists(md))
            {
                return;
            }

            var orderedPaths = EnumerableHelpers.OrderByDescending(
                Directory.GetFiles(md), 
                s => s);
            if (orderedPaths.Count < 1)
            {
                return;
            }

            var path = EnumerableHelpers.First(orderedPaths);
            string[] times;
            try
            {
                times = File.ReadAllLines(path);
            }
            catch
            {
                return;
            }        
            
            if (times.Length < 1)
            {
                return;
            }

            times[times.Length - 1]
                = newTimestamp.Ticks.ToString();
            try
            {
                File.WriteAllLines(path, times);
            }
            catch
            {
                return;
            }

            w.Run<FieldHolder>(holder =>
            {
                Interlocked.CompareExchange(
                    ref holder.needToTrapIf1,
                    1,
                    0);
            });

        }

        protected long firstReadIf0, readingIf1;
        protected readonly MethodWeb web;
        protected readonly string mainDirectory;
    }
}
