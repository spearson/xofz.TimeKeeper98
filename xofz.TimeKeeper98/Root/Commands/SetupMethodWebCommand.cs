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
            Gen<MethodWeb> createWeb,
            Messenger messenger,
            SettingsProvider settingsProvider)
        {
            this.createWeb = createWeb;
            this.messenger = messenger;
            this.settingsProvider = settingsProvider;
        }

        public virtual MethodWeb W => this.web;

        public override void Execute()
        {
            this.setWeb(this.createWeb());

            this.registerDependencies();
        }

        protected virtual void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            var sp = this.settingsProvider;
            w.RegisterDependency(
                new UiReaderWriter());
            w.RegisterDependency(
                this.messenger);
            w.RegisterDependency(
                new Navigator(w));
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
                new TextFileLog("Exceptions.log"),
                LogNames.Exceptions);
        }

        protected MethodWeb web;
        protected readonly Gen<MethodWeb> createWeb;
        protected readonly Messenger messenger;
        protected readonly SettingsProvider settingsProvider;
    }
}
