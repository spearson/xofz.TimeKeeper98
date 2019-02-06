namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class KeyboardKeyTappedHandler
    {
        public KeyboardKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var w = this.web;
            w.Run<KeyboardLoader>(loader => loader.Load());
            w.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    ui.FocusTitleTextTextBox);
            });
        }

        protected readonly MethodWeb web;
    }
}
