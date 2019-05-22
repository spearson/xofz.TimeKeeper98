namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodWeb runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var r = this.runner;
            r.Run<TimerHandler>(handler =>
            {
                handler.Handle(ui);
            });
            r.Run<xofz.Framework.Timer>(t =>
                {
                    t.Start(1000);
                },
                DependencyNames.Timer);
        }

        protected readonly MethodRunner runner;
    }
}
