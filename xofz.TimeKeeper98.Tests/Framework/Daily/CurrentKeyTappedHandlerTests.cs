namespace xofz.TimeKeeper98.Tests.Framework.Daily
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Daily;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class CurrentKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new CurrentKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<DailyUi>();
                this.settings = new SettingsHolder();
                this.startHandler = A.Fake<StartHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.startHandler);
            }

            protected readonly MethodWeb web;
            protected readonly CurrentKeyTappedHandler handler;
            protected readonly DailyUi ui;
            protected readonly SettingsHolder settings;
            protected readonly StartHandler startHandler;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_settings_ShowCurrent_to_true()
            {
                this.settings.ShowCurrent = false;

                this.handler.Handle(
                    this.ui);

                Assert.True(
                    this.settings.ShowCurrent);
            }

            [Fact]
            public void Calls_startHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.startHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
