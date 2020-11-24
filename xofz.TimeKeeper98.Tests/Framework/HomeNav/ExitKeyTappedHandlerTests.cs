namespace xofz.TimeKeeper98.Tests.Framework.HomeNav
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using Xunit;

    public class ExitKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new ExitKeyTappedHandler(
                    this.web);
                this.reader = A.Fake<NavLogicReader>();

                var w = this.web;
                w.RegisterDependency(
                    this.reader);
            }

            protected readonly MethodWeb web;
            protected readonly ExitKeyTappedHandler handler;
            protected readonly NavLogicReader reader;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_reader_ReadExit()
            {
                Do exit;

                this.handler.Handle();

                A
                    .CallTo(() => this.reader.ReadExit(
                        out exit))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_exit()
            {
                var exit = A.Fake<Do>();
                A
                    .CallTo(() => this.reader.ReadExit(
                        out exit))
                    .AssignsOutAndRefParameters(exit);

                this.handler.Handle();

                A
                    .CallTo(() => exit.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
