namespace xofz.TimeKeeper98.Framework.Timestamps
{
    using xofz.Framework;

    public class SetupHandler
    {
        public SetupHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<SettingsHolder>(settings =>
            {
                settings.ShowCurrent = true;
            });
        }

        protected readonly MethodWeb web;
    }
}
