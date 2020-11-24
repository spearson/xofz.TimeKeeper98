namespace xofz.TimeKeeper98.Tests.Framework.Daily
{
    using System;
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Daily;
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
                this.ui = A.Fake<DailyUi>();
                this.uiRW = new UiReaderWriter();
                this.reader = A.Fake<UiReader>();
                this.settings = new SettingsHolder();
                this.statsCalc = A.Fake<StatisticsCalculator>();
                this.dateCalc = A.Fake<DateCalculator>();
                this.viewer = A.Fake<TimeSpanViewer>();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.reader);
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.statsCalc);
                w.RegisterDependency(
                    this.dateCalc);
                w.RegisterDependency(
                    this.viewer);
            }

            protected readonly MethodWeb web;
            protected readonly StartHandler handler;
            protected readonly DailyUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly UiReader reader;
            protected readonly SettingsHolder settings;
            protected readonly StatisticsCalculator statsCalc;
            protected readonly DateCalculator dateCalc;
            protected readonly TimeSpanViewer viewer;
        }

        public class When_Handle_is_called : Context
        {
            public When_Handle_is_called()
            {
                this.statsUi = A.Fake<StatisticsUi>();
                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out this.statsUi))
                    .AssignsOutAndRefParameters(
                        this.statsUi);
            }

            [Fact]
            public void Calls_reader_ReadHomeNav()
            {
                HomeNavUi homeNavUi;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.reader.ReadHomeNav(
                        out homeNavUi))
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_homeNavUi_ActiveKeyLabel_to_NavKeyLabels_Daily()
            {
                var homeNavUi = A.Fake<HomeNavUi>();
                homeNavUi.ActiveKeyLabel = null;
                A
                    .CallTo(() => this.reader.ReadHomeNav(
                        out homeNavUi))
                    .AssignsOutAndRefParameters(
                        homeNavUi);

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    NavKeyLabels.Daily,
                    homeNavUi.ActiveKeyLabel);

            }

            [Fact]
            public void Calls_uiReader_ReadStatistics()
            {
                StatisticsUi statsUi;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out statsUi))
                    .MustHaveHappened();
            }

            [Fact]
            public void If_show_current_accesses_dateCalc_StartOfWeek()
            {
                this.settings.ShowCurrent = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.dateCalc.StartOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_show_current_accesses_dateCalc_EndOfWeek()
            {
                this.settings.ShowCurrent = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.dateCalc.EndOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_accesses_statsUi_StartDate()
            {
                this.settings.ShowCurrent = false;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.statsUi.StartDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_accesses_statsUi_EndDate()
            {
                this.settings.ShowCurrent = false;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.statsUi.EndDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_Info()
            {

                this.ui.Info = null;
                statsUi.StartDate = new DateTime(
                    2020,
                    8,
                    9);
                statsUi.EndDate = new DateTime(
                    2020,
                    8,
                    11);
                this.settings.ShowCurrent = false;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.Info);
                Assert.Equal(
                    3,
                    this.ui.Info.Count);
            }

            protected StatisticsUi statsUi;
        }
    }
}
