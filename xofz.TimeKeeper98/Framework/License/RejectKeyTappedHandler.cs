namespace xofz.TimeKeeper98.Framework.License
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class RejectKeyTappedHandler
    {
        public RejectKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            LicenseUi ui)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    ui.Hide);
            });
        }

        protected readonly MethodRunner runner;
    }
}
