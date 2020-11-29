namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class ShowDurationsChangedHandler
    {
        public ShowDurationsChangedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampsUi ui,
            HomeNavUi homeNavUi,
            StatisticsUi statsUi,
            bool shouldShow)
        {
            var r = this.runner;
            r?.Run<SettingsHolder>(settings =>
            {
                settings.ShowDurations = shouldShow;
            });
            r?.Run<StartHandler>(handler =>
            {
                handler.Handle(
                    ui,
                    homeNavUi,
                    statsUi);
            });
        }

        protected readonly MethodRunner runner;
    }
}
