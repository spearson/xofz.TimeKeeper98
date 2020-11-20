namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;

    public class FileTimestampManager 
        : TimestampReaderWriter
    {
        public FileTimestampManager(
            MethodRunner runner)
        {
            this.runner = runner;
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
            while (Interlocked.Exchange(
                ref this.readingIf1, 
                1) == 1)
            {
                Thread.Sleep(0);
            }

            var r = this.runner;
            var trapper = r.Run<EnumerableTrapper<DateTime>>();
            if (trapper == null)
            {
                yield break;
            }

            var firstRead = false;
            if (Interlocked.Exchange(
                    ref this.firstReadIf0, 
                    1) == 0)
            {
                firstRead = true;
                trapper.TrapNow(this.readAllTimestamps());
            }

            r.Run<FieldHolder>(holder =>
            {
                if (Interlocked.Exchange(
                        ref holder.needToTrapIf1, 
                        0) == 1)
                {
                    if (!firstRead)
                    {
                        trapper.TrapNow(this.readAllTimestamps());
                    }
                }
            });

            Interlocked.Exchange(
                ref this.readingIf1, 
                0);
            var tc = trapper.TrappedCollection;
            if (tc == null)
            {
                yield break;
            }

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

            var r = this.runner;
            return r.Run<EnumerableTrapper<DateTime>>()
                       ?.TrappedCollection
                   ?? new LinkedList<DateTime>();
        }

        protected virtual ICollection<DateTime> readAllTimestamps()
        {
            ICollection<DateTime> collection = new LinkedList<DateTime>();
            var md = this.mainDirectory;
            try
            {
                if (!Directory.Exists(md))
                {
                    Directory.CreateDirectory(md);
                }
            }
            catch
            {
                return collection;
            }

            string[] allDataFiles;
            try
            {
                allDataFiles = Directory.GetFiles(md);
            }
            catch
            {
                return collection;
            }

            foreach (var filePath in allDataFiles)
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

            collection = EnumerableHelpers.OrderBy(
                collection,
                timestamp => timestamp);

            return collection;
        }

        bool TimestampWriter.Write()
        {
            var r = this.runner;
            var md = this.mainDirectory;
            string filePath;

            try
            {
                if (!Directory.Exists(md))
                {
                    Directory.CreateDirectory(md);
                }

                filePath = Path.Combine(md, DataFileName);
            }
            catch
            {
                return false;
            }

            var now = DateTime.Now;
            r.Run<TimeProvider>(provider =>
            {
                now = provider.Now();
            });

            var tickCount = now.Ticks;
            try
            {
                if (File.Exists(filePath))
                {
                    ICollection<string> allTimes = new LinkedList<string>(
                        File.ReadAllLines(filePath));
                    allTimes = EnumerableHelpers.OrderBy(
                        allTimes,
                        s => s,
                        StringComparer.InvariantCulture);
                    if (allTimes.Count < 1)
                    {
                        goto writeNewFile;
                    }

                    allTimes.Add(tickCount.ToString());
                    var array = EnumerableHelpers.ToArray(
                        allTimes);
                    File.WriteAllLines(filePath, array);

                    goto succeeded;
                }
            }
            catch
            {
                return false;
            }

            writeNewFile:
            try
            {
                File.WriteAllText(filePath, tickCount.ToString());
            }
            catch
            {
                return false;
            }
            
            succeeded:
            r.Run<FieldHolder>(holder =>
            {
                Interlocked.Exchange(
                    ref holder.needToTrapIf1,
                    1);
            });
            
            return true;
        }

        void TimestampWriter.EditLastTimestamp(
            DateTime newTimestamp)
        {
            var r = this.runner;
            var md = this.mainDirectory;
            string[] allDataFiles;
            try
            {
                if (!Directory.Exists(md))
                {
                    return;
                }

                allDataFiles = Directory.GetFiles(md);
            }
            catch
            {
                return;
            }


            var orderedPaths = EnumerableHelpers.OrderByDescending(
                allDataFiles,
                s => s);
            if (orderedPaths.Count < 1)
            {
                return;
            }

            var path = EnumerableHelpers.First(
                orderedPaths);
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

            times = EnumerableHelpers.ToArray(
                EnumerableHelpers.OrderBy(
                    times,
                    ts => ts,
                    StringComparer.InvariantCulture));

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

            r.Run<FieldHolder>(holder =>
            {
                Interlocked.Exchange(
                    ref holder.needToTrapIf1,
                    1);
            });

        }

        protected long firstReadIf0, readingIf1;
        protected readonly MethodRunner runner;
        protected readonly string mainDirectory;
    }
}
