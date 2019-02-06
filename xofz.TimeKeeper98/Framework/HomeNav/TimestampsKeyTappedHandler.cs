namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class TimestampsKeyTappedHandler
    {
        public TimestampsKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadTimestamps(
                    out var navToTimestamps);
                navToTimestamps?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
