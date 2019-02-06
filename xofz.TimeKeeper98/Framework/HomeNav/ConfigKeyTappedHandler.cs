namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class ConfigKeyTappedHandler
    {
        public ConfigKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadConfig(
                    out var present);
                present?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
