namespace xofz.TimeKeeper98.Tests.Framework.Statistics
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
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
                this.ui = A.Fake<StatisticsUi>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.uiRW = new UiReaderWriter();
                this.timerHandler = A.Fake<TimerHandler>();
                this.timer = A.Fake<Timer>();
                this.settings = new GlobalSettingsHolder();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.timerHandler);
                w.RegisterDependency(
                    this.timer,
                    DependencyNames.Timer);
                w.RegisterDependency(
                    this.settings);
            }

            protected readonly MethodWeb web;
            protected readonly StartHandler handler;
            protected readonly StatisticsUi ui;
            protected readonly HomeNavUi homeNavUi;
            protected readonly UiReaderWriter uiRW;
            protected readonly TimerHandler timerHandler;
            protected readonly Timer timer;
            protected readonly GlobalSettingsHolder settings;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void
                Sets_homeNavUi_ActiveKeyLabel_to_NavKeyLabels_Statistics()
            {
                this.homeNavUi.ActiveKeyLabel = null;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi);

                Assert.Equal(
                    NavKeyLabels.Statistics,
                    this.homeNavUi.ActiveKeyLabel);
            }

            [Fact]
            public void Calls_timerHandler_Handle()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi);

                A
                    .CallTo(() => this.timerHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Starts_the_timer()
            {
                this.settings.TimerIntervalSeconds =
                    this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi);

                A
                    .CallTo(() => this.timer.Start(
                        this.settings.TimerIntervalSeconds * 1000))
                    .MustHaveHappened();
            }

            [Fact]
            public void Starts_timer_with_min_one_second()
            {
                this.settings.TimerIntervalSeconds =
                    -this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi);

                A
                    .CallTo(() => this.timer.Start(
                        1 * 1000))
                    .MustHaveHappened();
            }
        }
    }
}
