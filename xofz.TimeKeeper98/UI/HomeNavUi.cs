namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface HomeNavUi : Ui
    {
        event Action StatisticsKeyTapped;

        event Action TimestampsKeyTapped;

        event Action ExitKeyTapped;

        string ActiveKeyLabel { get; set; }
    }
}
