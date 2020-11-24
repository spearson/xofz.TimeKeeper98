namespace xofz.TimeKeeper98.Tests.Framework.Timestamps
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class StatisticsRangeKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StatisticsRangeKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<TimestampsUi>();
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
            protected readonly StatisticsRangeKeyTappedHandler handler;
            protected readonly TimestampsUi ui;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
            protected readonly SettingsHolder settings;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_settings_ShowCurrent_to_false()
            {
                this.settings.ShowCurrent = true;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                Assert.False(
                    this.settings.ShowCurrent);
            }

            [Fact]
            public void Calls_StartHandler_Handle()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

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
