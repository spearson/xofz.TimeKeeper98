namespace xofz.TimeKeeper98.Tests.Framework.Config
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class PromptUnselectedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new PromptUnselectedHandler(
                    this.web);
                this.settings = new GlobalSettingsHolder();
                this.saver = A.Fake<ConfigSaver>();
                this.ui = A.Fake<ConfigUi>();

                var w = this.web;
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.saver);
            }

            protected readonly MethodWeb web;
            protected readonly PromptUnselectedHandler handler;
            protected readonly GlobalSettingsHolder settings;
            protected readonly ConfigSaver saver;
            protected readonly ConfigUi ui;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void If_settings_Prompt_sets_it_to_false()
            {
                this.settings.Prompt = true;

                this.handler.Handle(
                    this.ui);

                Assert.False(
                    this.settings.Prompt);
            }

            [Fact]
            public void Also_calls_saver_Save()
            {
                this.settings.Prompt = true;

                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.saver.Save())
                    .MustHaveHappened();
            }
        }
    }
}
