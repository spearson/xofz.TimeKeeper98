namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Daily;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class DailyPresenter : Presenter
    {
        public DailyPresenter(
            DailyUi ui, 
            ShellUi shell,
            MethodWeb web) 
            : base(ui, shell)
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
                    nameof(this.ui.CurrentKeyTapped),
                    this.ui_CurrentKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.StatisticsRangeKeyTapped),
                    this.ui_StatisticsRangeKeyTapped);
                w.Run<Navigator>(n =>
                {
                    var homeUi = n.GetUi<HomePresenter, HomeUi>();
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.OutKeyTapped),
                        this.homeUi_OutKeyTapped);
                });
            });

            w.Run<SetupHandler>(handler =>
            {
                handler.Handle();
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            StatisticsUi statsUi = null;
            HomeNavUi hnUi = null;
            w.Run<Navigator>(n =>
            {
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            w.Run<StartHandler>(handler =>
                handler.Handle(
                    this.ui,
                    statsUi,
                    hnUi));
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(
                ref this.startedIf1, 
                0, 
                1);
        }

        private void ui_CurrentKeyTapped()
        {
            var w = this.web;
            StatisticsUi statsUi = null;
            HomeNavUi hnUi = null;
            w.Run<Navigator>(n =>
            {
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            w.Run<CurrentKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    statsUi,
                    hnUi);
            });
        }

        private void ui_StatisticsRangeKeyTapped()
        {
            var w = this.web;
            StatisticsUi statsUi = null;
            HomeNavUi hnUi = null;
            w.Run<Navigator>(n =>
            {
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            w.Run<StatisticsRangeKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    statsUi,
                    hnUi);
            });
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            StatisticsUi statsUi = null;
            HomeNavUi hnUi = null;
            w.Run<Navigator>(n =>
            {
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            w.Run<HomeUiOutKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    statsUi,
                    hnUi);
            });
        }

        private long setupIf1, startedIf1;
        private readonly DailyUi ui;
        private readonly MethodWeb web;
    }
}
