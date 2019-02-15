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

        void ReadLicense(
            out Do presentLicense);

        void ReadExit(
            out Do exit);
    }
}
