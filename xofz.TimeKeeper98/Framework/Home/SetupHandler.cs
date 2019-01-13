namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;

            w.Run<UiReaderWriter>(uiRW =>
            {
                w.Run<
                    StatisticsCalculator,
                    TimestampReader>(
                    (calc, reader) =>
                    {
                        var currentlyIn = calc.ClockedIn();
                        var editKeyEnabled = false;
                        foreach (var timestamp in reader.Read())
                        {
                            editKeyEnabled = true;
                            break;
                        }

                        uiRW.Write(ui, () =>
                        {
                            ui.InKeyVisible = !currentlyIn;
                            ui.OutKeyVisible = currentlyIn;
                            ui.EditKeyEnabled = editKeyEnabled;
                        });
                    });

                w.Run<VersionReader>(
                    vr =>
                    {
                        var appVersion = vr.Read();
                        var coreVersion = vr.ReadCoreVersion();
                        uiRW.Write(
                            ui,
                            () =>
                            {
                                ui.Version = appVersion;
                                ui.CoreVersion = coreVersion;
                            });
                    });

                w.Run<TitleUi, GlobalSettingsHolder>(
                    (shell, settings) =>
                    {
                        var title = settings.TitleText;
                        uiRW.Write(
                            shell,
                            () =>
                            {
                                shell.Title = title;
                            });
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
