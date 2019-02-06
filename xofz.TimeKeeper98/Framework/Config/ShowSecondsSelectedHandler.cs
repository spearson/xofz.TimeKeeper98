namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;

    public class ShowSecondsSelectedHandler
    {
        public ShowSecondsSelectedHandler(
            ThreadSafeMethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Unregister<PaddedTimeSpanViewer>();
            w.RegisterDependency(new PaddedTimeSpanViewer());
            w.Unregister<TimeSpanViewer>();
            w.RegisterDependency(
                new TimeSpanViewer());
            w.Run<GlobalSettingsHolder>(settings =>
            {
                settings.ShowSeconds = true;
            });
            w.Run<ConfigSaver>(saver => { saver.Save(); });
            w.Run<Do, Do, Do>(
                (refreshHome, refreshTimestamps, refreshDaily) =>
                {
                    refreshHome?.Invoke();
                    refreshTimestamps?.Invoke();
                    refreshDaily?.Invoke();
                },
                MethodNames.RefreshHome,
                MethodNames.RefreshTimestamps,
                MethodNames.RefreshDaily);
        }

        protected readonly ThreadSafeMethodWeb web;
    }
}
