namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Root;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.UI;
    using Xunit;

    public class SetupMethodWebCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.messenger = A.Fake<Messenger>();
                this.saver = A.Fake<ConfigSaver>();
                this.provider = A.Fake<SettingsProvider>();
                this.command = new SetupMethodWebCommand(
                    this.web,
                    this.messenger,
                    r => this.saver,
                    r => this.provider);
            }

            protected readonly MethodWebV2 web;
            protected readonly Messenger messenger;
            protected readonly ConfigSaver saver;
            protected readonly SettingsProvider provider;
            protected readonly SetupMethodWebCommand command;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_a_UiReaderWriter()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<UiReaderWriter>());
            }

            [Fact]
            public void Registers_a_NavigatorV2()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<NavigatorV2>());
            }

            [Fact]
            public void Registers_a_messenger()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<Messenger>());
            }

            [Fact]
            public void Registers_an_EventRaiser()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EventRaiser>());
            }

            [Fact]
            public void Registers_a_Lotter()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<Lotter>());
            }

            [Fact]
            public void Registers_an_EventSubscriber()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EventSubscriber>());
            }

            [Fact]
            public void Registers_the_SettingsProvider()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<SettingsProvider>());
                Assert.Same(
                    this.provider,
                    this.web.Run<SettingsProvider>());
            }

            [Fact]
            public void Registers_the_result_of_provider_Provide()
            {
                var settings = new GlobalSettingsHolder();
                A
                    .CallTo(() => this.provider.Provide())
                    .Returns(settings);

                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<GlobalSettingsHolder>());
                Assert.Same(
                    settings,
                    this.web.Run<GlobalSettingsHolder>());
            }

            [Fact]
            public void Registers_the_ConfigSaver()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<ConfigSaver>());
                Assert.Same(
                    this.saver,
                    this.web.Run<ConfigSaver>());
            }

            [Fact]
            public void Registers_an_exceptions_LogEditor()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<LogEditor>(
                        null,
                        LogNames.Exceptions));
            }

            [Fact]
            public void Registers_a_TimeProvider()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<TimeProvider>());
            }
        }
    }
}
