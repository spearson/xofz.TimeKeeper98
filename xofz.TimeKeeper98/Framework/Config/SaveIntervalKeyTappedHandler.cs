namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveIntervalKeyTappedHandler
    {
        public SaveIntervalKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                var interval = uiRW.Read(
                    ui,
                    () => ui.TimerIntervalSeconds);

                if (interval < 1)
                {
                    interval = 1;
                }

                r.Run<GlobalSettingsHolder>(settings =>
                {
                    settings.TimerIntervalSeconds = interval;
                    r.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });

                    r.Run<xofz.Framework.Timer>(t =>
                        {
                            t.Stop();
                            t.Start(interval * 1000);
                        },
                        Framework.Home.DependencyNames.Timer);
                });
            });
        }

        protected readonly MethodRunner runner;
    }
}
