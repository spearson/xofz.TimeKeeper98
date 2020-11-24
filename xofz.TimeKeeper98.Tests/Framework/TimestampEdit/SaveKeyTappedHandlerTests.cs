namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.Tests.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;
    using Xunit.Sdk;

    public class SaveKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SaveKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<TimestampEditUi>();
                this.fixture = new Fixture();
                this.uiRW = new UiReaderWriter();
                this.globalSettings = new GlobalSettingsHolder();
                this.messenger = A.Fake<Messenger>();
                this.reader = A.Fake<TimestampReader>();
                this.provider = A.Fake<TimeProvider>();
                this.watcher = A.Fake<DataWatcher>();
                this.writer = A.Fake<TimestampWriter>();
                this.settings = new SettingsHolder();
                this.navReader = A.Fake<NavLogicReader>();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.globalSettings);
                w.RegisterDependency(
                    this.messenger);
                w.RegisterDependency(
                    this.reader);
                w.RegisterDependency(
                    this.provider);
                w.RegisterDependency(
                    this.watcher);
                w.RegisterDependency(
                    this.writer);
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.navReader);

                A
                    .CallTo(() => this.messenger.Question(
                        A<string>.Ignored))
                    .Returns(Response.Yes);
            }

            protected readonly MethodWeb web;
            protected readonly SaveKeyTappedHandler handler;
            protected readonly TimestampEditUi ui;
            protected readonly Fixture fixture;
            protected readonly UiReaderWriter uiRW;
            protected readonly GlobalSettingsHolder globalSettings;
            protected readonly Messenger messenger;
            protected readonly TimestampReader reader;
            protected readonly TimeProvider provider;
            protected readonly DataWatcher watcher;
            protected readonly TimestampWriter writer;
            protected readonly SettingsHolder settings;
            protected readonly NavLogicReader navReader;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void If_Prompt_asks_question()
            {
                this.globalSettings.Prompt = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.messenger.Question(
                        A<string>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_ui_EditedTimestamp()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.EditedTimestamp)
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_reader_ReadAll()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.reader.ReadAll())
                    .MustHaveHappened();
            }

            [Fact]
            public void
                If_new_timestamp_before_penultimate_errors_with_too_early()
            {
                var penultimate = this.fixture.Create<DateTime>();
                var ultimate = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(new[] {penultimate, ultimate});
                this.ui.EditedTimestamp = penultimate.AddDays(-1);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.messenger.GiveError(
                        ErrorMessages.TooEarly))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_provider_Now()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.provider.Now())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_new_timestamp_after_now_gives_error_message()
            {
                var now = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.provider.Now())
                    .Returns(now);
                this.ui.EditedTimestamp = now.Add(TimeSpan.FromMilliseconds(1));

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.messenger.GiveError(
                        ErrorMessages.TooLate))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_watcher_Stop()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.watcher.Stop())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_writer_EditLastTimestamp()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.writer.EditLastTimestamp(
                        this.ui.EditedTimestamp))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_watcher_Start()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.watcher.Start())
                    .MustHaveHappened();
            }

            [Fact]
            public void
                If_last_visited_was_Timestamps_calls_navReader_ReadTimestamps()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Timestamps;

                this.handler.Handle(
                    this.ui);

                Do present;
                A
                    .CallTo(() => this.navReader.ReadTimestamps(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToTimestamps()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Timestamps;
                var navToTimestamps = A.Fake<Do>();
                A
                    .CallTo(() => this.navReader.ReadTimestamps(
                        out navToTimestamps))
                    .AssignsOutAndRefParameters(navToTimestamps);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => navToTimestamps.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void
                If_last_visited_was_Statistics_calls_navReader_ReadStatistics()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Statistics;

                this.handler.Handle(
                    this.ui);

                Do navToStats;
                A
                    .CallTo(() => this.navReader.ReadStatistics(
                        out navToStats))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToStats()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Statistics;
                var navToStats = A.Fake<Do>();
                A
                    .CallTo(() => this.navReader.ReadStatistics(
                        out navToStats))
                    .AssignsOutAndRefParameters(navToStats);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => navToStats.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_last_visited_was_Daily_calls_navReader_ReadDaily()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Daily;

                this.handler.Handle(
                    this.ui);

                Do present;
                A
                    .CallTo(() => this.navReader.ReadDaily(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToDaily()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Daily;
                var navToDaily = A.Fake<Do>();
                A
                    .CallTo(() => this.navReader.ReadDaily(
                        out navToDaily))
                    .AssignsOutAndRefParameters(navToDaily);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => navToDaily.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_last_visited_was_Config_calls_navReader_ReadConfig()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Config;

                this.handler.Handle(
                    this.ui);

                Do present;
                A
                    .CallTo(() => this.navReader.ReadConfig(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_navToConfig()
            {
                this.settings.LastVisitedKeyLabel = NavKeyLabels.Config;
                var navToConfig = A.Fake<Do>();
                A
                    .CallTo(() => this.navReader.ReadConfig(
                        out navToConfig))
                    .AssignsOutAndRefParameters(navToConfig);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => navToConfig.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_calls_navReader_ReadTimestamps()
            {
                this.settings.LastVisitedKeyLabel = this.fixture.Create<string>();

                this.handler.Handle(
                    this.ui);

                Do present;
                A
                    .CallTo(() => this.navReader.ReadTimestamps(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_invokes_defaultNav()
            {
                this.settings.LastVisitedKeyLabel = this.fixture.Create<string>();
                var defaultNav = A.Fake<Do>();
                A
                    .CallTo(() => this.navReader.ReadTimestamps(
                        out defaultNav))
                    .AssignsOutAndRefParameters(defaultNav);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => defaultNav.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
