namespace xofz.TimeKeeper98.Presentation
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
            MethodWeb web) 
            : base(ui)
        {
            this.ui = ui;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<EventSubscriber>(sub =>
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

            w.Run<Navigator>(nav => nav.RegisterPresenter(this));
        }

        private void ui_AcceptKeyTapped()
        {
            var w = this.web;
            w.Run<AcceptKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_RejectKeyTapped()
        {
            var w = this.web;
            w.Run<RejectKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private long setupIf1;
        private readonly LicenseUi ui;
        private readonly MethodWeb web;
    }
}
