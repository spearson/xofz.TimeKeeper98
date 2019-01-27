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
                        = this.fileWatcher_ChangedCreatedOrDeleted;
                    RenamedEventHandler handler2
                        = this.fileWatcher_Renamed;
                    sub.Subscribe(
                        watcher,
                        nameof(watcher.Changed),
                        handler);
                    sub.Subscribe(
                        watcher,
                        nameof(watcher.Created),
                        handler);
                    sub.Subscribe(
                        watcher,
                        nameof(watcher.Deleted),
                        handler);
                    sub.Subscribe(
                        watcher,
                        nameof(watcher.Renamed),
                        handler2);
                });
            w.RegisterDependency(this);
        }

        void DataWatcher.Start()
        {
            var w = this.web;
            w.Run<FileSystemWatcher>(watcher =>
            {
                try
                {
                    watcher.EnableRaisingEvents = true;
                }
                catch
                {
                    // oh no!! windows 98!
                }
            });
        }

        void DataWatcher.Stop()
        {
            var w = this.web;
            w.Run<FileSystemWatcher>(watcher =>
            {
                watcher.EnableRaisingEvents = false;
            });
        }

        protected virtual void fileWatcher_ChangedCreatedOrDeleted(
            object sender, 
            FileSystemEventArgs e)
        {
            this.pingApp();
        }

        protected virtual void fileWatcher_Renamed(
            object sender,
            RenamedEventArgs e)
        {
            this.pingApp();
        }

        protected virtual void pingApp()
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
