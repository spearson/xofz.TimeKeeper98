namespace xofz.TimeKeeper98.Tests.Framework.Statistics
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class PreviousWeekKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new PreviousWeekKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<StatisticsUi>();
                this.uiRW = new UiReaderWriter();
                this.fixture = new Fixture();
                this.settings = new SettingsHolder();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.settings);
            }

            protected readonly MethodWeb web;
            protected readonly PreviousWeekKeyTappedHandler handler;
            protected readonly StatisticsUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly SettingsHolder settings;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Reads_ui_StartDate()
            {
                this.ui.StartDate = this.fixture.Create<DateTime>();
                this.ui.EndDate = this.fixture.Create<DateTime>();

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.StartDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Reads_ui_EndDate()
            {
                this.ui.StartDate = this.fixture.Create<DateTime>();
                this.ui.EndDate = this.fixture.Create<DateTime>();

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.EndDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Pushes_StartDate_a_week_back()
            {
                var start = this.fixture.Create<DateTime>();
                this.ui.StartDate = start;
                this.ui.EndDate = this.fixture.Create<DateTime>();

                this.handler.Handle(
                    this.ui);

                Assert.InRange(
                    this.ui.StartDate,
                    start.Add(-this.settings.WeekLength),
                    start);
            }

            [Fact]
            public void Pushes_EndDate_a_week_back()
            {
                var end = this.fixture.Create<DateTime>();
                this.ui.StartDate = this.fixture.Create<DateTime>();
                this.ui.EndDate = end;

                this.handler.Handle(
                    this.ui);

                Assert.InRange(
                    this.ui.EndDate,
                    end.Add(-this.settings.WeekLength),
                    end);
            }
        }
    }
}
