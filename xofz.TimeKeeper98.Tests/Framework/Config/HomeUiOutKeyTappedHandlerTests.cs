namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Config;
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
                this.ui = A.Fake<ConfigUi>();
                this.startHandler = A.Fake<StartHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.startHandler);
            }

            protected readonly MethodWeb web;
            protected readonly HomeUiOutKeyTappedHandler handler;
            protected readonly ConfigUi ui;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_startHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
