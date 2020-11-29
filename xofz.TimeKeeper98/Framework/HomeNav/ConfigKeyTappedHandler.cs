namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class ConfigKeyTappedHandler
    {
        public ConfigKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r?.Run<NavLogicReader>(reader =>
            {
                reader.ReadConfig(
                    out var present);
                present?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
