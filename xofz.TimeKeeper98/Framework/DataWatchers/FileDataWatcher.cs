namespace xofz.TimeKeeper98.Framework.DataWatchers
{
    using System.IO;
    using System.Threading;
    using xofz.Framework;

    public class FileDataWatcher 
        : DataWatcher
    {
        public FileDataWatcher(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Setup()
        {
            if (Interlocked.CompareExchange(
                    ref this.setupIf1, 
                    1, 
                    0) == 1)
            {
                return;
            }

            var w = this.web;
            w.RegisterDependency(
                new FileSystemWatcher(
                    FileTimestampManager.DataDirectory));
            w.Run<FileSystemWatcher, EventSubscriber>(
                (watcher, sub) =>
                {
                    FileSystemEventHandler handler
                        = this.fileWatcher_Changed;
                    sub.Subscribe(
                        watcher,
                        nameof(watcher.Changed),
                        handler);
                });
            w.RegisterDependency(this);
        }

        void DataWatcher.Start()
        {
            var w = this.web;
            w.Run<FileSystemWatcher>(watcher =>
            {
                watcher.EnableRaisingEvents = true;
            });
        }

        protected virtual void fileWatcher_Changed(
            object sender, 
            FileSystemEventArgs e)
        {
            var w = this.web;
            w.Run<FieldHolder>(holder =>
            {
                Interlocked.CompareExchange(
                    ref holder.needToTrapIf1,
                    1,
                    0);
            });
            w.Run<Do>(refreshHome =>
                {
                    refreshHome.Invoke();
                },
                MethodNames.RefreshHome);
            w.Run<Do>(refreshTimestamps =>
                {
                    refreshTimestamps.Invoke();
                },
                MethodNames.RefreshTimestamps);
            w.Run<Do>(refreshDaily =>
                {
                    refreshDaily.Invoke();
                },
                MethodNames.RefreshDaily);
        }

        protected long setupIf1;
        protected readonly MethodWeb web;
    }
}
