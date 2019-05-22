namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class StatisticsKeyTappedHandler
    {
        public StatisticsKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r.Run<NavLogicReader>(reader =>
            {
                reader.ReadStatistics(
                    out var navToStats);
                navToStats?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
