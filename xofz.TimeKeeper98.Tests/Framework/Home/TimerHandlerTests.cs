namespace xofz.TimeKeeper98.Tests.Framework.Home
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
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
                this.ui = A.Fake<HomeUi>();
                this.timerLatch = A.Fake<LatchHolder>();
                this.uiRW = new UiReaderWriter();
                this.calc = A.Fake<StatisticsCalculator>();
                this.viewer = A.Fake<PaddedTimeSpanViewer>();
                this.reader = A.Fake<TimestampReader>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.timerLatch,
                    DependencyNames.Latch);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.calc);
                w.RegisterDependency(
                    this.viewer);
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly TimerHandler handler;
            protected readonly HomeUi ui;
            protected readonly LatchHolder timerLatch;
            protected readonly UiReaderWriter uiRW;
            protected readonly StatisticsCalculator calc;
            protected readonly PaddedTimeSpanViewer viewer;
            protected readonly TimestampReader reader;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Hits_the_timerLatch()
            {
                // to reset it
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timerLatch.Latch)
                    .MustHaveHappened();
            }

            [Fact]
            public void Hits_the_timerLatch_twice()
            {
                // to reset it and then set it
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timerLatch.Latch)
                    .MustHaveHappened(
                        2, Times.Exactly);
            }

            [Fact]
            public void Hits_calc_TimeWorkedThisWeek()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.TimeWorkedThisWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Hits_calc_TimeWorkedToday()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.TimeWorkedToday())
                    .MustHaveHappened();
            }

            [Fact]
            public void Hits_viewer_ReadableString()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        A<TimeSpan>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_viewer_ReadableString_twice()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        A<TimeSpan>.Ignored))
                    .MustHaveHappened(
                        2, Times.Exactly);
            }

            [Fact]
            public void Calls_calc_ClockedIn()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.ClockedIn())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_InKeyVisible()
            {
                var inVisible = this.fixture.Create<bool>();
                A
                    .CallTo(() => this.calc.ClockedIn())
                    .Returns(!inVisible);

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    inVisible,
                    this.ui.InKeyVisible);
            }

            [Fact]
            public void Sets_ui_OutKeyVisible()
            {
                var outVisible = this.fixture.Create<bool>();
                A
                    .CallTo(() => this.calc.ClockedIn())
                    .Returns(outVisible);

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    outVisible,
                    this.ui.OutKeyVisible);
            }

            [Fact]
            public void If_no_timestamps_sets_EditKeyEnabled_to_false()
            {
                this.ui.EditKeyEnabled = true;

                this.handler.Handle(
                    this.ui);

                Assert.False(
                    this.ui.EditKeyEnabled);
            }

            [Fact]
            public void True_otherwise()
            {
                this.ui.EditKeyEnabled = false;
                A
                    .CallTo(() => this.reader.Read())
                    .Returns(new[] {this.fixture.Create<DateTime>()});

                this.handler.Handle(
                    this.ui);

                Assert.True(
                    this.ui.EditKeyEnabled);
            }

            [Fact]
            public void Sets_ui_TimeWorkedThisWeek()
            {
                A
                    .CallTo(() => this.viewer.ReadableString(
                        A<TimeSpan>.Ignored))
                    .Returns(this.fixture.Create<string>());
                this.ui.TimeWorkedThisWeek = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.TimeWorkedThisWeek);
            }

            [Fact]
            public void Sets_ui_TimeWorkedToday()
            {
                A
                    .CallTo(() => this.viewer.ReadableString(
                        A<TimeSpan>.Ignored))
                    .Returns(this.fixture.Create<string>());
                this.ui.TimeWorkedToday = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.TimeWorkedToday);
            }
        }
    }
}
