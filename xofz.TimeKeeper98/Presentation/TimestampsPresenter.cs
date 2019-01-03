namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class TimestampsPresenter : Presenter
    {
        public TimestampsPresenter(
            TimestampsUi ui, 
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
            w.Run<SetupHandler>(handler =>
            {
                handler.Handle();
            });

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
                sub.Subscribe<bool>(
                    this.ui,
                    nameof(this.ui.ShowDurationChanged),
                    this.ui_ShowDurationChanged);
                w.Run<Navigator>(n =>
                {
                    var homeUi = n.GetUi<HomePresenter, HomeUi>();
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.InKeyTapped),
                        this.homeUi_InKeyTapped);
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.OutKeyTapped),
                        this.homeUi_OutKeyTapped);
                });
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            Interlocked.CompareExchange(
                ref this.startedIf1, 
                1, 
                0);

            base.Start();

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<StartHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi);
            });
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(
                ref this.startedIf1, 
                0, 
                1);
        }

        private void homeUi_InKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<HomeUiInKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi);
            });
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<HomeUiOutKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi);
            });
        }

        private void ui_CurrentKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<CurrentKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi);
            });
        }

        private void ui_StatisticsRangeKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<StatisticsRangeKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi);
            });
        }

        private void ui_ShowDurationChanged(bool shouldShow)
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            HomeNavUi hnUi = null;
            StatisticsUi statsUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                statsUi = n.GetUi<StatisticsPresenter, StatisticsUi>();
            });

            w.Run<ShowDurationsChangedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    hnUi,
                    statsUi,
                    shouldShow);
            });
        }

        private long 
            setupIf1, 
            startedIf1;
        private readonly TimestampsUi ui;
        private readonly MethodWeb web;
    }
}
