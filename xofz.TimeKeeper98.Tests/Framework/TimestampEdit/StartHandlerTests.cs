namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class StartHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StartHandler(
                    this.web);
                this.ui = A.Fake<TimestampEditUi>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.homeUi = A.Fake<HomeUi>();
                this.uiRW = new UiReaderWriter();
                this.reader = A.Fake<TimestampReader>();
                this.settings = new SettingsHolder();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.reader);
                w.RegisterDependency(
                    this.settings);
            }

            protected readonly MethodWeb web;
            protected readonly StartHandler handler;
            protected readonly TimestampEditUi ui;
            protected readonly HomeNavUi homeNavUi;
            protected readonly HomeUi homeUi;
            protected readonly UiReaderWriter uiRW;
            protected readonly TimestampReader reader;
            protected readonly SettingsHolder settings;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Calls_reader_ReadAll()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.homeUi);

                A
                    .CallTo(() => this.reader.ReadAll())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_EditedTimestamp()
            {
                var timestamp = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(new[] {timestamp});
                this.ui.EditedTimestamp = DateTime.MinValue;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.homeUi);

                Assert.Equal(
                    timestamp,
                    this.ui.EditedTimestamp);
            }

            [Fact]
            public void Sets_settings_LastVisitedKeyLabel_to_ActiveKeyLabel()
            {
                this.settings.LastVisitedKeyLabel = null;
                var activeLabel = this.fixture.Create<string>();
                this.homeNavUi.ActiveKeyLabel = activeLabel;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.homeUi);

                Assert.Equal(
                    activeLabel,
                    this.settings.LastVisitedKeyLabel);
            }

            [Fact]
            public void Sets_homeUi_Editing_to_true()
            {
                this.homeUi.Editing = false;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.homeUi);

                Assert.True(
                    this.homeUi.Editing);
            }
        }
    }
}
