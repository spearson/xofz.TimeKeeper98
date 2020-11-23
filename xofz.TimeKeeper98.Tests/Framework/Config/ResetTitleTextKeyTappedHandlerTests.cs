namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class ResetTitleTextKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new ResetTitleTextKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<ConfigUi>();
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly ResetTitleTextKeyTappedHandler handler;
            protected readonly ConfigUi ui;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_ui_TitleText_to_settings_TitleText()
            {
                this.settings.TitleText = this.fixture.Create<string>();
                this.ui.TitleText = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.settings.TitleText,
                    this.ui.TitleText);
            }
        }
    }
}
