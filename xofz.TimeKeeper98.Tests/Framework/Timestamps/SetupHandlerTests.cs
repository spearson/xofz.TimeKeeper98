namespace xofz.TimeKeeper98.Tests.Framework.Timestamps
{
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
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
                this.settings = new SettingsHolder();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
            }

            protected readonly MethodWeb web;
            protected readonly SetupHandler handler;
            protected readonly SettingsHolder settings;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Sets_settings_ShowCurrent_to_true()
            {
                this.settings.ShowCurrent = false;

                this.handler.Handle();

                Assert.True(this.settings.ShowCurrent);
            }
        }
    }
}
