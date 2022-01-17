namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupTimestampEditCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<TimestampEditUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWeb();
                this.nav = A.Fake<Navigator>();
                this.command = new SetupTimestampEditCommand(
                    this.ui,
                    this.shell,
                    this.web);

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly TimestampEditUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWeb web;
            protected readonly Navigator nav;
            protected readonly SetupTimestampEditCommand command;
        }

        public class When_Execute_is_called : Context
        {
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
            public void Registers_a_StopHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StopHandler>());
            }

            [Fact]
            public void Registers_a_SaveKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SaveKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_CancelKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<CancelKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_SaveCurrentKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SaveCurrentKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_TimestampEditPresenter_with_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<TimestampEditPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
