using xofz.Framework;

namespace xofz.TimeKeeper98.Framework.Statistics
{
    public class StopHandler
    {
        public StopHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<xofz.Framework.Timer>(t =>
                {
                    t.Stop();
                },
                @"StatisticsTimer");
        }

        protected readonly MethodWeb web;
    }
}
