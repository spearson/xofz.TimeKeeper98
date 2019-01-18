namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
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
                DependencyNames.Timer);
            w.RegisterDependency(
                new SetupHandler(w));
            w.RegisterDependency(
                new StartHandler(w));
            w.RegisterDependency(
                new StopHandler(w));
            w.RegisterDependency(
                new CurrentWeekKeyTappedHandler(w));
            w.RegisterDependency(
                new PreviousWeekKeyTappedHandler(w));
            w.RegisterDependency(
                new NextWeekKeyTappedHandler(w));
            w.RegisterDependency(
                new DateChangedHandler(w));
            w.RegisterDependency(
                new TimerHandler(w));
        }

        protected readonly StatisticsUi ui;
        protected readonly ShellUi shell;
        protected readonly MethodWeb web;
    }
}
