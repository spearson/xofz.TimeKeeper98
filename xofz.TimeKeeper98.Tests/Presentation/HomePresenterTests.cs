namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class HomePresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<HomeUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWebV2();
                this.presenter = new HomePresenter(
                    this.ui,
                    this.shell,
                    this.web);
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.timer = A.Fake<Timer>();
                this.setupHandler = A.Fake<SetupHandler>();
                this.timerHandler = A.Fake<TimerHandler>();
                this.startHandler = A.Fake<StartHandler>();
                this.inHandler = A.Fake<InKeyTappedHandler>();
                this.outHandler = A.Fake<OutKeyTappedHandler>();
                this.editHandler = A.Fake<EditKeyTappedHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.timer,
                    DependencyNames.Timer);
                w.RegisterDependency(
                    this.setupHandler);
                w.RegisterDependency(
                    this.timerHandler);
                w.RegisterDependency(
                    this.startHandler);
                w.RegisterDependency(
                    this.inHandler);
                w.RegisterDependency(
                    this.outHandler);
                w.RegisterDependency(
                    this.editHandler);
            }

            protected readonly HomeUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWebV2 web;
            protected readonly HomePresenter presenter;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly Timer timer;
            protected readonly SetupHandler setupHandler;
            protected readonly TimerHandler timerHandler;
            protected readonly StartHandler startHandler;
            protected readonly InKeyTappedHandler inHandler;
            protected readonly OutKeyTappedHandler outHandler;
            protected readonly EditKeyTappedHandler editHandler;
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
            public void Subscribes_to_InKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.InKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_OutKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.OutKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_EditKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.EditKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_timer_Elapsed()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.timer,
                        nameof(this.timer.Elapsed),
                        A<Do>.Ignored))
                    .MustHaveHappened();
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
            public void Registers_a_refresh_home_Do()
            {
                this.presenter.Setup();

                var w = this.web;
                var registered = false;
                w.Run<Do>(refreshHome =>
                    {
                        registered = true;
                    },
                    MethodNames.RefreshHome);

                Assert.True(registered);
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
            public void Switches_the_ui_into_the_shell()
            {
                this.presenter.Setup();
                
                this.presenter.Start();

                A
                    .CallTo(() => this.shell.SwitchUi(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_StartHandler_Handle()
            {
                this.presenter.Setup();
                
                this.presenter.Start();

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_in_key_is_tapped : Context
        {
            [Fact]
            public void Calls_InKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.InKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.inHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_out_key_is_tapped : Context
        {
            [Fact]
            public void Calls_OutKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.OutKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.outHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_edit_key_is_tapped : Context
        {
            [Fact]
            public void Calls_EditKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.EditKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.editHandler.Handle(
                        this.ui,
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }
        }

        public class When_the_timer_elapses : Context
        {
            [Fact]
            public void Calls_TimerHandler_Handle()
            {
                this.presenter.Setup();

                this.timer.Elapsed += Raise.FreeForm.With();

                A
                    .CallTo(() => this.timerHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
