namespace xofz.TimeKeeper98.Framework.Statistics
{
    using System;
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class NextWeekKeyTappedHandler
    {
        public NextWeekKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r?.Run<UiReaderWriter>(uiRW =>
            {
                var currentStart = uiRW.Read(
                    ui,
                    () => ui.StartDate);
                var currentEnd = uiRW.Read(
                    ui,
                    () => ui.EndDate);
                r.Run<SettingsHolder>(settings =>
                {
                    var weekLength = settings.WeekLength;
                    var newStart = currentStart.Add(weekLength);
                    var newEnd = currentEnd.Add(weekLength);

                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.StartDate = newStart;
                            ui.EndDate = newEnd;
                        });
                });
            });
        }

        protected readonly MethodRunner runner;
    }
}
