namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;

    public class StopHandler
    {
        public StopHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r.Run<xofz.Framework.Timer>(t =>
                {
                    t.Stop();
                },
                DependencyNames.Timer);
        }

        protected readonly MethodRunner runner;
    }
}
