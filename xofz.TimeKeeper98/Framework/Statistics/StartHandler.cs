using xofz.Framework;
using xofz.TimeKeeper98.UI;
using xofz.UI;

namespace xofz.TimeKeeper98.Framework.Statistics
{
    public class StartHandler
    {
        public StartHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeNavUi hnUi)
        {
            var w = this.web;
            w.Run<UiReaderWriter>(rw =>
            {
                rw.Write(
                    hnUi,
                    () => hnUi.ActiveKeyLabel = @"Statistics");
            });

            w.Run<xofz.Framework.Timer>(t =>
                {
                    w.Run<EventRaiser>(er =>
                    {
                        er.Raise(
                            t,
                            nameof(t.Elapsed));
                    });
                    t.Start(1000);
                },
                "StatisticsTimer");
        }

        protected readonly MethodWeb web;
    }
}
