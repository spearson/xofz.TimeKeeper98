namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface HomeUi : ShellUi
    {
        event Do InKeyTapped;

        event Do OutKeyTapped;

        event Do EditKeyTapped;

        bool InKeyVisible { get; set; }

        bool OutKeyVisible { get; set; }

        bool EditKeyEnabled { get; set; }

        string TimeWorkedThisWeek { get; set; }

        string TimeWorkedToday { get; set; }

        string Version { get; set; }

        string CoreVersion { get; set; }
    }
}
