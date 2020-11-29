namespace xofz.TimeKeeper98.Framework.Daily
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class CurrentKeyTappedHandler
    {
        public CurrentKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            DailyUi ui)
        {
            var r = this.runner;
            r?.Run<SettingsHolder>(settings =>
            {
                settings.ShowCurrent = true;
            });

            r?.Run<StartHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodRunner runner;
    }
}
