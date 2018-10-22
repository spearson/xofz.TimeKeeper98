namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Lotters;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;

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

        private void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        private void registerDependencies()
        {
            var w = this.web;
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
                new GlobalSettingsHolder()
                {
                    TimestampFormat = "MM/dd hh:mm:ss tt"
                });
        }

        private MethodWeb web;
        private readonly Gen<MethodWeb> createWeb;
        private readonly Messenger messenger;
    }
}
