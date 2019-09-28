namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface HomeNavUi 
        : Ui
    {
        event Do StatisticsKeyTapped;

        event Do TimestampsKeyTapped;

        event Do DailyKeyTapped;

        event Do ConfigKeyTapped;

        event Do ExitKeyTapped;

        string ActiveKeyLabel { get; set; }
    }
}
