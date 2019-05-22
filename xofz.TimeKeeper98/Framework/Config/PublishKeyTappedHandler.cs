namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;

    public class PublishKeyTappedHandler
    {
        public PublishKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r.Run<NavLogicReader>(reader =>
            {
                reader.ReadLicense(
                    out var presentLicense);
                presentLicense?.Invoke();
            });
        }

        protected readonly MethodRunner runner;
    }
}
