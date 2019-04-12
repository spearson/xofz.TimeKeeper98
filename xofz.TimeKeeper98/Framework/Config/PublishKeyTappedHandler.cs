namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;

    public class PublishKeyTappedHandler
    {
        public PublishKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<NavLogicReader>(reader =>
            {
                reader.ReadLicense(
                    out var presentLicense);
                presentLicense?.Invoke();
            });
        }

        protected readonly MethodWeb web;
    }
}
