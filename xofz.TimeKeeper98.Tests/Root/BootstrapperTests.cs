namespace xofz.TimeKeeper98.Tests.Root
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Framework.Lotters;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class BootstrapperTests
    {
        public class Context
        {
            protected Context()
            {
                this.executor = A.Fake<CommandExecutor>();
                this.bootstrapper = new TestBootstrapper(
                    this.executor);
                this.web = new MethodWebV2();
                this.nav = A.Fake<Navigator>();
                this.fixture = new Fixture();

                var command = A.Fake<SetupMethodWebCommand>();
                A
                    .CallTo(() => this.executor.Get<SetupMethodWebCommand>())
                    .Returns(command);
                A
                    .CallTo(() => command.W)
                    .Returns(this.web);

                var w = this.web;
                w.RegisterDependency(
                    new UiReaderWriter());
                w.RegisterDependency(
                    new LinkedListLotter());
                w.RegisterDependency(
                    this.nav);
                w.RegisterDependency(
                    ((Do<Do>)(act => act.Invoke())));
            }

            protected readonly CommandExecutor executor;
            protected readonly TestBootstrapper bootstrapper;
            protected readonly MethodWebV2 web;
            protected readonly Navigator nav;
            protected readonly Fixture fixture;
        }

        public class TestBootstrapper
            : Bootstrapper
        {
            public TestBootstrapper(
                CommandExecutor executor)
                : base(executor)
            {
            }

            public virtual void HandleException(
                UnhandledExceptionEventArgs args)
            {
                base.handleException(
                    null,
                    args);
            }
        }

        public class When_Bootstrap_is_called : Context
        {
            [Fact]
            public void Executes_a_SetupMethodWebCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupMethodWebCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_currentDomain_UnhandledException()
            {
                var sub = A.Fake<EventSubscriber>();
                this.web.RegisterDependency(
                    sub);

                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => sub.Subscribe(
                        A<AppDomain>.Ignored,
                        nameof(A<AppDomain>.Ignored.UnhandledException),
                        A<UnhandledExceptionEventHandler>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Registers_a_TimeKeeperShellUi()
            {
                this.bootstrapper.Bootstrap();

                Assert.NotNull(
                    this.web.Run<TimeKeeperShellUi>());
            }

            [Fact]
            public void Executes_a_SetupHomeCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupHomeCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupHomeNavCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupHomeNavCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupStatisticsCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupStatisticsCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupTimestampEditCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupTimestampEditCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupMainCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupMainCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupShutdownCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupShutdownCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupLicenseCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupLicenseCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupTimestampsCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupTimestampsCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupDailyCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupDailyCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_manager_ConvertToSingleFile()
            {
                var manager = A.Fake<FileTimestampManager>();
                this.web.RegisterDependency(
                    manager);

                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => manager.ConvertToSingleFile())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_watcher_Start()
            {
                var watcher = A.Fake<DataWatcher>();
                this.web.RegisterDependency(
                    watcher);

                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => watcher.Start())
                    .MustHaveHappened();
            }

            [Fact]
            public void Presents_a_HomePresenter()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.nav.Present<HomePresenter>())
                    .MustHaveHappened();
            }

            [Fact]
            public void Presents_a_HomeNavPresenter_fluidly()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.nav.PresentFluidly<HomeNavPresenter>())
                    .MustHaveHappened();
            }

            [Fact]
            public void Presents_a_TimestampsPresenter_fluidly()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(
                        () => this.nav.PresentFluidly<TimestampsPresenter>())
                    .MustHaveHappened();
            }

            [Fact]
            public void Executes_a_SetupConfigCommand()
            {
                this.bootstrapper.Bootstrap();

                A
                    .CallTo(() => this.executor.Execute(
                        A<SetupConfigCommand>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Unhandled_exceptions_are_logged()
            {
                var w = this.web;
                var le = A.Fake<LogEditor>();
                w.RegisterDependency(
                    le,
                    LogNames.Exceptions);

                this.bootstrapper.HandleException(
                    this.fixture.Create<UnhandledExceptionEventArgs>());
                A
                    .CallTo(() => le.AddEntry(
                        DefaultEntryTypes.Error,
                        A<IEnumerable<string>>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
