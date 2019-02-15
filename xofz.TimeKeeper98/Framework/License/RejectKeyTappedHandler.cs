namespace xofz.TimeKeeper98.Framework.License
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class RejectKeyTappedHandler
    {
        public RejectKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            LicenseUi ui)
        {
            var w = this.web;
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
