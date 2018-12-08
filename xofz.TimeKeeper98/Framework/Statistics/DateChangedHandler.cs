namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class DateChangedHandler
    {
        public DateChangedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<TimerHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodWeb web;
    }
}
