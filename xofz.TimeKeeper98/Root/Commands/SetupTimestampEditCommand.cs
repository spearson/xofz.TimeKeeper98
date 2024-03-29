﻿namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;

    public class SetupTimestampEditCommand 
        : Command
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
            this.registerDependencies();

            new TimestampEditPresenter(
                    this.ui,
                    this.shell,
                    this.web)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w?.RegisterDependency(
                new SettingsHolder());
            w?.RegisterDependency(
                new SetupHandler(w));
            w?.RegisterDependency(
                new StartHandler(w));
            w?.RegisterDependency(
                new StopHandler(w));
            w?.RegisterDependency(
                new SaveKeyTappedHandler(w));
            w?.RegisterDependency(
                new CancelKeyTappedHandler(w));
            w?.RegisterDependency(
                new SaveCurrentKeyTappedHandler(w));
        }

        protected readonly TimestampEditUi ui;
        protected readonly ShellUi shell;
        protected readonly MethodWeb web;
    }
}
