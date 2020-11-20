namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class LicensePresenterTests
    {
        public class Context
        {
            protected Context()
            {
                this.ui = A.Fake<LicenseUi>();
                this.web = new MethodWebV2();
                this.presenter = new LicensePresenter(
                    this.ui,
                    this.web);
                this.sub = new EventSubscriber();
                this.nav = A.Fake<Navigator>();
                this.acceptHandler = A.Fake<AcceptKeyTappedHandler>();
                this.rejectHandler = A.Fake<RejectKeyTappedHandler>();

                var w = this.web;
                w.RegisterDependency(
                    this.sub);
                w.RegisterDependency(
                    this.acceptHandler);
                w.RegisterDependency(
                    this.rejectHandler);
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly LicenseUi ui;
            protected readonly MethodWebV2 web;
            protected readonly LicensePresenter presenter;
            protected EventSubscriber sub;
            protected readonly Navigator nav;
            protected readonly AcceptKeyTappedHandler acceptHandler;
            protected readonly RejectKeyTappedHandler rejectHandler;
        }

        public class When_Setup_is_called : Context
        {
            public When_Setup_is_called()
            {
                this.sub = A.Fake<EventSubscriber>();
                var w = this.web;
                w.Unregister<EventSubscriber>();
                w.RegisterDependency(
                    this.sub);
            }

            [Fact]
            public void Subscribes_to_AcceptKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.AcceptKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Subscribes_to_RejectKeyTapped()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.sub.Subscribe(
                        this.ui,
                        nameof(this.ui.RejectKeyTapped),
                        A<Do>.Ignored))
                    .MustHaveHappened();
            }

            [Fact]
            public void Registers_itself_with_the_Navigator()
            {
                this.presenter.Setup();

                A
                    .CallTo(() => this.nav.RegisterPresenter(
                        this.presenter))
                    .MustHaveHappened();
            }
        }

        public class When_the_accept_key_is_tapped : Context
        {
            [Fact]
            public void Calls_acceptHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.AcceptKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.acceptHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }

        public class When_the_reject_key_is_tapped : Context
        {
            [Fact]
            public void Calls_rejectHandler_Handle()
            {
                this.presenter.Setup();

                this.ui.RejectKeyTapped += Raise.FreeForm.With();

                A
                    .CallTo(() => this.rejectHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
