namespace xofz.TimeKeeper98.Tests.Framework.Statistics
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Statistics;
    using Xunit;

    public class StopHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StopHandler(
                    this.web);
                this.timer = A.Fake<Timer>();

                var w = this.web;
                w.RegisterDependency(
                    this.timer,
                    DependencyNames.Timer);
            }

            protected readonly MethodWeb web;
            protected readonly StopHandler handler;
            protected readonly Timer timer;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Stops_the_timer()
            {
                this.handler.Handle();

                A
                    .CallTo(() => this.timer.Stop())
                    .MustHaveHappened();
            }
        }
    }
}
