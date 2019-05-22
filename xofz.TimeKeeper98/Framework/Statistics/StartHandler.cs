namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeNavUi hnUi)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    hnUi,
                    () => hnUi.ActiveKeyLabel = 
                        NavKeyLabels.Statistics);
            });
            r.Run<xofz.Framework.Timer>(t =>
                {
                    r.Run<EventRaiser>(er =>
                    {
                        er.Raise(
                            t,
                            nameof(t.Elapsed));
                    });

                    t.Start(1000);
                },
                DependencyNames.Timer);
        }

        protected readonly MethodRunner runner;
    }
}
