namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Statistics;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class StatisticsPresenter : Presenter
    {
        public StatisticsPresenter(
            StatisticsUi ui,
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
                handler.Handle(this.ui);
            });

            w.Run<EventSubscriber>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.DateChanged),
                    this.ui_DateChanged);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.CurrentWeekKeyTapped),
                    this.ui_CurrentWeekKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.PreviousWeekKeyTapped),
                    this.ui_PreviousWeekKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.NextWeekKeyTapped),
                    this.ui_NextWeekKeyTapped);
                w.Run<xofz.Framework.Timer>(t =>
                    {
                        subscriber.Subscribe(
                            t,
                            nameof(t.Elapsed),
                            this.timer_Elapsed);
                    },
                    "StatisticsTimer");
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            var w = this.web;

            base.Start();

            HomeNavUi hnUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            w.Run<StartHandler>(handler =>
            {
                handler.Handle(hnUi);
            });
        }

        public override void Stop()
        {
            var w = this.web;
            w.Run<StopHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_CurrentWeekKeyTapped()
        {
            var w = this.web;
            w.Run<CurrentWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_PreviousWeekKeyTapped()
        {
            var w = this.web;
            w.Run<PreviousWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_NextWeekKeyTapped()
        {
            var w = this.web;
            w.Run<NextWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_DateChanged()
        {
            var w = this.web;
            w.Run<DateChangedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void timer_Elapsed()
        {
            var w = this.web;
            w.Run<TimerHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private long setupIf1;
        private readonly StatisticsUi ui;
        private readonly MethodWeb web;
    }
}
