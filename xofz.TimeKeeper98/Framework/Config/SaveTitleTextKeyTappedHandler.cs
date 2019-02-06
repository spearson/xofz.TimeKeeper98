namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveTitleTextKeyTappedHandler
    {
        public SaveTitleTextKeyTappedHandler(
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
                    var tt = uiRW.Read(
                        ui,
                        () => ui.TitleText);
                    settings.TitleText = tt;
                    w.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });
                    w.Run<TitleUi>(shell =>
                    {
                        uiRW.WriteSync(
                            shell,
                            () => shell.Title = tt);
                    });
                });
        }

        protected readonly MethodWeb web;
    }
}
