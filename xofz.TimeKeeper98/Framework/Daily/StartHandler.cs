namespace xofz.TimeKeeper98.Framework.Daily
{
    using System;
    using xofz.Framework;
    using xofz.Framework.Lots;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            DailyUi ui)
        {
            var r = this.runner;
            r?.Run<UiReaderWriter, UiReader>(
                (uiRW, reader) =>
            {
                reader.ReadHomeNav(
                    out var homeNavUi);
                uiRW.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = NavKeyLabels.Daily;
                    });
            });

            var showCurrent = true;
            r?.Run<SettingsHolder>(settings =>
            {
                showCurrent = settings.ShowCurrent;
            });

            StatisticsUi statsUi = null;
            r?.Run<UiReader>(reader =>
            {
                reader.ReadStatistics(
                    out var statisticsUi);
                statsUi = statisticsUi;
            });

            var ll = new LinkedListLot<string>();
            r?.Run<
                StatisticsCalculator, 
                DateCalculator,
                UiReaderWriter,
                TimeSpanViewer>(
                (statsCalc, dateCalc, uiRW, viewer) =>
            {
                DateTime currentDay, start, end;
                if (showCurrent)
                {
                    start = dateCalc.StartOfWeek();
                    end = dateCalc.EndOfWeek();
                    goto afterComputeRange;
                }

                start = uiRW.Read(
                    statsUi,
                    () => statsUi.StartDate);
                end = uiRW.Read(
                    statsUi,
                    () => statsUi.EndDate);

                afterComputeRange:
                currentDay = start;
                while (currentDay <= end)
                {
                    var today = currentDay.Date;
                    var tomorrow = today.AddDays(1);
                    ll.AddLast(
                        currentDay.Date.ToString(
                            @"yyyy/MM/dd ddd")
                        + @" ---- "
                        + viewer.ReadableString(
                            statsCalc.TimeWorked(
                                today,
                                tomorrow)));
                    currentDay = currentDay.AddDays(1);
                }
            });

            r?.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.Info = ll;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
