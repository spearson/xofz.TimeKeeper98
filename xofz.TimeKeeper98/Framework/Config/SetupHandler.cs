namespace xofz.TimeKeeper98.Framework.Config
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

        public virtual void Handle(ConfigUi ui)
        {
            var w = this.web;
            w.Run<GlobalSettingsHolder>(settings =>
            {
                var p = settings.Prompt;
                if (p)
                {
                    w.Run<UiReaderWriter>(uiRW =>
                    {
                        uiRW.WriteSync(
                            ui,
                            () => ui.PromptChecked = true);
                    });

                    w.Run<PromptSelectedHandler>(
                        handler => handler.Handle(ui));
                    return;
                }

                w.Run<PromptUnselectedHandler>(handler =>
                    handler.Handle(ui));
            });

            w.Run<ResetTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(ui);
            });

            w.Run<GlobalSettingsHolder>(settings =>
            {
                var ss = settings.ShowSeconds;
                if (ss)
                {
                    w.Run<UiReaderWriter>(uiRW =>
                    {
                        uiRW.WriteSync(
                            ui,
                            () => ui.ShowSecondsChecked = true);
                    });

                    w.Run<ShowSecondsSelectedHandler>(
                        handler => handler.Handle());
                    return;
                }

                w.Run<ShowSecondsUnselectedHandler>(handler =>
                    handler.Handle());
            });
        }

        protected readonly MethodWeb web;
    }
}
