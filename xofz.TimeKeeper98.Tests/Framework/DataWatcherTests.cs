namespace xofz.TimeKeeper98.Tests.Framework
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using Xunit;

    public class DataWatcherTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.watcher = new PingingDataWatcher(this.web);
                this.fields = new FieldHolder();
                this.refreshHome = A.Fake<Do>();
                this.refreshTimestamps = A.Fake<Do>();
                this.refreshDaily = A.Fake<Do>();
                this.refreshConfig = A.Fake<Do>();

                var w = this.web;
                w.RegisterDependency(
                    this.refreshHome,
                    MethodNames.RefreshHome);
                w.RegisterDependency(
                    this.refreshTimestamps,
                    MethodNames.RefreshTimestamps);
                w.RegisterDependency(
                    this.refreshDaily,
                    MethodNames.RefreshDaily);
                w.RegisterDependency(
                    this.refreshConfig,
                    MethodNames.RefreshConfig);
                w.RegisterDependency(
                    this.fields);
            }

            protected readonly MethodWeb web;
            protected readonly PingingDataWatcher watcher;
            protected readonly FieldHolder fields;
            protected readonly Do refreshHome;
            protected readonly Do refreshTimestamps;
            protected readonly Do refreshDaily;
            protected readonly Do refreshConfig;
        }

        public class PingingDataWatcher : DataWatcher
        {
            public PingingDataWatcher(
                MethodRunner runner) 
                : base(runner)
            {
            }

            public override void Start()
            {
            }

            public override void Stop()
            {
            }

            public void Pinging()
            {
                this.pingApp();
            }
        }

        public class When_app_is_pinged : Context
        {
            [Fact]
            public void Swaps_needToTrapIf1_to_1()
            {
                this.fields.needToTrapIf1 = 0;
                this.watcher.Pinging();

                Assert.Equal(
                    1,
                    this.fields.needToTrapIf1);
            }

            [Fact]
            public void Invokes_refreshHome()
            {
                this.watcher.Pinging();

                A
                    .CallTo(() => this.refreshHome.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_refreshTimestamps()
            {
                this.watcher.Pinging();

                A
                    .CallTo(() => this.refreshTimestamps.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_refreshDaily()
            {
                this.watcher.Pinging();

                A
                    .CallTo(() => this.refreshDaily.Invoke())
                    .MustHaveHappened();
            }

            [Fact]
            public void Invokes_refreshConfig()
            {
                this.watcher.Pinging();

                A
                    .CallTo(() => this.refreshConfig.Invoke())
                    .MustHaveHappened();
            }
        }
    }
}
