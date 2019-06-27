namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers;
    using xofz.TimeKeeper98.Framework.TimeSpanViewers;

    public class ShowSecondsUnselectedHandler
    {
        public ShowSecondsUnselectedHandler(
            MethodWebV2 web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Unregister<PaddedTimeSpanViewer>();
            w.RegisterDependency(new MinutesPaddedTimeSpanViewer());
            w.Unregister<TimeSpanViewer>();
            w.RegisterDependency(
                new MinutesTimeSpanViewer());
            w.Run<GlobalSettingsHolder>(settings =>
            {
                settings.ShowSeconds = false;
                w.Run<ConfigSaver>(saver =>
                {
                    saver.Save();
                });
            });
            w.Run<Do>(
                refreshHome =>
                {
                    refreshHome?.Invoke();
                },
                MethodNames.RefreshHome);
            w.Run<Do>(
                refreshTimestamps =>
                {
                    refreshTimestamps?.Invoke();
                },
                MethodNames.RefreshTimestamps);
            w.Run<Do>(
                refreshDaily =>
                {
                    refreshDaily?.Invoke();
                },
                MethodNames.RefreshDaily);
        }

        protected readonly MethodWebV2 web;
    }
}
