namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;



    public class ShowSecondsSelectedHandler
    {
        public ShowSecondsSelectedHandler(
            MethodWebV2 web)
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
                if (!settings.ShowSeconds)
                {
                    settings.ShowSeconds = true;
                    w.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });
                }
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
