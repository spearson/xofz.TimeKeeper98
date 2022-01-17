namespace xofz.TimeKeeper98.Presentation.Presenters
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.License;
    using xofz.TimeKeeper98.UI;

    public sealed class LicensePresenter 
        : PopupPresenter
    {
        public LicensePresenter(
            LicenseUi ui,
            MethodRunner runner) 
            : base(ui)
        {
            this.ui = ui;
            this.runner = runner;
        }

        public void Setup()
        {
            const byte one = 1;
            if (Interlocked.Exchange(
                    ref this.setupIf1, 
                    one) == one)
            {
                return;
            }

            var r = this.runner;
            r?.Run<EventSubscriber>(sub =>
            {
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.AcceptKeyTapped),
                    this.ui_AcceptKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.RejectKeyTapped),
                    this.ui_RejectKeyTapped);
            });

            r?.Run<Navigator>(nav => 
                nav.RegisterPresenter(this));
        }

        private void ui_AcceptKeyTapped()
        {
            var r = this.runner;
            r?.Run<AcceptKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_RejectKeyTapped()
        {
            var r = this.runner;
            r?.Run<RejectKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private long setupIf1;
        private readonly LicenseUi ui;
        private readonly MethodRunner runner;
    }
}
