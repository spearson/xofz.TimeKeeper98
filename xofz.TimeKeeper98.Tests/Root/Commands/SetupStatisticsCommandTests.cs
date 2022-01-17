namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupStatisticsCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<StatisticsUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWeb();
                this.command = new SetupStatisticsCommand(
                    this.ui,
                    this.shell,
                    this.web);
                this.nav = A.Fake<Navigator>();

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly StatisticsUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWeb web;
            protected readonly SetupStatisticsCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_a_Timer()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<Timer>(
                        null,
                        DependencyNames.Timer));
            }

            [Fact]
            public void Registers_a_SetupHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SetupHandler>());
            }

            [Fact]
            public void Registers_a_StartHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StartHandler>());
            }

            [Fact]
            public void Registers_a_StopHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StopHandler>());
            }

            [Fact]
            public void Registers_a_CurrentWeekKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<CurrentWeekKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_PreviousWeekKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<PreviousWeekKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_NextWeekKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<NextWeekKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_DateChangedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<DateChangedHandler>());
            }

            [Fact]
            public void Registers_a_TimerHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<TimerHandler>());
            }

            [Fact]
            public void Registers_a_SettingsHolder()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SettingsHolder>());
            }

            [Fact]
            public void Throws_a_StatisticsPresenter_into_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<StatisticsPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
