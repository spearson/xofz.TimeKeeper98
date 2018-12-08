namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class TimerHandler
    {
        public TimerHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<
                UiReaderWriter,
                StatisticsCalculator,
                TimeSpanViewer>(
                (rw, calc, viewer) =>
                {
                    var start = rw.Read(
                        ui,
                        () => ui.StartDate);
                    var end = rw.Read(
                        ui,
                        () => ui.EndDate).AddDays(1);

                    var timeWorked = viewer.ReadableString(
                        calc.TimeWorked(start, end));
                    var avgDaily = viewer.ReadableString(
                        calc.AverageDailyTimeWorked(start, end));
                    var minDaily = viewer.ReadableString(
                        calc.MinDailyTimeWorked(start, end));
                    var maxDaily = viewer.ReadableString(
                        calc.MaxDailyTimeWorked(start, end));

                    rw.Write(
                        ui,
                        () =>
                        {
                            ui.TimeWorked = timeWorked;
                            ui.AvgDailyTimeWorked = avgDaily;
                            ui.MinDailyTimeWorked = minDaily;
                            ui.MaxDailyTimeWorked = maxDaily;
                        });
                });
        }
        protected readonly MethodWeb web;
    }
}
