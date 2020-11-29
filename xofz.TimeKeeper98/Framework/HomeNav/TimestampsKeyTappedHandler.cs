namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class TimestampsKeyTappedHandler
    {
        public TimestampsKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r?.Run<NavLogicReader>(reader =>
            {
                reader.ReadTimestamps(
                    out var navToTimestamps);
                navToTimestamps?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
