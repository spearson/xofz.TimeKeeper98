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

    public class CurrentWeekKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new CurrentWeekKeyTappedHandler(
                    this.web);
                this.calc = A.Fake<DateCalculator>();
                this.uiRW = new UiReaderWriter();
                this.ui = A.Fake<StatisticsUi>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.calc);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly CurrentWeekKeyTappedHandler handler;
            protected readonly DateCalculator calc;
            protected readonly UiReaderWriter uiRW;
            protected readonly StatisticsUi ui;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_calc_StartOfWeek()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.StartOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_calc_Friday()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.Friday())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_StartDate_to_StartOfWeek()
            {
                var start = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.calc.StartOfWeek())
                    .Returns(start);
                this.ui.StartDate = DateTime.MaxValue;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    start,
                    this.ui.StartDate);
            }

            [Fact]
            public void Sets_ui_EndDate_to_Friday()
            {
                var end = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.calc.Friday())
                    .Returns(end);
                this.ui.EndDate = DateTime.MinValue;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    end,
                    this.ui.EndDate);
            }
        }
    }
}
