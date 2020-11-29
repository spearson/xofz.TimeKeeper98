namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using xofz.Framework;

    public class SetupHandler
    {
        public SetupHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r?.Run<SettingsHolder>(settings =>
            {
                settings.ShowCurrent = true;
            });
        }

        protected readonly MethodRunner runner;
    }
}
