namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupConfigCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<ConfigUi>();
                this.shell = A.Fake<ShellUi>();
                this.web = new MethodWebV2();
                this.command = new SetupConfigCommand(
                    this.ui,
                    this.shell,
                    this.web);
                this.nav = A.Fake<Navigator>();
                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly ConfigUi ui;
            protected readonly ShellUi shell;
            protected readonly MethodWebV2 web;
            protected readonly SetupConfigCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
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
            public void Registers_a_ShowSecondsSelectedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ShowSecondsSelectedHandler>());
            }

            [Fact]
            public void Registers_a_ShowSecondsUnselectedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ShowSecondsUnselectedHandler>());
            }

            [Fact]
            public void Registers_a_SaveIntervalKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SaveIntervalKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_ResetIntervalKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ResetIntervalKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_PromptSelectedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<PromptSelectedHandler>());
            }

            [Fact]
            public void Registers_a_PromptUnselectedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<PromptUnselectedHandler>());
            }

            [Fact]
            public void Registers_a_SaveTitleTextKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SaveTitleTextKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_ResetTitleTextKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ResetTitleTextKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_DefaultTitleTextKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<DefaultTitleTextKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_KeyboardLoader()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<KeyboardLoader>());
            }

            [Fact]
            public void Registers_a_PublishKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<PublishKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_Core98Publisher()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<Core98Publisher>());
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
            public void Registers_a_RefreshConfig_Do()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<Do>(
                        null, 
                        MethodNames.RefreshConfig));
            }

            [Fact]
            public void Throws_a_ConfigPresenter_into_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<ConfigPresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
