namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupTimestampsCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<TimestampsUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWeb();
                this.command = new SetupTimestampsCommand(
                    this.ui,
                    this.shell,
                    this.web);
                this.nav = A.Fake<Navigator>();

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly TimestampsUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWeb web;
            protected readonly SetupTimestampsCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_an_EnumerableSplitter()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EnumerableSplitter>());
            }

            [Fact]
            public void Registers_an_EnumerableSplicer()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EnumerableSplicer>());
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
            public void Registers_a_SettingsHolder()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SettingsHolder>());
            }

            [Fact]
            public void Registers_a_HomeUiInKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<HomeUiInKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_HomeUiOutKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<HomeUiOutKeyTappedHandler>());
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
            public void Registers_a_ShowDurationsChangedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ShowDurationsChangedHandler>());
            }

            [Fact]
            public void Throws_a_TimestampsPresenter_into_the_web()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<TimestampsPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
