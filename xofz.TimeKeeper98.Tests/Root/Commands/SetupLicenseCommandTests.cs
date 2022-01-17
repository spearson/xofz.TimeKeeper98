namespace xofz.TimeKeeper98.Tests.Root.Commands
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class SetupLicenseCommandTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<LicenseUi>();
                this.web = new MethodWeb();
                this.command = new SetupLicenseCommand(
                    this.ui,
                    this.web);
                this.nav = A.Fake<Navigator>();
                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly LicenseUi ui;
            protected readonly MethodWeb web;
            protected readonly SetupLicenseCommand command;
            protected readonly Navigator nav;
        }

        public class When_Execute_is_called : Context
        {
            [Fact]
            public void Registers_an_AcceptKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<AcceptKeyTappedHandler>());
            }

            [Fact]
            public void Registers_a_RejectKeyTappedHandler()
            {
                this.command.Execute();

                Assert.NotNull(
                    this.web.Run<RejectKeyTappedHandler>());
            }

            [Fact]
            public void Throws_a_LicensePresenter_into_the_nav()
            {
                this.command.Execute();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        A<LicensePresenter>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
