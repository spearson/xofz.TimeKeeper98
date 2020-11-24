namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class CancelKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new CancelKeyTappedHandler(
                    this.web);
                this.settings = new SettingsHolder();
                this.reader = A.Fake<NavLogicReader>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly CancelKeyTappedHandler handler;
            protected readonly SettingsHolder settings;
            protected readonly NavLogicReader reader;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void If_last_label_Timestamps_calls_reader_ReadTimestamps()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Timestamps;

                this.handler.Handle();

                Do present;
                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToTimestamps()
            {
                var navToTimestamps = A.Fake<Do>();
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Timestamps;
                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out navToTimestamps))
                    .AssignsOutAndRefParameters(navToTimestamps);

                this.handler.Handle();

                A
                    .CallTo(() => navToTimestamps.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_last_label_Statistics_calls_reader_ReadStatistics()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Statistics;

                this.handler.Handle();

                Do present;
                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToStats()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Statistics;
                var navToStats = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out navToStats))
                    .AssignsOutAndRefParameters(navToStats);

                this.handler.Handle();

                A
                    .CallTo(() => navToStats.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_last_label_Daily_calls_reader_ReadDaily()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Daily;
                
                this.handler.Handle();

                Do present;
                A
                    .CallTo(() => this.reader.ReadDaily(out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToDaily()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Daily;
                var navToDaily = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadDaily(
                        out navToDaily))
                    .AssignsOutAndRefParameters(navToDaily);

                this.handler.Handle();

                A
                    .CallTo(() => navToDaily.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_last_label_Config_calls_reader_ReadConfig()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Config;

                this.handler.Handle();

                Do present;
                A
                    .CallTo(() => this.reader.ReadConfig(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToConfig()
            {
                var navToConfig = A.Fake<Do>();
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Config;
                A
                    .CallTo(() => this.reader.ReadConfig(
                        out navToConfig))
                    .AssignsOutAndRefParameters(navToConfig);

                this.handler.Handle();

                A
                    .CallTo(() => navToConfig.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_calls_reader_ReadTimestamps()
            {
                this.settings.LastVisitedKeyLabel =
                    this.fixture.Create<string>();

                this.handler.Handle();

                Do present;
                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_defaultNav()
            {
                var defaultNav = A.Fake<Do>();
                this.settings.LastVisitedKeyLabel =
                    this.fixture.Create<string>();
                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out defaultNav))
                    .AssignsOutAndRefParameters(defaultNav);

                this.handler.Handle();

                A
                    .CallTo(() => defaultNav.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
