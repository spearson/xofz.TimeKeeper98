namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class DailyKeyTappedHandler
    {
        public DailyKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadDaily(
                    out var present);
                present?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
