namespace xofz.TimeKeeper98.Tests.Framework.HomeNav
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using Xunit;

    public class StatisticsKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StatisticsKeyTappedHandler(
                    this.web);
                this.reader = A.Fake<NavLogicReader>();

                var w = this.web;
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly StatisticsKeyTappedHandler handler;
            protected readonly NavLogicReader reader;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_reader_ReadStatistics()
            {
                Do present;

                this.handler.Handle();

                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_navToStats()
            {
                var navToStats = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadStatistics(
                        out navToStats))
                    .AssignsOutAndRefParameters(navToStats);

                this.handler.Handle();

                A
                    .CallTo(() => navToStats.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
