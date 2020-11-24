namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
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
                this.ui = A.Fake<HomeUi>();
                this.uiRW = new UiReaderWriter();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly StopHandler handler;
            protected readonly HomeUi ui;
            protected readonly UiReaderWriter uiRW;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_ui_Editing_to_false()
            {
                this.ui.Editing = true;

                this.handler.Handle(
                    this.ui);

                Assert.False(
                    this.ui.Editing);
            }
        }
    }
}
