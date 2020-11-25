namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupHomeNavCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<HomeNavUi>();
                this.shell = A.Fake<ShellUi>();
                this.reader = A.Fake<NavLogicReader>();
                this.web = new MethodWeb();
                this.command = new SetupHomeNavCommand(
                    this.ui,
                    this.shell,
                    this.reader,
                    this.web);
                this.nav = A.Fake<Navigator>();
                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly HomeNavUi ui;
            protected readonly ShellUi shell;
            protected readonly NavLogicReader reader;
            protected readonly MethodWeb web;
            protected readonly SetupHomeNavCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_the_NavLogicReader()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<NavLogicReader>());
            }

            [Fact]
            public void Registers_a_TimestampsKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<TimestampsKeyTappedHandler>());

            }

            [Fact]
            public void Registers_a_StatisticsKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StatisticsKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_DailyKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<DailyKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_ConfigKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ConfigKeyTappedHandler>());
            }

            [Fact]
            public void Registers_an_ExitKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ExitKeyTappedHandler>());
            }

            [Fact]
            public void Throws_a_HomeNavPresenter_into_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<HomeNavPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
