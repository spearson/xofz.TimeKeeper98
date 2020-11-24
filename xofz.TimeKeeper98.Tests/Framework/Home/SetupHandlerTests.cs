namespace xofz.TimeKeeper98.Tests.Framework.Home
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.handler = new SetupHandler(
                    this.web);
                this.ui = A.Fake<HomeUi>();
                this.uiRW = new UiReaderWriter();
                this.calc = A.Fake<StatisticsCalculator>();
                this.reader = A.Fake<TimestampReader>();
                this.virginReader = A.Fake<VersionReader>();
                this.shell = A.Fake<TitleUi>();
                this.settings = new GlobalSettingsHolder();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.calc);
                w.RegisterDependency(
                    this.reader);
                w.RegisterDependency(
                    this.virginReader);
                w.RegisterDependency(
                    this.shell);
                w.RegisterDependency(
                    this.settings);
            }

            protected readonly MethodWebV2 web;
            protected readonly SetupHandler handler;
            protected readonly HomeUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly StatisticsCalculator calc;
            protected readonly TimestampReader reader;
            protected VersionReader virginReader;
            protected readonly TitleUi shell;
            protected readonly GlobalSettingsHolder settings;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_calc_ClockedIn()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.calc.ClockedIn())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_reader_Read()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.reader.Read())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_InKeyVisible()
            {
                var inIt = this.fixture.Create<bool>();
                A
                    .CallTo(() => this.calc.ClockedIn())
                    .Returns(inIt);

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    !inIt,
                    this.ui.InKeyVisible);
            }

            [Fact]
            public void Sets_OutKeyVisible()
            {
                var outIt = this.fixture.Create<bool>();
                A
                    .CallTo(() => this.calc.ClockedIn())
                    .Returns(outIt);

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    outIt,
                    this.ui.OutKeyVisible);
            }

            [Fact]
            public void Sets_editKeyEnabled_to_true_if_at_least_one()
            {
                A
                    .CallTo(() => this.reader.Read())
                    .Returns(new[] {this.fixture.Create<DateTime>()});
                this.ui.EditKeyEnabled = false;

                this.handler.Handle(
                    this.ui);

                Assert.True(
                    this.ui.EditKeyEnabled);
            }

            [Fact]
            public void False_otherwise()
            {
                this.ui.EditKeyEnabled = true;

                this.handler.Handle(
                    this.ui);

                Assert.False(
                    this.ui.EditKeyEnabled);
            }

            [Fact]
            public void Calls_versionReader_Read()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.virginReader.Read())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_versionReader_ReadCoreVersion()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.virginReader.ReadCoreVersion())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_Version()
            {
                this.virginReader = new VersionReader();
                var w = this.web;
                w.Unregister<VersionReader>();
                w.RegisterDependency(
                    this.virginReader);
                this.ui.Version = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.Version);
            }

            [Fact]
            public void Sets_ui_CoreVersion()
            {
                this.virginReader = new VersionReader();
                var w = this.web;
                w.Unregister<VersionReader>();
                w.RegisterDependency(
                    this.virginReader);
                this.ui.CoreVersion = null;

                this.handler.Handle(
                    this.ui);

                Assert.NotNull(
                    this.ui.CoreVersion);
            }

            [Fact]
            public void Sets_shell_Title_to_settings_TittieText()
            {
                this.settings.TitleText = this.fixture.Create<string>();
                this.shell.Title = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.settings.TitleText,
                    this.shell.Title);
            }
        }
    }
}
