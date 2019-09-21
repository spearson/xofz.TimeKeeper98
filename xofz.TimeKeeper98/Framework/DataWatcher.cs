namespace xofz.TimeKeeper98.Framework
{
    using System.Threading;
    using xofz.Framework;

    public abstract class DataWatcher
    {
        public DataWatcher(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Setup()
        {
        }

        public abstract void Start();

        public abstract void Stop();

        protected virtual void pingApp()
        {
            var r = this.runner;
            r.Run<FieldHolder>(holder =>
            {
                Interlocked.CompareExchange(
                    ref holder.needToTrapIf1,
                    1,
                    0);
            });
            r.Run<Do>(refreshHome =>
                {
                    refreshHome.Invoke();
                },
                MethodNames.RefreshHome);
            r.Run<Do>(refreshTimestamps =>
                {
                    refreshTimestamps.Invoke();
                },
                MethodNames.RefreshTimestamps);
            r.Run<Do>(refreshDaily =>
                {
                    refreshDaily.Invoke();
                },
                MethodNames.RefreshDaily);
            r.Run<Do>(refreshConfig =>
                {
                    refreshConfig.Invoke();
                },
                MethodNames.RefreshConfig);
        }

        protected readonly MethodRunner runner;
    }
}
