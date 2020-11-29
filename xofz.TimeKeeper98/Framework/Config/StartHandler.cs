namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
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
            ConfigUi ui)
        {
            var r = this.runner;
            r?.Run<UiReader, UiReaderWriter>((reader, uiRW) =>
            {
                reader.ReadHomeNav(
                    out var homeNavUi);
                uiRW.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = NavKeyLabels.Config;
                    });
            });

            r?.Run<UiReaderWriter, TimestampReader, UiReader, DateCalculator>(
                (uiRW, reader, uiReader, dateCalc) =>
                {
                    var allTimestamps = reader.ReadAll();
                    uiReader.ReadStatistics(
                        out var statsUi);
                    var start = uiRW.Read(
                        statsUi,
                        () => statsUi.StartDate);
                    var end = uiRW.Read(
                            statsUi,
                            () => statsUi.EndDate)
                        .AddDays(1);
                    var startOfWeek = dateCalc.StartOfWeek();
                    var endOfWeek = dateCalc
                        .EndOfWeek()
                        .AddDays(1);
                    long countThisWeek = 0;
                    long countInRange = 0;
                    long totalCount = allTimestamps.Count;
                    foreach (var timestamp in allTimestamps)
                    {
                        if (timestamp >= start && timestamp < end)
                        {
                            ++countInRange;
                        }

                        if (timestamp >= startOfWeek && timestamp < endOfWeek)
                        {
                            ++countThisWeek;
                        }
                    }

                    var tcString = totalCount.ToString();
                    var weekString = countThisWeek.ToString();
                    var rangeString = countInRange.ToString();

                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TotalTimestampCount = tcString;
                            ui.ThisWeekTimestampCount = weekString;
                            ui.InRangeTimestampCount = rangeString;
                        });
                });
        }

        protected readonly MethodRunner runner;
    }
}
