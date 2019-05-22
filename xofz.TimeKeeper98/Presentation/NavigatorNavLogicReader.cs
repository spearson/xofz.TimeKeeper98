namespace xofz.TimeKeeper98.Presentation
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;

    public sealed class NavigatorNavLogicReader
        : NavLogicReader
    {
        public NavigatorNavLogicReader(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        void NavLogicReader.ReadTimestamps(
            out Do presentTimestamps)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                presentTimestamps = null;
                return;
            }

            presentTimestamps = nav.Present<TimestampsPresenter>;
        }

        void NavLogicReader.ReadStatistics(
            out Do presentStatistics)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                presentStatistics = null;
                return;
            }

            presentStatistics = nav.Present<StatisticsPresenter>;
        }

        void NavLogicReader.ReadDaily(
            out Do presentDaily)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                presentDaily = null;
                return;
            }
            presentDaily = nav.Present<DailyPresenter>;
        }

        void NavLogicReader.ReadConfig(
            out Do presentConfig)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                presentConfig = null;
                return;
            }

            presentConfig = nav.Present<ConfigPresenter>;
        }

        void NavLogicReader.ReadLicense(
            out Do presentLicense)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                presentLicense = null;
                return;
            }

            presentLicense = nav.Present<LicensePresenter>;
        }

        void NavLogicReader.ReadExit(
            out Do exit)
        {
            var nav = this.runner.Run<Navigator>();
            if (nav == null)
            {
                exit = null;
                return;
            }

            exit = nav.Present<ShutdownPresenter>;
        }

        private readonly MethodRunner runner;
    }
}
