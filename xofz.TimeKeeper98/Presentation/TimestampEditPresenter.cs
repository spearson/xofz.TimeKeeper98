namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;

    public sealed class TimestampEditPresenter : Presenter
    {
        public TimestampEditPresenter(
            TimestampEditUi ui,
            ShellUi shell,
            MethodWeb web)
            : base(ui, shell)
        {
            this.ui = ui;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(
                    ref this.setupIf1, 
                    1, 
                    0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            w.Run<EventSubscriber>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveKeyTapped),
                    this.ui_SaveKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.CancelKeyTapped),
                    this.ui_CancelKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveCurrentKeyTapped),
                    this.ui_SaveCurrentKeyTapped);
            });

            w.Run<Navigator>(nav => nav.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            HomeNavUi hnUi = null;
            HomeUi homeUi = null;
            w.Run<Navigator>(nav =>
            {
                hnUi = nav.GetUi<HomeNavPresenter, HomeNavUi>();
                homeUi = nav.GetUi<HomePresenter, HomeUi>();
            });

            w.Run<StartHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    homeUi);
            });
        }

        public override void Stop()
        {
            var w = this.web;
            HomeUi homeUi = null;
            w.Run<Navigator>(nav =>
            {
                homeUi = nav.GetUi<HomePresenter, HomeUi>();
            });

            w.Run<StopHandler>(handler =>
            {
                handler.Handle(homeUi);
            });
        }

        private void ui_SaveKeyTapped()
        {
            var w = this.web;

            w.Run<SaveKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_SaveCurrentKeyTapped()
        {
            var w = this.web;

            w.Run<SaveCurrentKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_CancelKeyTapped()
        {
            var w = this.web;
            w.Run<CancelKeyTappedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private long setupIf1;
        private readonly TimestampEditUi ui;
        private readonly MethodWeb web;
    }
}
