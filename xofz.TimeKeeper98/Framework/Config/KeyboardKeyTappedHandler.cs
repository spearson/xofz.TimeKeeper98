namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class KeyboardKeyTappedHandler
    {
        public KeyboardKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var r = this.runner;
            r?.Run<KeyboardLoader>(loader =>
            {
                try
                {
                    loader.Load();
                }
                catch
                {
                    // oh noes!! windows 98!
                }
            });

            r?.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    ui.FocusTitleTextTextBox);
            });
        }

        protected readonly MethodRunner runner;
    }
}
