namespace xofz.TimeKeeper98.Tests.Framework.License
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class RejectKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new RejectKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<LicenseUi>();
                this.uiRW = new UiReaderWriter();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly RejectKeyTappedHandler handler;
            protected readonly LicenseUi ui;
            protected readonly UiReaderWriter uiRW;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Hides_the_ui()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.Hide())
                    .MustHaveHappened();
            }
        }
    }
}
