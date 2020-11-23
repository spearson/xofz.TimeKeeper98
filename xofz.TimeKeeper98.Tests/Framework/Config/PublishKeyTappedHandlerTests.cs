namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using Xunit;

    public class PublishKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new PublishKeyTappedHandler(
                    this.web);
                this.reader = A.Fake<NavLogicReader>();

                var w = this.web;
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly PublishKeyTappedHandler handler;
            protected readonly NavLogicReader reader;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_reader_ReadLicense()
            {
                Do present = null;

                this.handler.Handle();

                A
                    .CallTo(() => this.reader.ReadLicense(
                        out present))
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_it()
            {
                Do present = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadLicense(
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
