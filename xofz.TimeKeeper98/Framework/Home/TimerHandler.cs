﻿namespace xofz.TimeKeeper98.Framework.Home
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
                TimeSpanViewer,
                TimestampReader>(
            (uiRW, calc, viewer, reader) =>
            {
                var timeThisWeek = calc.TimeWorkedThisWeek();
                var timeToday = calc.TimeWorkedToday();
                var thisWeekString = viewer.ReadableString(timeThisWeek);
                var todayString = viewer.ReadableString(timeToday);
                var inKeyVisible = !calc.ClockedIn();
                var editKeyEnabled = false;
                foreach (var timestamp in reader.Read())
                {
                    editKeyEnabled = true;
                }

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.EditKeyEnabled = editKeyEnabled;
                        ui.TimeWorkedThisWeek = thisWeekString;
                        ui.TimeWorkedToday = todayString;
                        ui.InKeyVisible = inKeyVisible;
                        ui.OutKeyVisible = !inKeyVisible;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
