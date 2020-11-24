namespace xofz.TimeKeeper98.Tests.Framework.Statistics
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class TimerHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new TimerHandler(
                    this.web);
                this.ui = A.Fake<StatisticsUi>();
                this.uiRW = new UiReaderWriter();
                this.calc = A.Fake<StatisticsCalculator>();
                this.viewer = A.Fake<TimeSpanViewer>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.calc);
                w.RegisterDependency(
                    this.viewer);
            }

            protected readonly MethodWeb web;
            protected readonly TimerHandler handler;
            protected readonly StatisticsUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly StatisticsCalculator calc;
            protected readonly TimeSpanViewer viewer;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            public When_Handle_is_called()
            {
                this.ui.StartDate = this.fixture.Create<DateTime>();
                this.ui.EndDate = this.fixture.Create<DateTime>();
            }

            [Fact]
            public void Calls_calc_TimeWorked()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.TimeWorked(
                        this.ui.StartDate,
                        this.ui.EndDate.AddDays(1)))
                    .MustHaveHappened();

            }

            [Fact]
            public void Calls_calc_AverageDailyTimeWorked()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.AverageDailyTimeWorked(
                        this.ui.StartDate,
                        this.ui.EndDate.AddDays(1)))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_calc_MinDailyTimeWorked()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.MinDailyTimeWorked(
                        this.ui.StartDate,
                        this.ui.EndDate.AddDays(1)))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_calc_MaxDailyTimeWorked()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.MaxDailyTimeWorked(
                        this.ui.StartDate,
                        this.ui.EndDate.AddDays(1)))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_viewer_ReadableString_for_calc_TimeWorked()
            {
                var time = this.fixture.Create<TimeSpan>();
                A
                    .CallTo(() => this.calc.TimeWorked(
                        A<DateTime>.Ignored,
                        A<DateTime>.Ignored))
                    .Returns(time);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        time))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                Calls_viewer_ReadableString_for_calc_AverageDailyTimeWorked()
            {
                var time = this.fixture.Create<TimeSpan>();
                A
                    .CallTo(() => this.calc.AverageDailyTimeWorked(
                        A<DateTime>.Ignored,
                        A<DateTime>.Ignored))
                    .Returns(time);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        time))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                Calls_viewer_ReadableString_for_calc_MinDailyTimeWorked()
            {
                var time = this.fixture.Create<TimeSpan>();
                A
                    .CallTo(() => this.calc.MinDailyTimeWorked(
                        A<DateTime>.Ignored,
                        A<DateTime>.Ignored))
                    .Returns(time);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        time))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                Calls_viewer_ReadableString_for_calc_MaxDailyTimeWorked()
            {
                var time = this.fixture.Create<TimeSpan>();
                A
                    .CallTo(() => this.calc.MaxDailyTimeWorked(
                        A<DateTime>.Ignored,
                        A<DateTime>.Ignored))
                    .Returns(time);

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        time))
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_TimeWorked()
            {
                this.ui.TimeWorked = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.TimeWorked);
            }

            [Fact]
            public void Sets_ui_AvgDailyTimeWorked()
            {
                this.ui.AvgDailyTimeWorked = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.AvgDailyTimeWorked);
            }

            [Fact]
            public void Sets_ui_MinDailyTimeWorked()
            {
                this.ui.MinDailyTimeWorked = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.MinDailyTimeWorked);
            }

            [Fact]
            public void Sets_ui_MaxDailyTimeWorked()
            {
                this.ui.MaxDailyTimeWorked = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.MaxDailyTimeWorked);
            }
        }
    }
}
