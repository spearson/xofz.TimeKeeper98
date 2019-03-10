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
            w.Run<LatchHolder>(timerLatch =>
                {
                    timerLatch.Latch.Reset();
                },
                DependencyNames.Latch);
            w.Run<
                UiReaderWriter,
                StatisticsCalculator,
                PaddedTimeSpanViewer,
                TimestampReader>(
            (uiRW, calc, viewer, reader) =>
            {
                var timeThisWeek = calc.TimeWorkedThisWeek();
                var timeToday = calc.TimeWorkedToday();
                var thisWeekString = viewer.ReadableString(timeThisWeek);
                var todayString = viewer.ReadableString(timeToday);
                var outKeyVisible = calc.ClockedIn();
                var editKeyEnabled = false;
                foreach (var timestamp in reader.Read())
                {
                    editKeyEnabled = true;
                    break;
                }

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.EditKeyEnabled = editKeyEnabled;
                        ui.TimeWorkedThisWeek = thisWeekString;
                        ui.TimeWorkedToday = todayString;
                        ui.InKeyVisible = !outKeyVisible;
                        ui.OutKeyVisible = outKeyVisible;
                    });
            });

            w.Run<LatchHolder>(timerLatch =>
                {
                    timerLatch.Latch.Set();
                },
                DependencyNames.Latch);
        }

        protected readonly MethodWeb web;
    }
}
