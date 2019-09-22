namespace xofz.TimeKeeper98.Framework.Config
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
            ConfigUi ui)
        {
            var r = this.runner;
            r.Run<GlobalSettingsHolder>(settings =>
            {
                var p = settings.Prompt;
                if (p)
                {
                    r.Run<UiReaderWriter>(uiRW =>
                    {
                        uiRW.WriteSync(
                            ui,
                            () =>
                            {
                                ui.PromptChecked = true;
                            });
                    });

                    r.Run<PromptSelectedHandler>(
                        handler =>
                        {
                            handler.Handle(ui);
                        });
                    return;
                }

                r.Run<PromptUnselectedHandler>(handler =>
                {
                    handler.Handle(ui);
                });
            });

            r.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, uiRW) =>
                {
                    var interval = settings
                        .TimerIntervalSeconds;
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TimerIntervalSeconds = interval;
                        });

                });

            r.Run<ResetTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(ui);
            });

            r.Run<GlobalSettingsHolder>(settings =>
            {
                var ss = settings.ShowSeconds;
                if (ss)
                {
                    r.Run<UiReaderWriter>(uiRW =>
                    {
                        uiRW.WriteSync(
                            ui,
                            () =>
                            {
                                ui.ShowSecondsChecked = true;
                            });
                    });

                    r.Run<ShowSecondsSelectedHandler>(
                        handler =>
                        {
                            handler.Handle();
                        });
                    return;
                }

                r.Run<ShowSecondsUnselectedHandler>(
                    handler =>
                {
                    handler.Handle();
                });
            });
        }

        protected readonly MethodRunner runner;
    }
}
