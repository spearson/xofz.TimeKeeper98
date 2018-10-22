namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface TimestampsUi : Ui
    {
        event Do CurrentKeyTapped;

        event Do StatisticsRangeKeyTapped;

        Lot<string> InTimes { get; set; }

        Lot<string> OutTimes { get; set; }

        void SetSplicedInOutTimes(Lot<string> inOutTimes);
    }
}
