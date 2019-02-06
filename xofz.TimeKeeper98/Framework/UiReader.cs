namespace xofz.TimeKeeper98.Framework
{
    using xofz.TimeKeeper98.UI;

    public interface UiReader
    {
        void ReadHomeNav(out HomeNavUi ui);

        void ReadStatistics(out StatisticsUi ui);
    }
}
