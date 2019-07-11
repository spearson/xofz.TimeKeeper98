namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class PromptUnselectedHandler
    {
        public PromptUnselectedHandler(
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
                if (settings.Prompt)
                {
                    settings.Prompt = false;
                    r.Run<ConfigSaver>(saver =>
                    {
                        saver.Save();
                    });
                }
            });
        }

        protected readonly MethodRunner runner;
    }
}
