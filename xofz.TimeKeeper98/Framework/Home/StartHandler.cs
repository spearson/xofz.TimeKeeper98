namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
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
            r.Run<xofz.Framework.Timer, GlobalSettingsHolder>(
                (t, settings) =>
                {
                    var interval = settings.TimerIntervalSeconds;
                    if (interval < 1)
                    {
                        interval = 1;
                    }

                    t.Start(interval * 1000);
                },
                DependencyNames.Timer);
        }

        protected readonly MethodRunner runner;
    }
}
