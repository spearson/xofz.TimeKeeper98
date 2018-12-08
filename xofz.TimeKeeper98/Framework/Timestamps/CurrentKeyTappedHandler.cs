namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class CurrentKeyTappedHandler
    {
        public CurrentKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampsUi ui,
            HomeNavUi homeNavUi,
            StatisticsUi statsUi)
        {
            var w = this.web;
            w.Run<SettingsHolder>(settings =>
            {
                settings.ShowCurrent = true;
            });

            w.Run<StartHandler>(handler =>
            {
                handler.Handle(ui, homeNavUi, statsUi);
            });
        }

        protected readonly MethodWeb web;
    }
}
