namespace xofz.TimeKeeper98.Tests.Framework.Home
{
    using System.Threading;
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;
    using Timer = xofz.Framework.Timer;

    public class InKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new InKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<HomeUi>();
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.messenger = A.Fake<Messenger>();
                this.timer = A.Fake<Timer>();
                this.timerLatch = A.Fake<LatchHolder>();
                this.writer = A.Fake<TimestampWriter>();
                this.watcher = A.Fake<DataWatcher>();
                this.startHandler = A.Fake<StartHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.messenger);
                w.RegisterDependency(
                    this.timer,
                    DependencyNames.Timer);
                w.RegisterDependency(
                    this.timerLatch,
                    DependencyNames.Latch);
                w.RegisterDependency(
                    this.writer);
                w.RegisterDependency(
                    this.watcher);
                w.RegisterDependency(
                    this.startHandler);

                A
                    .CallTo(() => this.messenger.Question(
                        A<string>.Ignored))
                    .Returns(Response.Yes);
                A
                    .CallTo(() => this.timerLatch.Latch)
                    .Returns(new ManualResetEvent(true));
            }

            protected readonly MethodWeb web;
            protected readonly InKeyTappedHandler handler;
            protected readonly HomeUi ui;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly Messenger messenger;
            protected readonly Timer timer;
            protected readonly LatchHolder timerLatch;
            protected readonly TimestampWriter writer;
            protected readonly DataWatcher watcher;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void If_Prompt_asks_question()
            {
                this.settings.Prompt = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.messenger.Question(
                        A<string>.Ignored))
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
            public void Touches_the_timer_latch()
            {
                // to wait on it
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.timerLatch.Latch)
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_InKeyVisible_to_false()
            {
                this.ui.InKeyVisible = true;

                this.handler.Handle(
                    this.ui);

                Assert.False(
                    this.ui.InKeyVisible);
            }

            [Fact]
            public void Calls_watcher_Stop()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.watcher.Stop())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_writer_Write()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.writer.Write())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_watcher_Start()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.watcher.Start())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_startHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
