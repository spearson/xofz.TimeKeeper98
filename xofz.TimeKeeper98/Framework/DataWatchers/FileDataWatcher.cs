namespace xofz.TimeKeeper98.Framework.DataWatchers
{
    using System.IO;
    using System.Threading;
    using xofz.Framework;

    public sealed class FileDataWatcher 
        : DataWatcher
    {
        public FileDataWatcher(
            MethodWeb web)
            : base(web)
        {
            this.web = web;
        }

        public override void Setup()
        {
            const byte one = 1;
            if (Interlocked.Exchange(
                    ref this.setupIf1, 
                    one) == one)
            {
                return;
            }

            var w = this.web;
            w?.RegisterDependency(
                new FileSystemWatcher(
                    FileTimestampManager.DataDirectory));
            w?.Run<FileSystemWatcher, EventSubscriber>(
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

            w?.RegisterDependency(this);
        }

        public override void Start()
        {
            var w = this.web;
            w?.Run<FileSystemWatcher>(watcher =>
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

        public override void Stop()
        {
            var w = this.web;
            w?.Run<FileSystemWatcher>(watcher =>
            {
                watcher.EnableRaisingEvents = false;
            });
        }

        private void fileWatcher_ChangedCreatedOrDeleted(
            object sender, 
            FileSystemEventArgs e)
        {
            this.pingApp();
        }

        private void fileWatcher_Renamed(
            object sender,
            RenamedEventArgs e)
        {
            this.pingApp();
        }

        private long setupIf1;
        private readonly MethodWeb web;
    }
}
