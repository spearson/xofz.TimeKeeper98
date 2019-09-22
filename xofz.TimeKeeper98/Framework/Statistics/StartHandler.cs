namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui,
            HomeNavUi hnUi)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    hnUi,
                    () =>
                    {
                        hnUi.ActiveKeyLabel =
                            NavKeyLabels.Statistics;
                    });
            });

            r.Run<TimerHandler>(handler =>
            {
                handler.Handle(
                    ui);
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
