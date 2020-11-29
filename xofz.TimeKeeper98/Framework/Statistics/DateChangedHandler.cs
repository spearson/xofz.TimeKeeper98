namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class DateChangedHandler
    {
        public DateChangedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r?.Run<TimerHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodRunner runner;
    }
}
