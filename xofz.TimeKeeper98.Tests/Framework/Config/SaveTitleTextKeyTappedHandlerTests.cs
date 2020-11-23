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

    public class SaveTitleTextKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SaveTitleTextKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<ConfigUi>();
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.saver = A.Fake<ConfigSaver>();
                this.shell = A.Fake<TitleUi>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.saver);
                w.RegisterDependency(
                    this.shell);
            }
            protected readonly MethodWeb web;
            protected readonly SaveTitleTextKeyTappedHandler handler;
            protected readonly ConfigUi ui;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly ConfigSaver saver;
            protected readonly TitleUi shell;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_settings_TitleText_to_ui_TitleText()
            {
                this.ui.TitleText = this.fixture.Create<string>();

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.ui.TitleText,
                    this.settings.TitleText);
            }

            [Fact]
            public void Calls_saver_Save()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.saver.Save())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_shell_Title_to_ui_TitleText()
            {
                this.ui.TitleText = this.fixture.Create<string>();

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.ui.TitleText,
                    this.shell.Title);
            }
        }
    }
}
