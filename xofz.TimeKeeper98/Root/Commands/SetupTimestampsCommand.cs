﻿namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupTimestampsCommand 
        : Command
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
            w?.RegisterDependency(
                new EnumerableSplitter());
            w?.RegisterDependency(
                new EnumerableSplicer());
            w?.RegisterDependency(
                new SetupHandler(w));
            w?.RegisterDependency(
                new StartHandler(w));
            w?.RegisterDependency(
                new SettingsHolder());
            w?.RegisterDependency(
                new HomeUiInKeyTappedHandler(w));
            w?.RegisterDependency(
                new HomeUiOutKeyTappedHandler(w));
            w?.RegisterDependency(
                new CurrentKeyTappedHandler(w));
            w?.RegisterDependency(
                new StatisticsRangeKeyTappedHandler(w));
            w?.RegisterDependency(
                new ShowDurationsChangedHandler(w));
        }

        protected readonly TimestampsUi ui;
        protected readonly ShellUi shell;
        protected readonly MethodWeb web;
    }
}
