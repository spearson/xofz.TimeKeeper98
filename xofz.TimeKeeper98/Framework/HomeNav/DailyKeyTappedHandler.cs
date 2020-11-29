namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class DailyKeyTappedHandler
    {
        public DailyKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r?.Run<NavLogicReader>(reader =>
            {
                reader.ReadDaily(
                    out var present);
                present?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
