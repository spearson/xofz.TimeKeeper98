namespace xofz.TimeKeeper98.Framework.Daily
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class StatisticsRangeKeyTappedHandler
    {
        public StatisticsRangeKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            DailyUi ui,
            StatisticsUi statsUi,
            HomeNavUi homeNavUi)
        {
            var w = this.web;
            w.Run<SettingsHolder>(settings =>
            {
                settings.ShowCurrent = false;
            });

            w.Run<StartHandler>(handler =>
            {
                handler.Handle(ui, statsUi, homeNavUi);
            });
        }

        protected readonly MethodWeb web;
    }
}
