namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class StartHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StartHandler(
                    this.web);
                this.ui = A.Fake<ConfigUi>();
                this.uiReader = A.Fake<UiReader>();
                this.uiRW = new UiReaderWriter();
                this.stampReader = A.Fake<TimestampReader>();
                this.dateCalc = A.Fake<DateCalculator>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiReader);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.stampReader);
                w.RegisterDependency(
                    this.dateCalc);
            }

            protected readonly MethodWeb web;
            protected readonly StartHandler handler;
            protected readonly ConfigUi ui;
            protected readonly UiReader uiReader;
            protected readonly UiReaderWriter uiRW;
            protected readonly TimestampReader stampReader;
            protected readonly DateCalculator dateCalc;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            public When_Handle_is_called()
            {
                this.ts1 = new DateTime(
                    1999,
                    12,
                    31);
                this.ts2 = new DateTime(
                    2020,
                    4,
                    5);
                this.ts3 = new DateTime(
                    2020,
                    7,
                    7);
                A
                    .CallTo(() => this.stampReader.ReadAll())
                    .Returns(new[]
                    {
                        ts1, ts2, ts3
                    });
                this.statsUi = A.Fake<StatisticsUi>();
                this.statsUi.StartDate = new DateTime(
                    2020,
                    4,
                    5);
                this.statsUi.EndDate = new DateTime(
                    2020,
                    8,
                    8);
                A
                    .CallTo(() => this.dateCalc.StartOfWeek())
                    .Returns(new DateTime(
                        2020,
                        7,
                        5));
                A
                    .CallTo(() => this.dateCalc.EndOfWeek())
                    .Returns(new DateTime(
                        2020,
                        7,
                        8));

                A
                    .CallTo(() => this.uiReader.ReadStatistics(
                        out this.statsUi))
                    .AssignsOutAndRefParameters(statsUi);
            }

            [Fact]
            public void Calls_reader_ReadHomeNav()
            {
                HomeNavUi hnUi;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.uiReader.ReadHomeNav(
                        out hnUi))
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_homeNavUi_ActiveKeyLabel_to_Config()
            {
                var homeNavUi = A.Fake<HomeNavUi>();
                A
                    .CallTo(() => this.uiReader.ReadHomeNav(
                        out homeNavUi))
                    .AssignsOutAndRefParameters(homeNavUi);
                homeNavUi.ActiveKeyLabel = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    NavKeyLabels.Config,
                    homeNavUi.ActiveKeyLabel);
            }

            [Fact]
            public void Calls_stampReader_ReadAll()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.stampReader.ReadAll())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_uiReader_ReadStatistics()
            {
                StatisticsUi statsUi;
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.uiReader.ReadStatistics(
                        out statsUi))
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_statsUi_StartDate()
            {
                this.statsUi.StartDate = this.fixture.Create<DateTime>();

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => statsUi.StartDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_statsUi_EndDate()
            {
                statsUi.EndDate = this.fixture.Create<DateTime>();

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => statsUi.EndDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_dateCalc_StartOfWeek()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.dateCalc.StartOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_dateCalc_EndOfWeek()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.dateCalc.EndOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_TotalTimestampCount()
            {
                this.ui.TotalTimestampCount = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    3.ToString(),
                    this.ui.TotalTimestampCount);
            }

            [Fact]
            public void Sets_ui_ThisWeekTimestampCount()
            {
                this.ui.ThisWeekTimestampCount = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    1.ToString(),
                    this.ui.ThisWeekTimestampCount);
            }

            [Fact]
            public void Sets_ui_InRangeTimestampCount()
            {
                this.ui.InRangeTimestampCount = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    2.ToString(),
                    this.ui.InRangeTimestampCount);
            }

            protected StatisticsUi statsUi;
            protected readonly DateTime ts1, ts2, ts3;
        }
    }
}
