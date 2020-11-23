namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class DefaultTitleTextKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new DefaultTitleTextKeyTappedHandler(
                    this.web);
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.saver = A.Fake<ConfigSaver>();
                this.shell = A.Fake<TitleUi>();
                this.ui = A.Fake<ConfigUi>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.shell);
                w.RegisterDependency(
                    this.saver);
            }

            protected readonly MethodWeb web;
            protected readonly DefaultTitleTextKeyTappedHandler handler;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly ConfigSaver saver;
            protected readonly TitleUi shell;
            protected readonly ConfigUi ui;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_ui_TitleText_to_DefaultTitle()
            {
                this.ui.TitleText = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    UiConstants.DefaultTitle,
                    this.ui.TitleText);
            }

            [Fact]
            public void Sets_settings_TitleText_to_DefaultTitle()
            {
                this.settings.TitleText = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    UiConstants.DefaultTitle,
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
            public void Sets_shell_Title_to_DefaultTitle()
            {
                this.shell.Title = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    UiConstants.DefaultTitle,
                    this.shell.Title);
            }
        }
    }
}
