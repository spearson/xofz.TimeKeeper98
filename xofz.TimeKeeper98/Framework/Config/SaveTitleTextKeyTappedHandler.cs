namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveTitleTextKeyTappedHandler
    {
        public SaveTitleTextKeyTappedHandler(
            MethodWeb runner)
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
                    var tt = uiRW.Read(
                        ui,
                        () => ui.TitleText);
                    settings.TitleText = tt;
                    r.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });
                    r.Run<TitleUi>(shell =>
                    {
                        uiRW.WriteSync(
                            shell,
                            () => shell.Title = tt);
                    });
                });
        }

        protected readonly MethodRunner runner;
    }
}
