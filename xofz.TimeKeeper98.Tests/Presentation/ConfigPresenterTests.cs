namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class ConfigPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<ConfigUi>();
                this.web = new MethodWebV2();
                this.setupHandler = A.Fake<SetupHandler>();
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.startHandler = A.Fake<StartHandler>();
                this.promptHandler = A.Fake<PromptSelectedHandler>();
                this.keyboardHandler = A.Fake<KeyboardKeyTappedHandler>();
                this.prompt2Handler = A.Fake<PromptUnselectedHandler>();
                this.saveTitleHandler = A.Fake<SaveTitleTextKeyTappedHandler>();
                this.resetHandler = A.Fake<ResetTitleTextKeyTappedHandler>();
                this.defaultHandler =
                    A.Fake<DefaultTitleTextKeyTappedHandler>();
                this.secondsHandler = A.Fake<ShowSecondsSelectedHandler>();
                this.seconds2Handler = A.Fake<ShowSecondsUnselectedHandler>();
                this.saveIntervalHandler =
                    A.Fake<SaveIntervalKeyTappedHandler>();
                this.reset2Handler = A.Fake<ResetIntervalKeyTappedHandler>();
                this.publishHandler = A.Fake<PublishKeyTappedHandler>();
                this.homeInHandler = A.Fake<HomeUiInKeyTappedHandler>();
                this.homeOutHandler = A.Fake<HomeUiOutKeyTappedHandler>();
                this.presenter = new ConfigPresenter(
                    this.ui,
                    A.Fake<ShellUi>(),
                    this.web);
                this.homeUi = A.Fake<HomeUi>();

                var w = this.web;
                w.RegisterDependency(
                    this.setupHandler);
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.startHandler);
                w.RegisterDependency(
                    this.promptHandler);
                w.RegisterDependency(
                    this.keyboardHandler);
                w.RegisterDependency(
                    this.prompt2Handler);
                w.RegisterDependency(
                    this.saveTitleHandler);
                w.RegisterDependency(
                    this.resetHandler);
                w.RegisterDependency(
                    this.defaultHandler);
                w.RegisterDependency(
                    this.secondsHandler);
                w.RegisterDependency(
                    this.seconds2Handler);
                w.RegisterDependency(
                    this.saveIntervalHandler);
                w.RegisterDependency(
                    this.reset2Handler);
                w.RegisterDependency(
                    this.publishHandler);
                w.RegisterDependency(
                    this.homeInHandler);
                w.RegisterDependency(
                    this.homeOutHandler);

                A
                    .CallTo(() => this.nav.GetUi<HomePresenter, HomeUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.homeUi);

            }

            protected readonly ConfigUi ui;
            protected readonly MethodWebV2 web;
            protected readonly SetupHandler setupHandler;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly StartHandler startHandler;
            protected readonly PromptSelectedHandler promptHandler;
            protected readonly KeyboardKeyTappedHandler keyboardHandler;
            protected readonly PromptUnselectedHandler prompt2Handler;
            protected readonly SaveTitleTextKeyTappedHandler saveTitleHandler;
            protected readonly ResetTitleTextKeyTappedHandler resetHandler;
            protected readonly DefaultTitleTextKeyTappedHandler defaultHandler;
            protected readonly ShowSecondsSelectedHandler secondsHandler;
            protected readonly ShowSecondsUnselectedHandler seconds2Handler;
            protected readonly SaveIntervalKeyTappedHandler saveIntervalHandler;
            protected readonly ResetIntervalKeyTappedHandler reset2Handler;
            protected readonly PublishKeyTappedHandler publishHandler;
            protected readonly HomeUiInKeyTappedHandler homeInHandler;
            protected readonly HomeUiOutKeyTappedHandler homeOutHandler;
            protected readonly ConfigPresenter presenter;
            protected readonly HomeUi homeUi;
        }

        public class When_Setup_is_called : Context
        {
            public When_Setup_is_called()
            {
                this.sub = A.Fake<EventSubscriber>();
                var w = this.web;
                w.Unregister<EventSubscriber>();
                w.RegisterDependency(
                    this.sub);
            }

            [Fact]
            public void Calls_setupHandler_Handle()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.setupHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_PromptSelected()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.PromptSelected),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_PromptUnselected()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.PromptUnselected),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_KeyboardKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.KeyboardKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_SaveTitleTextKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.SaveTitleTextKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ResetTitleTextKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ResetTitleTextKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_DefaultTitleTextKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.DefaultTitleTextKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_ShowSecondsSelected()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ShowSecondsSelected),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_ShowSecondsUnselected()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ShowSecondsUnselected),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_SaveIntervalKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.SaveIntervalKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_ResetIntervalKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ResetIntervalKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_PublishKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.PublishKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_homeUi_InKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.homeUi,
                        nameof(this.homeUi.InKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_homeUi_OutKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.homeUi,
                        nameof(this.homeUi.OutKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Registers_itself_with_the_Navigator()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        this.presenter))
                    .MustHaveHappened();
            }
        }

        public class When_Start_is_called : Context
        {
            [Fact]
            public void Calls_startHandler_Handle()
            {
                this.presenter.Setup();

                this.presenter.Start();

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_prompt_is_selected : Context
        {
            [Fact]
            public void Calls_promptHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.PromptSelected += Raise.FreeForm.With();

                A
                    .CallTo(() => this.promptHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_keyboard_key_is_tapped : Context
        {
            [Fact]
            public void Calls_keyboardHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.KeyboardKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.keyboardHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_prompt_is_unselected : Context
        {
            [Fact]
            public void Calls_PromptUnselectedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.PromptUnselected += Raise.FreeForm.With();

                A
                    .CallTo(() => this.prompt2Handler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_save_title_key_is_tapped : Context
        {
            [Fact]
            public void Calls_save_title_handler_Handle()
            {
                this.presenter.Setup();

                this.ui.SaveTitleTextKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.saveTitleHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_reset_title_key_is_tapped : Context
        {
            [Fact]
            public void Calls_reset_title_handler_Handle()
            {
                this.presenter.Setup();

                this.ui.ResetTitleTextKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.resetHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_default_title_key_is_tapped : Context
        {
            [Fact]
            public void Calls_default_handler_Handle()
            {
                this.presenter.Setup();

                this.ui.DefaultTitleTextKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.defaultHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_show_seconds_is_selected : Context
        {
            [Fact]
            public void Calls_showSecondsHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.ShowSecondsSelected += Raise.FreeForm.With();

                A
                    .CallTo(() => this.secondsHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_show_seconds_is_unselected : Context
        {
            [Fact]
            public void Calls_showSeconds2Handler_Handle()
            {
                this.presenter.Setup();

                this.ui.ShowSecondsUnselected += Raise.FreeForm.With();

                A
                    .CallTo(() => this.seconds2Handler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_save_interval_key_is_tapped : Context
        {
            [Fact]
            public void Calls_saveIntervalHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.SaveIntervalKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.saveIntervalHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_reset_interval_key_is_tapped : Context
        {
            [Fact]
            public void Calls_resetIntervalHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.ResetIntervalKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.reset2Handler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_in_key_is_tapped : Context
        {
            [Fact]
            public void Calls_home_in_handler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.homeUi.InKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.homeInHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_out_key_is_tapped : Context
        {
            [Fact]
            public void Calls_home_out_handler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.homeUi.OutKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.homeOutHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
