namespace xofz.TimeKeeper98.Root.Commands
{
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.UI;

    public class SetupMethodWebCommand : Command
    {
        public SetupMethodWebCommand(
            Messenger messenger)
        {
            this.messenger = messenger;
        }

        public virtual MethodWeb Web => this.web;

        public override void Execute()
        {
            this.setWeb(new MethodWeb());
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
                new LinkedListMaterializer());
            w.RegisterDependency(
                new EventSubscriber());
        }

        private MethodWeb web;
        private readonly Messenger messenger;
    }
}
