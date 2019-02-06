namespace xofz.TimeKeeper98.Framework
{
    public interface NavLogicReader
    {
        void ReadStatistics(
            out Do presentStatistics);

        void ReadTimestamps(
            out Do presentTimestamps);

        void ReadDaily(
            out Do presentDaily);

        void ReadExit(
            out Do exit);
    }
}
