namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Daily;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupDailyCommand : Command
    {
        public SetupDailyCommand(
            DailyUi ui,
            ShellUi shell,
            UiReader uiReader,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.uiReader = uiReader;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new DailyPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                this.uiReader);
            w.RegisterDependency(
                new SettingsHolder());
            w.RegisterDependency(
                new SetupHandler(w));
            w.RegisterDependency(
                new StartHandler(w));
            w.RegisterDependency(
                new CurrentKeyTappedHandler(w));
            w.RegisterDependency(
                new StatisticsRangeKeyTappedHandler(w));
            w.RegisterDependency(
                new HomeUiOutKeyTappedHandler(w));
        }

        protected readonly DailyUi ui;
        protected readonly ShellUi shell;
        protected readonly UiReader uiReader;
        protected readonly MethodWeb web;
    }
}
