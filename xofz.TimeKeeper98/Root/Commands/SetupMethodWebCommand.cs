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
            Messenger messenger)
        {
            this.createWeb = createWeb;
            this.messenger = messenger;
        }

        public virtual MethodWeb Web => this.web;

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
                new GlobalSettingsHolder
                {
                    TimestampFormat = "MM/dd hh:mm:ss tt"
                });
            w.RegisterDependency(
                new TextFileLog("Exceptions.log"),
                "Exceptions");
        }

        protected MethodWeb web;
        protected readonly Gen<MethodWeb> createWeb;
        protected readonly Messenger messenger;
    }
}
