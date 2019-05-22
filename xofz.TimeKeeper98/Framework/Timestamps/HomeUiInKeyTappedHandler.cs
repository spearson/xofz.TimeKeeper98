namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class HomeUiInKeyTappedHandler
    {
        public HomeUiInKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampsUi ui,
            HomeNavUi homeNavUi,
            StatisticsUi statsUi)
        {
            var r = this.runner;
            r.Run<StartHandler>(handler =>
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
