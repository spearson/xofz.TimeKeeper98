namespace xofz.TimeKeeper98.Root.Commands
{
    using System;
    using System.Reflection;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.DataWatchers;
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

            new FileDataWatcher(
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
                new FileTimestampManager(
                    w));
            w.RegisterDependency(
                new FieldHolder());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                TimerNames.Home);
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

        protected readonly HomeUi ui;
        protected readonly HomeNavUi navUi;
        protected readonly ShellUi mainShell;
        protected readonly ShellUi navShell;
        protected readonly MethodWeb web;
    }
}
