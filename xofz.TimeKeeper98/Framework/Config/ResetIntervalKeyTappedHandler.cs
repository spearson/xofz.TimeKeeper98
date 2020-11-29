namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class ResetIntervalKeyTappedHandler
    {
        public ResetIntervalKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var r = this.runner;
            r?.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, uiRW) =>
                {
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TimerIntervalSeconds =
                                settings.TimerIntervalSeconds;
                        });
                });
        }

        protected readonly MethodRunner runner;
    }
}
