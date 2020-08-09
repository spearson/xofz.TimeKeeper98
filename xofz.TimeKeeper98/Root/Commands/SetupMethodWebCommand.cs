namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Lotters;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;
    using xofz.Framework.Logging.Logs;

    public class SetupMethodWebCommand 
        : Command
    {
        public SetupMethodWebCommand(
            MethodWebV2 web,
            Messenger messenger,
            Gen<MethodRunner, ConfigSaver> newConfigSaver,
            Gen<MethodRunner, SettingsProvider> newSettingsProvider)
        {
            this.web = web;
            this.messenger = messenger;
            this.newConfigSaver = newConfigSaver;
            this.newSettingsProvider = newSettingsProvider;
        }

        public virtual MethodWebV2 W => this.web;

        public override void Execute()
        {
            this.registerDependencies();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new UiReaderWriter());
            w.RegisterDependency(
                new NavigatorV2(w));
            w.RegisterDependency(
                this.messenger);
            w.RegisterDependency(
                new EventRaiser());
            w.RegisterDependency(
                new LinkedListLotter());
            w.RegisterDependency(
                new EventSubscriber());
            w.RegisterDependency(
                this.newSettingsProvider?.Invoke(w));
            w.Run<SettingsProvider>(provider =>
            {
                w.RegisterDependency(
                    provider.Provide());
            });
            w.RegisterDependency(
                this.newConfigSaver?.Invoke(w));
            var exceptionsLogName = LogNames.Exceptions;
            w.RegisterDependency(
                new TextFileLog(exceptionsLogName + @".log"),
                exceptionsLogName);
            w.RegisterDependency(
                new TimeProvider());
        }

        protected readonly MethodWebV2 web;
        protected readonly Messenger messenger;
        protected readonly Gen<MethodRunner, ConfigSaver> newConfigSaver;
        protected readonly Gen<MethodRunner, SettingsProvider> newSettingsProvider;
    }
}
