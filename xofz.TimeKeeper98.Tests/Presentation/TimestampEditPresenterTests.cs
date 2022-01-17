namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class TimestampEditPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<TimestampEditUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWebV2();
                this.presenter = new TimestampEditPresenter(
                    this.ui,
                    this.shell,
                    this.web);
                this.setupHandler = A.Fake<SetupHandler>();
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.startHandler = A.Fake<StartHandler>();
                this.stopHandler = A.Fake<StopHandler>();
                this.saveHandler = A.Fake<SaveKeyTappedHandler>();
                this.currentHandler = A.Fake<SaveCurrentKeyTappedHandler>();
                this.cancelHandler = A.Fake<CancelKeyTappedHandler>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.homeUi = A.Fake<HomeUi>();

                A
                    .CallTo(() => this.nav.GetUi<HomeNavPresenter, HomeNavUi>(
                        null, Presenter.DefaultUiFieldName))
                    .Returns(this.homeNavUi);
                A
                    .CallTo(() => this.nav.GetUi<HomePresenter, HomeUi>(
                        null, Presenter.DefaultUiFieldName))
                    .Returns(this.homeUi);

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
                    this.stopHandler);
                w.RegisterDependency(
                    this.saveHandler);
                w.RegisterDependency(
                    this.currentHandler);
                w.RegisterDependency(
                    this.cancelHandler);
            }

            protected readonly TimestampEditUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWebV2 web;
            protected readonly TimestampEditPresenter presenter;
            protected readonly SetupHandler setupHandler;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly StartHandler startHandler;
            protected readonly StopHandler stopHandler;
            protected readonly SaveKeyTappedHandler saveHandler;
            protected readonly SaveCurrentKeyTappedHandler currentHandler;
            protected readonly CancelKeyTappedHandler cancelHandler;
            protected readonly HomeNavUi homeNavUi;
            protected readonly HomeUi homeUi;
        }

        public class When_Setup_is_called : Context
        {
            public When_Setup_is_called()
            {
                this.sub = A.Fake<EventSubscriber>();
                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.Unregister<EventSubscriber>();
            }

            [Fact]
            public void Calls_SetupHandler_Handle()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.setupHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_SaveKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.SaveKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_CancelKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.CancelKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_SaveCurrentKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.SaveCurrentKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Registers_itself_with_the_navigator()
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
            public void Switches_the_ui_into_the_shell()
            {
                this.presenter.Start();

                A
                    .CallTo(() => this.shell.SwitchUi(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_StartHandler_Handle()
            {
                this.presenter.Start();

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.homeUi))
                    .MustHaveHappened();
            }
        }

        public class When_Stop_is_called : Context
        {
            [Fact]
            public void Calls_StopHandler_Handle()
            {
                this.presenter.Stop();

                A
                    .CallTo(() => this.stopHandler.Handle(
                        this.homeUi))
                    .MustHaveHappened();
            }
        }

        public class When_the_save_key_is_tapped : Context
        {
            [Fact]
            public void Calls_SaveKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.SaveKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.saveHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_save_current_key_is_tapped : Context
        {
            [Fact]
            public void Calls_SaveCurrentKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.SaveCurrentKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.currentHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_cancel_key_is_tapped : Context
        {
            [Fact]
            public void Calls_CancelKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.CancelKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.cancelHandler.Handle())
                    .MustHaveHappened();
            }
        }
    }
}
