namespace xofz.TimeKeeper98.Tests.Framework.Home
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class EditKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new EditKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<HomeUi>();
                this.presentEditor = A.Fake<Do>();
            }

            protected readonly MethodWeb web;
            protected readonly EditKeyTappedHandler handler;
            protected readonly HomeUi ui;
            protected readonly Do presentEditor;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_presentEditor()
            {
                this.handler.Handle(
                    this.ui,
                    this.presentEditor);

                A
                    .CallTo(() => this.presentEditor.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
