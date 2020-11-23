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

    public class SetupHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SetupHandler(
                    this.web);
                this.ui = A.Fake<ConfigUi>();
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.promptOnHandler = A.Fake<PromptSelectedHandler>();
                this.promptOffHandler = A.Fake<PromptUnselectedHandler>();
                this.resetHandler = A.Fake<ResetTitleTextKeyTappedHandler>();
                this.showOnHandler = A.Fake<ShowSecondsSelectedHandler>();
                this.showOffHandler = A.Fake<ShowSecondsUnselectedHandler>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.promptOnHandler);
                w.RegisterDependency(
                    this.promptOffHandler);
                w.RegisterDependency(
                    this.resetHandler);
                w.RegisterDependency(
                    this.showOnHandler);
                w.RegisterDependency(
                    this.showOffHandler);
            }

            protected readonly MethodWeb web;
            protected readonly SetupHandler handler;
            protected readonly ConfigUi ui;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly PromptSelectedHandler promptOnHandler;
            protected readonly PromptUnselectedHandler promptOffHandler;
            protected readonly ResetTitleTextKeyTappedHandler resetHandler;
            protected readonly ShowSecondsSelectedHandler showOnHandler;
            protected readonly ShowSecondsUnselectedHandler showOffHandler;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void If_settings_Prompt_sets_ui_PromptChecked_to_true()
            {
                this.settings.Prompt = true;
                this.ui.PromptChecked = false;

                this.handler.Handle(
                    this.ui);

                Assert.True(
                    this.ui.PromptChecked);
            }

            [Fact]
            public void Also_calls_PromptSelectedHandler_Handle()
            {
                this.settings.Prompt = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.promptOnHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_calls_PromptUnselectedHandler_Handle()
            {
                this.settings.Prompt = false;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.promptOffHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                Sets_ui_TimerIntervalSeconds_to_settings_TimerIntervalSeconds()
            {
                this.settings.TimerIntervalSeconds = this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.settings.TimerIntervalSeconds,
                    this.ui.TimerIntervalSeconds);
            }

            [Fact]
            public void Calls_ResetTitleTextKeyTappedHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.resetHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                If_settings_ShowSeconds_sets_ui_ShowSecondsChecked_to_true()
            {
                this.settings.ShowSeconds = true;
                this.ui.ShowSecondsChecked = false;

                this.handler.Handle(
                    this.ui);

                Assert.True(
                    this.ui.ShowSecondsChecked);
            }

            [Fact]
            public void Also_calls_ShowSecondsSelectedHandler_Handle()
            {
                this.settings.ShowSeconds = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.showOnHandler.Handle())
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_calls_ShowSecondsUnselectedHandler_Handle()
            {
                this.settings.ShowSeconds = false;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.showOffHandler.Handle())
                    .MustHaveHappened();
            }
        }
    }
}
