namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SetupHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SetupHandler(
                    this.web);
                this.ui = A.Fake<TimestampEditUi>();
                this.settings = new GlobalSettingsHolder();
                this.uiRW = new UiReaderWriter();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly SetupHandler handler;
            protected readonly TimestampEditUi ui;
            protected readonly GlobalSettingsHolder settings;
            protected readonly UiReaderWriter uiRW;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_ui_TimestampFormat_to_settings_EditTimestampFormat()
            {
                this.settings.EditTimestampFormat = this.fixture.Create<string>();
                this.ui.TimestampFormat = null;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    this.settings.EditTimestampFormat,
                    this.ui.TimestampFormat);
            }
        }
    }
}
