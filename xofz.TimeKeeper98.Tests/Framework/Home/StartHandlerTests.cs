namespace xofz.TimeKeeper98.Tests.Framework.Home
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.UI;
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
                this.ui = A.Fake<HomeUi>();
                this.timerHandler = A.Fake<TimerHandler>();
                this.timer = A.Fake<Timer>();
                this.settings = new GlobalSettingsHolder();
                this.fixture = new Fixture();

                var w = this.web;
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
            protected readonly HomeUi ui;
            protected readonly TimerHandler timerHandler;
            protected readonly Timer timer;
            protected readonly GlobalSettingsHolder settings;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Starts_the_timer_at_settings_Interval_times_1000()
            {
                this.settings.TimerIntervalSeconds = this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timer.Start(
                        this.settings.TimerIntervalSeconds * 1000))
                    .MustHaveHappened();
            }

            [Fact]
            public void If_interval_less_than_one_sets_interval_to_one()
            {
                this.settings.TimerIntervalSeconds = -14;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timer.Start(
                        1 * 1000))
                    .MustHaveHappened();
            }
        }
    }
}
