namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class KeyboardKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new KeyboardKeyTappedHandler(
                    this.web);
                this.loader = A.Fake<KeyboardLoader>();
                this.uiRW = new UiReaderWriter();
                this.ui = A.Fake<ConfigUi>();

                var w = this.web;
                w.RegisterDependency(
                    this.loader);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly KeyboardKeyTappedHandler handler;
            protected readonly KeyboardLoader loader;
            protected readonly UiReaderWriter uiRW;
            protected readonly ConfigUi ui;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_loader_Load()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.loader.Load())
                    .MustHaveHappened();
            }

            [Fact]
            public void Focuses_title_text_box()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.FocusTitleTextTextBox())
                    .MustHaveHappened();
            }
        }
    }
}
