namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface HomeUi : ShellUi
    {
        event Action InKeyTapped;

        event Action OutKeyTapped;

        bool InKeyVisible { get; set; }

        bool OutKeyVisible { get; set; }

        string TimeWorkedThisWeek { get; set; }

        string TimeWorkedToday { get; set; }

        string WelcomeMessage { get; set; }

        string Version { get; set; }

        string CoreVersion { get; set; }
    }
}
