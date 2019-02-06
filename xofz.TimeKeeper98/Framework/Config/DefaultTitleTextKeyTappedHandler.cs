namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class DefaultTitleTextKeyTappedHandler
    {
        public DefaultTitleTextKeyTappedHandler(
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
                    var titleText = UiConstants.DefaultTitle;
                    uiRW.Write(
                        ui,
                        () => ui.TitleText = titleText);
                    settings.TitleText = titleText;
                    w.Run<ConfigSaver>(saver => { saver.Save(); });

                    w.Run<TitleUi>(shell =>
                    {
                        uiRW.WriteSync(
                            shell,
                            () => shell.Title = titleText);
                    });
                });
        }

        protected readonly MethodWeb web;
    }
}
