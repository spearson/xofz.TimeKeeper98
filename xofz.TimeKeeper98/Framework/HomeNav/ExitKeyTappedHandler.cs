namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class ExitKeyTappedHandler
    {
        public ExitKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadExit(
                    out var exit);
                exit?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
