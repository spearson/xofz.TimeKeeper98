namespace xofz.TimeKeeper98.Framework.HomeNav
{
    using xofz.Framework;

    public class ExitKeyTappedHandler
    {
        public ExitKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r?.Run<NavLogicReader>(reader =>
            {
                reader.ReadExit(
                    out var exit);
                exit?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
