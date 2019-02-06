namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class StatisticsKeyTappedHandler
    {
        public StatisticsKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadStatistics(
                    out var navToStats);
                navToStats?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
