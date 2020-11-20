namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class HomeNavPresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.ui = A.Fake<HomeNavUi>();
                this.presenter = new HomeNavPresenter(
                    this.ui,
                    A.Fake<ShellUi>(),
                    this.web);
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.statsHandler = A.Fake<StatisticsKeyTappedHandler>();
                this.timestampsHandler = A.Fake<TimestampsKeyTappedHandler>();
                this.dailyHandler = A.Fake<DailyKeyTappedHandler>();
                this.configHandler = A.Fake<ConfigKeyTappedHandler>();
                this.exitHandler = A.Fake<ExitKeyTappedHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    this.statsHandler);
                w.RegisterDependency(
                    this.timestampsHandler);
                w.RegisterDependency(
                    this.dailyHandler);
                w.RegisterDependency(
                    this.configHandler);
                w.RegisterDependency(
                    this.exitHandler);
            }

            protected readonly MethodWebV2 web;
            protected readonly HomeNavUi ui;
            protected readonly HomeNavPresenter presenter;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly StatisticsKeyTappedHandler statsHandler;
            protected readonly TimestampsKeyTappedHandler timestampsHandler;
            protected readonly DailyKeyTappedHandler dailyHandler;
            protected readonly ConfigKeyTappedHandler configHandler;
            protected readonly ExitKeyTappedHandler exitHandler;
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
            public void Subscribes_to_StatisticsKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.StatisticsKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_TimestampsKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.TimestampsKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_DailyKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.DailyKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ConfigKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ConfigKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_ExitKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.ExitKeyTapped),
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

        public class When_the_stats_key_is_tapped : Context
        {
            [Fact]
            public void Calls_statsHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.StatisticsKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.statsHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_timestamps_key_is_tapped : Context
        {
            [Fact]
            public void Calls_timestampsHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.TimestampsKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.timestampsHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_daily_key_is_tapped : Context
        {
            [Fact]
            public void Calls_dailyHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.DailyKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.dailyHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_config_key_is_tapped : Context
        {
            [Fact]
            public void Calls_configHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.ConfigKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.configHandler.Handle())
                    .MustHaveHappened();
            }
        }

        public class When_the_exit_key_is_tapped : Context
        {
            [Fact]
            public void Calls_exitHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.ExitKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.exitHandler.Handle())
                    .MustHaveHappened();
            }
        }
    }
}
