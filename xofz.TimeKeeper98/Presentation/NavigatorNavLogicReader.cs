namespace xofz.TimeKeeper98.Presentation
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;

    public sealed class NavigatorNavLogicReader
        : NavLogicReader
    {
        public NavigatorNavLogicReader(
            MethodWeb web)
        {
            this.web = web;
        }

        void NavLogicReader.ReadTimestamps(
            out Do presentTimestamps)
        {
            var nav = this.web.Run<Navigator>();
            presentTimestamps = nav.Present<TimestampsPresenter>;
        }

        void NavLogicReader.ReadStatistics(
            out Do presentStatistics)
        {
            var nav = this.web.Run<Navigator>();
            presentStatistics = nav.Present<StatisticsPresenter>;
        }

        void NavLogicReader.ReadDaily(
            out Do presentDaily)
        {
            var nav = this.web.Run<Navigator>();
            presentDaily = nav.Present<DailyPresenter>;
        }

        void NavLogicReader.ReadConfig(out Do presentConfig)
        {
            var nav = this.web.Run<Navigator>();
            presentConfig = nav.Present<ConfigPresenter>;
        }

        void NavLogicReader.ReadExit(
            out Do exit)
        {
            var nav = this.web.Run<Navigator>();
            exit = nav.Present<ShutdownPresenter>;
        }

        private readonly MethodWeb web;
    }
}
