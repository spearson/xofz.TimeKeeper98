namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface TimestampsUi : Ui
    {
        MaterializedEnumerable<string> InTimes { get; set; }

        MaterializedEnumerable<string> OutTimes { get; set; }

        void SetSplicedInOutTimes(MaterializedEnumerable<string> inOutTimes);
    }
}
