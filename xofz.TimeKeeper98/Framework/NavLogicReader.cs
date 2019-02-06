namespace xofz.TimeKeeper98.Framework
{
    public interface NavLogicReader
    {
        void ReadTimestamps(
            out Do presentTimestamps);

        void ReadStatistics(
            out Do presentStatistics);

        void ReadDaily(
            out Do presentDaily);

        void ReadConfig(
            out Do presentConfig);

        void ReadExit(
            out Do exit);
    }
}
