using xofz.TimeKeeper98.UI;

namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.UI;

    public class PreviousWeekKeyTappedHandler
    {
        public PreviousWeekKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<UiReaderWriter>(rw =>
            {
                var currentStart = rw.Read(
                    ui,
                    () => ui.StartDate);
                var currentEnd = rw.Read(
                    ui,
                    () => ui.EndDate);
                var newStart = currentStart.AddDays(-7);
                var newEnd = currentEnd.AddDays(-7);

                rw.Write(ui, () =>
                {
                    ui.StartDate = newStart;
                    ui.EndDate = newEnd;
                });
            });
        }

        protected readonly MethodWeb web;
    }
}
