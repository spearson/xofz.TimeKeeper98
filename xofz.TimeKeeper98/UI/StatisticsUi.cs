namespace xofz.TimeKeeper98.UI
{
    using System;
    using xofz.UI;

    public interface StatisticsUi : Ui
    {
        event Action DateChanged;

        event Action PreviousWeekKeyTapped;

        event Action CurrentWeekKeyTapped;

        event Action NextWeekKeyTapped;

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        string TimeWorked { get; set; }

        string AvgDailyTimeWorked { get; set; }

        string MinDailyTimeWorked { get; set; }

        string MaxDailyTimeWorked { get; set; }
    }
}
