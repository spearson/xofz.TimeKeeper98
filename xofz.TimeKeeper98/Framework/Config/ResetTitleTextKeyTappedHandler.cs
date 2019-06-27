namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class ResetTitleTextKeyTappedHandler
    {
        public ResetTitleTextKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var r = this.runner;
            r.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, uiRW) =>
                {
                    var titleText = settings.TitleText;
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TitleText = titleText;
                        });
                });
        }

        protected readonly MethodRunner runner;
    }
}
