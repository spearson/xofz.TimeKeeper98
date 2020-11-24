namespace xofz.TimeKeeper98.Tests.Framework.License
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class AcceptKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new AcceptKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<LicenseUi>();
                this.pub = A.Fake<Core98Publisher>();
                this.uiRW = new UiReaderWriter();

                var w = this.web;
                w.RegisterDependency(
                    this.pub);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly AcceptKeyTappedHandler handler;
            protected readonly LicenseUi ui;
            protected readonly Core98Publisher pub;
            protected readonly UiReaderWriter uiRW;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_pub_Publish()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.pub.Publish())
                    .MustHaveHappened();
            }

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
