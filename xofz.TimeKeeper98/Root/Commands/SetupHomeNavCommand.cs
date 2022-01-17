namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHomeNavCommand 
        : Command
    {
        public SetupHomeNavCommand(
            HomeNavUi ui,
            ShellUi shell,
            NavLogicReader navReader,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.navReader = navReader;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new HomeNavPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w?.RegisterDependency(
                this.navReader);
            w?.RegisterDependency(
                new TimestampsKeyTappedHandler(w));
            w?.RegisterDependency(
                new StatisticsKeyTappedHandler(w));
            w?.RegisterDependency(
                new DailyKeyTappedHandler(w));
            w?.RegisterDependency(
                new ConfigKeyTappedHandler(w));
            w?.RegisterDependency(
                new ExitKeyTappedHandler(w));
        }

        protected readonly HomeNavUi ui;
        protected readonly ShellUi shell;
        protected readonly NavLogicReader navReader;
        protected readonly MethodWeb web;
    }
}
