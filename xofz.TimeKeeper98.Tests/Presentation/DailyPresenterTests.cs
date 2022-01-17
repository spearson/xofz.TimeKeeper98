namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Daily;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class DailyPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.ui = A.Fake<DailyUi>();
                this.presenter = new DailyPresenter(
                    this.ui,
                    A.Fake<ShellUi>(),
                    this.web);
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.homeUi = A.Fake<HomeUi>();
                this.setupHandler = A.Fake<SetupHandler>();
                this.startHandler = A.Fake<StartHandler>();
                this.currentHandler = A.Fake<CurrentKeyTappedHandler>();
                this.statsHandler = A.Fake<StatisticsRangeKeyTappedHandler>();
                this.homeHandler = A.Fake<HomeUiOutKeyTappedHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.setupHandler);
                w.RegisterDependency(
                    this.startHandler);
                w.RegisterDependency(
                    this.startHandler);
                w.RegisterDependency(
                    this.currentHandler);
                w.RegisterDependency(
                    this.statsHandler);
                w.RegisterDependency(
                    this.homeHandler);

                A
                    .CallTo(() => this.nav.GetUi<HomePresenter, HomeUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.homeUi);
            }

            protected MethodWebV2 web;
            protected DailyPresenter presenter;
            protected readonly DailyUi ui;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly HomeUi homeUi;
            protected readonly SetupHandler setupHandler;
            protected readonly StartHandler startHandler;
            protected readonly CurrentKeyTappedHandler currentHandler;
            protected readonly StatisticsRangeKeyTappedHandler statsHandler;
            protected readonly HomeUiOutKeyTappedHandler homeHandler;
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
                    .CallTo(() => this.setupHandler.Handle())
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_CurrentKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.CurrentKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ui_StatisticsRangeKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.StatisticsRangeKeyTapped),
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
            public void Registers_a_refreshDaily_Do()
            {
                this.presenter.Setup();

                var w = this.web;
                var registered = false;
                w.Run<Do>(refreshDaily =>
                    {
                        registered = true;
                    },
                    MethodNames.RefreshDaily);

                Assert.True(registered);
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

        public class When_the_current_key_is_tapped : Context
        {
            [Fact]
            public void Calls_currentHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.CurrentKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.currentHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_statistics_range_key_is_tapped : Context
        {
            [Fact]
            public void Calls_statsHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.StatisticsRangeKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.statsHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_home_out_key_is_tapped : Context
        {
            [Fact]
            public void Calls_homeHandler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.homeUi.OutKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.homeHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
