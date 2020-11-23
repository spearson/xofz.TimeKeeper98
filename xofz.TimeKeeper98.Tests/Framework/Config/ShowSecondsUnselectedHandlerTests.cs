namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers;
    using Xunit;

    public class ShowSecondsUnselectedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.handler = new ShowSecondsUnselectedHandler(
                    this.web);
                this.settings = new GlobalSettingsHolder();
                this.saver = A.Fake<ConfigSaver>();
                this.refreshHome = A.Fake<Do>();
                this.refreshTimestamps = A.Fake<Do>();
                this.refreshDaily = A.Fake<Do>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.saver);
                w.RegisterDependency(
                    this.refreshHome,
                    MethodNames.RefreshHome);
                w.RegisterDependency(
                    this.refreshTimestamps,
                    MethodNames.RefreshTimestamps);
                w.RegisterDependency(
                    this.refreshDaily,
                    MethodNames.RefreshDaily);
            }

            protected MethodWebV2 web;
            protected ShowSecondsUnselectedHandler handler;
            protected readonly GlobalSettingsHolder settings;
            protected readonly ConfigSaver saver;
            protected readonly Do refreshHome, refreshTimestamps, refreshDaily;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Unregisters_a_PaddedTimeSpanViewer()
            {
                this.web = A.Fake<MethodWebV2>();
                this.handler = new ShowSecondsUnselectedHandler(
                    this.web);

                this.handler.Handle();

                A
                    .CallTo(() => this.web.Unregister<PaddedTimeSpanViewer>(
                        null))
                    .MustHaveHappened();
            }

            [Fact]
            public void Registers_a_MinutesPaddedTimeSpanViewer()
            {
                this.web = A.Fake<MethodWebV2>();
                this.handler = new ShowSecondsUnselectedHandler(
                    this.web);

                this.handler.Handle();

                A
                    .CallTo(() => this.web.RegisterDependency(
                        A<MinutesPaddedTimeSpanViewer>.Ignored,
                        null))
                    .MustHaveHappened();
            }

            [Fact]
            public void Unregisters_a_TimeSpanViewer()
            {
                this.web = A.Fake<MethodWebV2>();
                this.handler = new ShowSecondsUnselectedHandler(
                    this.web);

                this.handler.Handle();

                A
                    .CallTo(() => this.web.Unregister<TimeSpanViewer>(
                        null))
                    .MustHaveHappened();

            }

            [Fact]
            public void Registers_a_MinutesTimeSpanViewer()
            {
                this.web = A.Fake<MethodWebV2>();
                this.handler = new ShowSecondsUnselectedHandler(
                    this.web);

                this.handler.Handle();

                A
                    .CallTo(() => this.web.RegisterDependency(
                        A<MinutesPaddedTimeSpanViewer>.Ignored,
                        null))
                    .MustHaveHappened();
            }

            [Fact]
            public void If_settings_ShowSeconds_is_true_sets_it_to_false()
            {
                this.settings.ShowSeconds = true;

                this.handler.Handle();

                Assert.False(
                    this.settings.ShowSeconds);
            }

            [Fact]
            public void Also_calls_saver_Save()
            {
                this.settings.ShowSeconds = true;

                this.handler.Handle();

                A
                    .CallTo(() => this.saver.Save())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_refreshHome_Invoke()
            {
                this.handler.Handle();

                A
                    .CallTo(() => this.refreshHome.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_refreshTimestamps_Invoke()
            {
                this.handler.Handle();

                A
                    .CallTo(() => this.refreshTimestamps.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_refreshDaily_Invoke()
            {
                this.handler.Handle();

                A
                    .CallTo(() => this.refreshDaily.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
