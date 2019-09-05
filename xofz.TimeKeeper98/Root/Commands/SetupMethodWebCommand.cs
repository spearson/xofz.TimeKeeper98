namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Lotters;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;
    using xofz.Framework.Logging.Logs;

    public class SetupMethodWebCommand : Command
    {
        public SetupMethodWebCommand(
            MethodWeb web,
            Navigator navigator,
            Messenger messenger,
            ConfigSaver configSaver,
            SettingsProvider settingsProvider)
        {
            this.web = web;
            this.navigator = navigator;
            this.messenger = messenger;
            this.configSaver = configSaver;
            this.settingsProvider = settingsProvider;
        }

        public virtual MethodWeb W => this.web;

        public override void Execute()
        {
            this.registerDependencies();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            var sp = this.settingsProvider;
            w.RegisterDependency(
                new UiReaderWriter());
            w.RegisterDependency(
                this.navigator);
            w.RegisterDependency(
                this.messenger);
            w.RegisterDependency(
                new EventRaiser());
            w.RegisterDependency(
                new LinkedListLotter());
            w.RegisterDependency(
                new EventSubscriber());
            w.RegisterDependency(
                sp);
            w.RegisterDependency(
                sp.Provide());
            w.RegisterDependency(
                this.configSaver);
            w.RegisterDependency(
                new TextFileLog(@"Exceptions.log"),
                LogNames.Exceptions);
        }

        protected readonly MethodWeb web;
        protected readonly Navigator navigator;
        protected readonly Messenger messenger;
        protected readonly ConfigSaver configSaver;
        protected readonly SettingsProvider settingsProvider;
    }
}
