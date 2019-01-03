namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class NextWeekKeyTappedHandler
    {
        public NextWeekKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<UiReaderWriter>(uiRW =>
            {
                var currentStart = uiRW.Read(
                    ui,
                    () => ui.StartDate);
                var currentEnd = uiRW.Read(
                    ui,
                    () => ui.EndDate);
                var newStart = currentStart.AddDays(7);
                var newEnd = currentEnd.AddDays(7);

                uiRW.Write(ui, () =>
                {
                    ui.StartDate = newStart;
                    ui.EndDate = newEnd;
                });
            });
        }

        protected readonly MethodWeb web;
    }
}
