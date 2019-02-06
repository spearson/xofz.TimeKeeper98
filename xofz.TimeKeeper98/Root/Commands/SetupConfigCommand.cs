namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupConfigCommand : Command
    {
        public SetupConfigCommand(
            ConfigUi ui,
            ShellUi shell,
            ThreadSafeMethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new ConfigPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new SetupHandler(w));
            w.RegisterDependency(
                new StartHandler(w));
            w.RegisterDependency(
                new ShowSecondsSelectedHandler(w));
            w.RegisterDependency(
                new ShowSecondsUnselectedHandler(w));
            w.RegisterDependency(
                new PromptSelectedHandler(w));
            w.RegisterDependency(
                new PromptUnselectedHandler(w));
            w.RegisterDependency(
                new SaveTitleTextKeyTappedHandler(w));
            w.RegisterDependency(
                new ResetTitleTextKeyTappedHandler(w));
            w.RegisterDependency(
                new DefaultTitleTextKeyTappedHandler(w));
            w.RegisterDependency(
                new KeyboardLoader());
            w.RegisterDependency(
                new KeyboardKeyTappedHandler(w));
        }

        protected readonly ConfigUi ui;
        protected readonly ShellUi shell;
        protected readonly ThreadSafeMethodWeb web;
    }
}
