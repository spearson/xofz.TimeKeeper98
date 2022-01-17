namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class TimestampsPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<TimestampsUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWebV2();
                this.presenter = new TimestampsPresenter(
                    this.ui,
                    this.shell,
                    this.web);
                this.sub = new EventSubscriber();
                this.setupHandler = A.Fake<SetupHandler>();
                this.nav = A.Fake<Navigator>();
                this.startHandler = A.Fake<StartHandler>();
                this.homeUi = A.Fake<HomeUi>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.statsUi = A.Fake<StatisticsUi>();
                this.inHandler = A.Fake<HomeUiInKeyTappedHandler>();
                this.outHandler = A.Fake<HomeUiOutKeyTappedHandler>();
                this.currentHandler = A.Fake<CurrentKeyTappedHandler>();
                this.statsHandler = A.Fake<StatisticsRangeKeyTappedHandler>();
                this.durationsHandler = A.Fake<ShowDurationsChangedHandler>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.setupHandler);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.startHandler);
                A
                    .CallTo(() => this.nav.GetUi<HomeNavPresenter, HomeNavUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.homeNavUi);
                A
                    .CallTo(() => this.nav.GetUi<HomePresenter, HomeUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.homeUi);
                A
                    .CallTo(() => this.nav.GetUi<StatisticsPresenter, StatisticsUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.statsUi);
                w.RegisterDependency(
                    this.inHandler);
                w.RegisterDependency(
                    this.outHandler);
                w.RegisterDependency(
                    this.currentHandler);
                w.RegisterDependency(
                    this.statsHandler);
                w.RegisterDependency(
                    this.durationsHandler);
            }

            protected readonly TimestampsUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWebV2 web;
            protected readonly TimestampsPresenter presenter;
            protected EventSubscriber sub;
            protected readonly SetupHandler setupHandler;
            protected readonly Navigator nav;
            protected readonly StartHandler startHandler;
            protected readonly HomeUi homeUi;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
            protected readonly HomeUiInKeyTappedHandler inHandler;
            protected readonly HomeUiOutKeyTappedHandler outHandler;
            protected readonly CurrentKeyTappedHandler currentHandler;
            protected readonly StatisticsRangeKeyTappedHandler statsHandler;
            protected readonly ShowDurationsChangedHandler durationsHandler;
            protected readonly Fixture fixture;
        }

        public class When_Setup_is_called : Context
        {
            public When_Setup_is_called()
            {
                var w = this.web;
                this.sub = A.Fake<EventSubscriber>();
                w.RegisterDependency(
                    this.sub);
                w.Unregister<EventSubscriber>();
            }

            [Fact]
            public void Calls_SetupHandler_Handle()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.setupHandler.Handle())
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_CurrentKeyTapped()
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
            public void Subscribes_to_StatisticsRangeKeyTapped()
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
            public void Subscribes_to_ShowDurationsChanged()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ShowDurationChanged),
                        A<Do<bool>>.Ignored))
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
            public void Registers_a_RefreshTimestamps_Do()
            {
                this.presenter.Setup();

                var registered = false;
                var w = this.web;
                w.Run<Do>(refreshTimestamps =>
                    {
                        registered = true;
                    },
                    MethodNames.RefreshTimestamps);

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
                        this.statsUi))
                    .MustHaveHappened();
            }
        }

        public class When_the_in_key_is_tapped : Context
        {
            [Fact]
            public void Calls_HomeUiInKeyTappedHandler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.homeUi.InKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.inHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi))
                    .MustHaveHappened();
            }
        }

        public class When_the_out_key_is_tapped : Context
        {
            [Fact]
            public void Calls_outHandler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.homeUi.OutKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.outHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi))
                    .MustHaveHappened();
            }
        }

        public class When_the_current_key_is_tapped : Context
        {
            [Fact]
            public void Calls_CurrentKeyTappedHandler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.ui.CurrentKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.currentHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi))
                    .MustHaveHappened();
            }
        }

        public class When_the_statistics_range_key_is_tapped : Context
        {
            [Fact]
            public void Calls_statsHandler_Handle()
            {
                this.presenter.Setup();
                this.presenter.Start();

                this.ui.StatisticsRangeKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.statsHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi))
                    .MustHaveHappened();
            }
        }

        public class When_show_durations_is_changed : Context
        {
            [Fact]
            public void Calls_ShowDurationsChangedHandler_Handle()
            {
                var show = this.fixture.Create<bool>();
                this.presenter.Setup();
                this.presenter.Start();

                this.ui.ShowDurationChanged += Raise.FreeForm.With(show);

                A
                    .CallTo(() => this.durationsHandler.Handle(
                        this.ui,
                        this.homeNavUi,
                        this.statsUi,
                        show))
                    .MustHaveHappened();
            }
        }
    }
}
