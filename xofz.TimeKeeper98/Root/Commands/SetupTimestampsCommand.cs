namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupTimestampsCommand : Command
    {
        public SetupTimestampsCommand(
            TimestampsUi ui,
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
            new TimestampsPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new EnumerableSplitter());
            w.RegisterDependency(
                new EnumerableSplicer());
        }

        private readonly TimestampsUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
