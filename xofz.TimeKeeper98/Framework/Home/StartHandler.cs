namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            w.Run<TimerHandler>(handler =>
            {
                handler.Handle(ui);
            });
            w.Run<xofz.Framework.Timer>(t =>
                {
                    t.Start(1000);
                },
                DependencyNames.Timer);
        }

        protected readonly MethodWeb web;
    }
}
