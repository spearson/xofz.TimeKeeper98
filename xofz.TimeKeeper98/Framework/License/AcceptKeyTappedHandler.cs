namespace xofz.TimeKeeper98.Framework.License
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class AcceptKeyTappedHandler
    {
        public AcceptKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            LicenseUi ui)
        {
            var w = this.web;
            w.Run<Core98Publisher>(pub =>
            {
                pub.Publish();
            });

            w.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    ui.Hide);
            });
        }

        protected readonly MethodWeb web;
    }
}
