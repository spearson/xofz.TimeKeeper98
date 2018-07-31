namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.UI;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;

    public class SetupTimestampEditCommand : Command
    {
        public SetupTimestampEditCommand(
            TimestampEditUi ui,
            ShellUi shell,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.web = web;
        }

        public override void Execute()
        {
            new TimestampEditPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        private readonly TimestampEditUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
