namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class PreviousWeekKeyTappedHandler
    {
        public PreviousWeekKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                var currentStart = uiRW.Read(
                    ui,
                    () => ui.StartDate);
                var currentEnd = uiRW.Read(
                    ui,
                    () => ui.EndDate);
                var newStart = currentStart.AddDays(-7);
                var newEnd = currentEnd.AddDays(-7);

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.StartDate = newStart;
                        ui.EndDate = newEnd;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
