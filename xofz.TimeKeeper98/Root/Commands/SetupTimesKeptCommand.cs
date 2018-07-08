namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupTimesKeptCommand : Command
    {
        public SetupTimesKeptCommand(
            TimesKeptUi ui,
            ShellUi shell,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new TimesKeptPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new EnumerableSplitter());
            w.RegisterDependency(
                new EnumerableSplicer());
        }

        private readonly TimesKeptUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
