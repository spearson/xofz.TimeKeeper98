namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class HomeUiInKeyTappedHandler
    {
        public HomeUiInKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var r = this.runner;
            r.Run<StartHandler>(handler =>
            {
                handler.Handle(
                    ui);
            });
        }

        protected readonly MethodRunner runner;
    }
}