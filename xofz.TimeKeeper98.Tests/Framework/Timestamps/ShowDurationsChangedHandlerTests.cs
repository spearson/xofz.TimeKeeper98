namespace xofz.TimeKeeper98.Tests.Framework.Timestamps
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class ShowDurationsChangedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new ShowDurationsChangedHandler(
                    this.web);
                this.ui = A.Fake<TimestampsUi>();
                this.fixture = new Fixture();
                this.shouldShow = this.fixture.Create<bool>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.statsUi = A.Fake<StatisticsUi>();
                this.settings = new SettingsHolder();
                this.startHandler = A.Fake<StartHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.startHandler);
            }

            protected readonly MethodWeb web;
            protected readonly ShowDurationsChangedHandler handler;
            protected readonly TimestampsUi ui;
            protected readonly Fixture fixture;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
            protected readonly bool shouldShow;
            protected readonly SettingsHolder settings;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_settings_ShowDurations()
            {
                this.settings.ShowDurations = !this.shouldShow;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi,
                    this.shouldShow);

                Assert.Equal(
                    this.shouldShow,
                    this.settings.ShowDurations);
            }

            [Fact]
            public void Calls_startHandler_Handle()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi,
                    this.shouldShow);

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi))
                    .MustHaveHappened();
            }
        }
    }
}
