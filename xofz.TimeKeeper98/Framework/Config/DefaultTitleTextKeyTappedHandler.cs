namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class DefaultTitleTextKeyTappedHandler
    {
        public DefaultTitleTextKeyTappedHandler(
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
                    var titleText = UiConstants.DefaultTitle;
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TitleText = titleText;
                        });
                    settings.TitleText = titleText;
                    r.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });

                    r.Run<TitleUi>(shell =>
                    {
                        uiRW.Write(
                            shell,
                            () =>
                            {
                                shell.Title = titleText;
                            });
                    });
                });
        }

        protected readonly MethodRunner runner;
    }
}
