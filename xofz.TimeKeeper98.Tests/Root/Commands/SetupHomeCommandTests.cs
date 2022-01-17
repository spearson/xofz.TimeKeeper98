namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using System;
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers;
    using xofz.TimeKeeper98.Framework.TimeSpanViewers;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupHomeCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<HomeUi>();
                this.shell = A.Fake<ShellUi>();
                this.readerWriter = A.Fake<TimestampReaderWriter>();
                this.dataWatcher = A.Fake<DataWatcher>();
                this.web = new MethodWeb();
                this.command = new SetupHomeCommand(
                    this.ui,
                    this.shell,
                    r => this.readerWriter,
                    web => this.dataWatcher,
                    this.web);
                this.nav = A.Fake<Navigator>();

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly HomeUi ui;
            protected readonly ShellUi shell;

            protected readonly TimestampReaderWriter
                readerWriter;

            protected readonly DataWatcher dataWatcher;
            protected readonly MethodWeb web;
            protected readonly SetupHomeCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_a_DateCalculator()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<DateCalculator>());
            }

            [Fact]
            public void Registers_an_EnumerableTrapper_DateTime()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EnumerableTrapper<DateTime>>());
            }

            [Fact]
            public void Registers_a_TimestampReaderWriter()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<TimestampReaderWriter>());
            }

            [Fact]
            public void Registers_a_FieldHolder()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<FieldHolder>());
            }

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
            public void Registers_a_MinutesTimeSpanViewer()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<MinutesTimeSpanViewer>());
            }

            [Fact]
            public void Registers_a_MinutesPaddedTimeSpanViewer()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<MinutesPaddedTimeSpanViewer>());
            }

            [Fact]
            public void Registers_a_StatisticsCalculator()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<StatisticsCalculator>());
            }

            [Fact]
            public void Registers_a_VersionReader()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<VersionReader>());
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
            public void Registers_an_InKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<InKeyTappedHandler>());
            }

            [Fact]
            public void Registers_an_OutKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<OutKeyTappedHandler>());
            }

            [Fact]
            public void Registers_an_EditKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<EditKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_TimerHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<TimerHandler>());
            }

            [Fact]
            public void Registers_a_LatchHolder()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<LatchHolder>(
                        null,
                        DependencyNames.Latch));
            }

            [Fact]
            public void Throws_a_HomePresenter_in_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() =>
                        this.nav.RegisterPresenter(
                            A<HomePresenter>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_Setup_on_a_DataWatcher()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.dataWatcher.Setup())
                    .MustHaveHappened();
            }
        }
    }
}
