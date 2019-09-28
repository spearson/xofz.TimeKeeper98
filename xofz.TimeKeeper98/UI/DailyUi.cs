namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface DailyUi 
        : Ui
    {
        event Do CurrentKeyTapped;

        event Do StatisticsRangeKeyTapped;

        Lot<string> Info { get; set; }
    }
}
