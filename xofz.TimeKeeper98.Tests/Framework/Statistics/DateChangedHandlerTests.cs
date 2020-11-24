namespace xofz.TimeKeeper98.Tests.Framework.Statistics
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class DateChangedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new DateChangedHandler(
                    this.web);
                this.ui = A.Fake<StatisticsUi>();
                this.timerHandler = A.Fake<TimerHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.timerHandler);
            }

            protected readonly MethodWeb web;
            protected readonly DateChangedHandler handler;
            protected readonly StatisticsUi ui;
            protected readonly TimerHandler timerHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_TimerHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timerHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
