namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class TimerHandler
    {
        public TimerHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r?.Run<
                UiReaderWriter,
                StatisticsCalculator,
                TimeSpanViewer>(
                (uiRW, calc, viewer) =>
                {
                    var start = uiRW.Read(
                        ui,
                        () => ui.StartDate);
                    var end = uiRW.Read(
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

                    uiRW.Write(
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

        protected readonly MethodRunner runner;
    }
}
