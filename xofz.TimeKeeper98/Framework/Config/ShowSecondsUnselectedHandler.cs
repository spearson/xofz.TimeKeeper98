﻿namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers;
    using xofz.TimeKeeper98.Framework.TimeSpanViewers;

    public class ShowSecondsUnselectedHandler
    {
        public ShowSecondsUnselectedHandler(
            ThreadSafeMethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Unregister<PaddedTimeSpanViewer>();
            w.RegisterDependency(new PaddedMinutesTimeSpanViewer());
            w.Unregister<TimeSpanViewer>();
            w.RegisterDependency(
                new MinutesTimeSpanViewer());
            w.Run<GlobalSettingsHolder>(settings =>
            {
                settings.ShowSeconds = false;
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
