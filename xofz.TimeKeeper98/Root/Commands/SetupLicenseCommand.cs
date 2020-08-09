namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;

    public class SetupLicenseCommand 
        : Command
    {
        public SetupLicenseCommand(
            LicenseUi ui,
            MethodWeb web)
        {
            this.ui = ui;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new LicensePresenter(
                    this.ui,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new AcceptKeyTappedHandler(w));
            w.RegisterDependency(
                new RejectKeyTappedHandler(w));
        }

        protected readonly LicenseUi ui;
        protected readonly MethodWeb web;
    }
}
