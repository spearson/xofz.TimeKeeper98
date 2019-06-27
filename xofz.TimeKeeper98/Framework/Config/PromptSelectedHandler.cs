namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class PromptSelectedHandler
    {
        public PromptSelectedHandler(
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
                settings.Prompt = true;
                r.Run<ConfigSaver>(saver =>
                {
                    saver.Save();
                });
            });
        }

        protected readonly MethodRunner runner;
    }
}
