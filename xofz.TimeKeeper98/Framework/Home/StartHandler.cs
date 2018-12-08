namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;

    public class StartHandler
    {
        public StartHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<xofz.Framework.Timer>(t =>
                {
                    w.Run<xofz.Framework.EventRaiser>(er =>
                    {
                        er.Raise(
                            t,
                            nameof(t.Elapsed));
                    });

                    t.Start(1000);
                },
                "HomeTimer");
        }

        protected readonly MethodWeb web;
    }
}
