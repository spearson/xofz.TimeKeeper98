namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                r.Run<
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

                r.Run<VersionReader>(
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

                r.Run<TitleUi, GlobalSettingsHolder>(
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

        protected readonly MethodRunner runner;
    }
}
