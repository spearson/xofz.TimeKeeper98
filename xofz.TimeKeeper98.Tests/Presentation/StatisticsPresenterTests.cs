namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class StatisticsPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<StatisticsUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWebV2();
                this.presenter = new StatisticsPresenter(
                    this.ui,
                    this.shell,
                    this.web);
                this.setupHandler = A.Fake<SetupHandler>();
                this.sub = new EventSubscriber();
                this.timer = A.Fake<Timer>();
                this.nav = A.Fake<Navigator>();
                this.startHandler = A.Fake<StartHandler>();
                this.stopHandler = A.Fake<StopHandler>();
                this.currentHandler = A.Fake<CurrentWeekKeyTappedHandler>();
                this.previousHandler = A.Fake<PreviousWeekKeyTappedHandler>();
                this.nextHandler = A.Fake<NextWeekKeyTappedHandler>();
                this.dateHandler = A.Fake<DateChangedHandler>();
                this.timerHandler = A.Fake<TimerHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.setupHandler);
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.timer,
                    DependencyNames.Timer);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.startHandler);
                w.RegisterDependency(
                    this.stopHandler);
                w.RegisterDependency(
                    this.currentHandler);
                w.RegisterDependency(
                    this.previousHandler);
                w.RegisterDependency(
                    this.nextHandler);
                w.RegisterDependency(
                    this.dateHandler);
                w.RegisterDependency(
                    this.timerHandler);
            }

            protected readonly StatisticsUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWebV2 web;
            protected readonly StatisticsPresenter presenter;
            protected readonly SetupHandler setupHandler;
            protected EventSubscriber sub;
            protected readonly Timer timer;
            protected readonly Navigator nav;
            protected readonly StartHandler startHandler;
            protected readonly StopHandler stopHandler;
            protected readonly CurrentWeekKeyTappedHandler currentHandler;
            protected readonly PreviousWeekKeyTappedHandler previousHandler;
            protected readonly NextWeekKeyTappedHandler nextHandler;
            protected readonly DateChangedHandler dateHandler;
            protected readonly TimerHandler timerHandler;
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
            public void Calls_SetupHandler_Handle()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.setupHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_DateChanged()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.DateChanged),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_CurrentWeekKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.CurrentWeekKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_PreviousWeekKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.PreviousWeekKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_NextWeekKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.NextWeekKeyTapped),
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
                this.presenter.Start();

                A
                    .CallTo(() => this.shell.SwitchUi(
                        this.ui))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_startHandler_Handle()
            {
                var hnUi = A.Fake<HomeNavUi>();
                A
                    .CallTo(() => this.nav.GetUi<HomeNavPresenter, HomeNavUi>(
                        null, 
                        Presenter.DefaultUiFieldName))
                    .Returns(hnUi);

                this.presenter.Start();

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui,
                        hnUi))
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
                    .CallTo(() => this.stopHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_current_week_key_is_tapped : Context
        {
            [Fact]
            public void Calls_CurrentWeekKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.CurrentWeekKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.currentHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_previous_week_key_is_tapped : Context
        {
            [Fact]
            public void Calls_PreviousWeekKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.PreviousWeekKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.previousHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_next_week_key_is_tapped : Context
        {
            [Fact]
            public void Calls_NextWeekKeyTappedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.NextWeekKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.nextHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_date_changes : Context
        {
            [Fact]
            public void Calls_DateChangedHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.DateChanged += Raise.FreeForm.With();

                A
                    .CallTo(() => this.dateHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_timer_Elapses : Context
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
