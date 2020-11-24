namespace xofz.TimeKeeper98.Tests.Framework.HomeNav
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using Xunit;

    public class TimestampsKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new TimestampsKeyTappedHandler(
                    this.web);
                this.reader = A.Fake<NavLogicReader>();

                var w = this.web;
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly TimestampsKeyTappedHandler handler;
            protected readonly NavLogicReader reader;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_reader_ReadTimestamps()
            {
                Do present;

                this.handler.Handle();

                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_navToTimestamps()
            {
                var present = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadTimestamps(
                        out present))
                    .AssignsOutAndRefParameters(present);

                this.handler.Handle();

                A
                    .CallTo(() => present.Invoke())
                    .MustHaveHappened();

            }
        }
    }
}
