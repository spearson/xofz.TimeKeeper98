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
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            DailyUi ui)
        {
            var w = this.web;
            var reader = w.Run<UiReader>();
            w.Run<UiReaderWriter>(uiRW =>
            {
                reader.ReadHomeNav(out var homeNavUi);
                uiRW.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = NavKeyLabels.Daily;
                    });
            });
            var showCurrent = true;
            w.Run<SettingsHolder>(settings =>
            {
                showCurrent = settings.ShowCurrent;
            });

            reader.ReadStatistics(out var statsUi);
            var ll = new LinkedListLot<string>();
            w.Run<
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
                        + " ---- "
                        + viewer.ReadableString(
                            statsCalc.TimeWorked(
                                today,
                                tomorrow)));
                    currentDay = currentDay.AddDays(1);
                }
            });

            w.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    ui,
                    () => ui.Info = ll);
            });
        }

        protected readonly MethodWeb web;
    }
}
