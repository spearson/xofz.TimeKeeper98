namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.UI;

    public class TimerHandler
    {
        public TimerHandler(MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            w.Run<
                UiReaderWriter,
                StatisticsCalculator,
                TimeSpanViewer>(
            (uiRW, calc, viewer) =>
            {
                var timeThisWeek = calc.TimeWorkedThisWeek();
                var timeToday = calc.TimeWorkedToday();
                var thisWeekString = viewer.ReadableString(timeThisWeek);
                var todayString = viewer.ReadableString(timeToday);
                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.TimeWorkedThisWeek = thisWeekString;
                        ui.TimeWorkedToday = todayString;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
