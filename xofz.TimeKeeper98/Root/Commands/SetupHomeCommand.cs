namespace xofz.TimeKeeper98.Root.Commands
{
    using System;
    using System.Reflection;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHomeCommand : Command
    {
        public SetupHomeCommand(
            HomeUi ui,
            HomeNavUi navUi,
            ShellUi mainShell,
            ShellUi navShell,
            MethodWeb web)
        {
            this.ui = ui;
            this.navUi = navUi;
            this.mainShell = mainShell;
            this.navShell = navShell;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();

            var w = this.web;
            new HomeNavPresenter(
                    this.navUi,
                    this.navShell,
                    w)
                .Setup();

            new HomePresenter(
                    this.ui,
                    this.mainShell,
                    w)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new DateCalculator());
            w.RegisterDependency(
                new EnumerableTrapper<DateTime>());
            w.RegisterDependency(
                new TimestampManager(
                    w));
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "HomeTimer");
            w.RegisterDependency(
                new TimeSpanViewer());
            w.RegisterDependency(
                new StatisticsCalculator(w));
            w.RegisterDependency(
                new VersionReader(
                    Assembly.GetExecutingAssembly()));
            w.RegisterDependency(
                new InKeyTappedHandler(w));
            w.RegisterDependency(
                new OutKeyTappedHandler(w));
            w.RegisterDependency(
                new TimerHandler(w));
            w.RegisterDependency(
                new StartHandler(w));
            w.RegisterDependency(
                new SetupHandler(w));
        }

        private readonly HomeUi ui;
        private readonly HomeNavUi navUi;
        private readonly ShellUi mainShell;
        private readonly ShellUi navShell;
        private readonly MethodWeb web;
    }
}
