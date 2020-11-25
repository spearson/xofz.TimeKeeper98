namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Daily;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupDailyCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<DailyUi>();
                this.shell = A.Fake<ShellUi>();
                this.uiReader = A.Fake<UiReader>();
                this.web = new MethodWeb();
                this.nav = A.Fake<Navigator>();
                this.command = new SetupDailyCommand(
                    this.ui,
                    this.shell,
                    this.uiReader,
                    this.web);

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly DailyUi ui;
            protected readonly ShellUi shell;
            protected readonly UiReader uiReader;
            protected readonly MethodWeb web;
            protected SetupDailyCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_a_UiReader()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<UiReader>());
            }

            [Fact]
            public void Registers_a_SettingsHolder()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SettingsHolder>());
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
            public void Registers_a_CurrentKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<CurrentKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_StatisticsRangeKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StatisticsRangeKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_HomeUiOutKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<HomeUiOutKeyTappedHandler>());
            }

            [Fact]
            public void Throws_a_DailyPresenter_into_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<DailyPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
