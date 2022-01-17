namespace xofz.TimeKeeper98.Presentation.Presenters
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class TimestampEditPresenter 
        : Presenter
    {
        public TimestampEditPresenter(
            TimestampEditUi ui,
            ShellUi shell,
            MethodRunner runner)
            : base(ui, shell)
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
            r?.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            r?.Run<EventSubscriber>(subscriber =>
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

            r?.Run<Navigator>(nav => 
                nav.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var r = this.runner;
            r?.Run<Navigator>(nav =>
            {
                var hnUi = nav.GetUi<HomeNavPresenter, HomeNavUi>();
                var homeUi = nav.GetUi<HomePresenter, HomeUi>();

                r.Run<StartHandler>(handler =>
                {
                    handler.Handle(
                        this.ui,
                        hnUi,
                        homeUi);
                });
            });
            
        }

        public override void Stop()
        {
            var r = this.runner;
            r?.Run<Navigator>(nav =>
            {
                var homeUi = nav.GetUi<HomePresenter, HomeUi>();
                r.Run<StopHandler>(handler =>
                {
                    handler.Handle(homeUi);
                });
            });
        }

        private void ui_SaveKeyTapped()
        {
            var r = this.runner;
            r?.Run<SaveKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_SaveCurrentKeyTapped()
        {
            var r = this.runner;
            r?.Run<SaveCurrentKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_CancelKeyTapped()
        {
            var r = this.runner;
            r?.Run<CancelKeyTappedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private long setupIf1;
        private readonly TimestampEditUi ui;
        private readonly MethodRunner runner;
    }
}
