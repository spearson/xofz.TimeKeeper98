namespace xofz.TimeKeeper98.Framework.Daily
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class HomeUiOutKeyTappedHandler
    {
        public HomeUiOutKeyTappedHandler(
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
            w.Run<StartHandler>(handler =>
                handler.Handle(
                    ui,
                    statsUi,
                    homeNavUi));
        }

        protected readonly MethodWeb web;
    }
}
