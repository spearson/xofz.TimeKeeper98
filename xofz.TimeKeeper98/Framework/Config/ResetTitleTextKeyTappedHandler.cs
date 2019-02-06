namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class ResetTitleTextKeyTappedHandler
    {
        public ResetTitleTextKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(ConfigUi ui)
        {
            var w = this.web;
            w.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, uiRW) =>
                {
                    var titleText = settings.TitleText;
                    uiRW.Write(
                        ui,
                        () => ui.TitleText = titleText);
                });
        }

        protected readonly MethodWeb web;
    }
}
