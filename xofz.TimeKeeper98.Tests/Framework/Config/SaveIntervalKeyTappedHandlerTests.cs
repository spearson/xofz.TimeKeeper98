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

    public class SaveIntervalKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SaveIntervalKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<ConfigUi>();
                this.uiRW = new UiReaderWriter();
                this.settings = new GlobalSettingsHolder();
                this.saver = A.Fake<ConfigSaver>();
                this.timer = A.Fake<Timer>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.saver);
                w.RegisterDependency(
                    this.timer,
                    TimeKeeper98.Framework.Home.DependencyNames.Timer);
            }

            protected readonly MethodWeb web;
            protected readonly SaveIntervalKeyTappedHandler handler;
            protected readonly ConfigUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly GlobalSettingsHolder settings;
            protected readonly ConfigSaver saver;
            protected readonly Timer timer;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Accesses_ui_TimerIntervalSeconds()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.ui.TimerIntervalSeconds)
                    .MustHaveHappened();
            }

            [Fact]
            public void
                Sets_settings_TimerIntervalSeconds_to_ui_TimerIntervalSeconds()
            {
                this.settings.TimerIntervalSeconds = 0;
                this.ui.TimerIntervalSeconds = this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.ui.TimerIntervalSeconds,
                    this.settings.TimerIntervalSeconds);
            }

            [Fact]
            public void If_interval_less_than_1_sets_interval_to_1()
            {
                this.ui.TimerIntervalSeconds = 0;
                this.settings.TimerIntervalSeconds = this.fixture.Create<int>();

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    1,
                    this.settings.TimerIntervalSeconds);
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
            public void Stops_the_timer()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timer.Stop())
                    .MustHaveHappened();
            }

            [Fact]
            public void Starts_the_timer_with_interval_seconds()
            {
                var interval = this.fixture.Create<int>();
                this.ui.TimerIntervalSeconds = interval;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timer.Start(
                        interval * 1000))
                    .MustHaveHappened();
            }
        }
    }
}
