namespace xofz.TimeKeeper98.Tests.Framework.Timestamps
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class HomeUiOutKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new HomeUiOutKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<TimestampsUi>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.statsUi = A.Fake<StatisticsUi>();
                this.startHandler = A.Fake<StartHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.startHandler);
            }

            protected readonly MethodWeb web;
            protected readonly HomeUiOutKeyTappedHandler handler;
            protected readonly TimestampsUi ui;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_startHandler_Handle()
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