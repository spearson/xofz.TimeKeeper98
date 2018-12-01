namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupStatisticsCommand : Command
    {
        public SetupStatisticsCommand(
            StatisticsUi ui,
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
            new StatisticsPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "StatisticsTimer");
        }

        private readonly StatisticsUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
