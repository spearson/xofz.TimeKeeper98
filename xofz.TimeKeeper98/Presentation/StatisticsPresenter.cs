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
            MethodRunner runner)
            : base(ui, shell)
        {
            this.ui = ui;
            this.runner = runner;
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

            var r = this.runner;
            r.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
            r.Run<EventSubscriber>(subscriber =>
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
                r.Run<xofz.Framework.Timer>(t =>
                    {
                        subscriber.Subscribe(
                            t,
                            nameof(t.Elapsed),
                            this.timer_Elapsed);
                    },
                    DependencyNames.Timer);
            });

            r.Run<Navigator>(nav =>
                nav.RegisterPresenter(this));
        }

        public override void Start()
        {
            var r = this.runner;

            base.Start();

            HomeNavUi hnUi = null;
            r.Run<Navigator>(nav =>
            {
                hnUi = nav.GetUi<HomeNavPresenter, HomeNavUi>();
            });

            r.Run<StartHandler>(handler =>
            {
                handler.Handle(hnUi);
            });
        }

        public override void Stop()
        {
            var r = this.runner;
            r.Run<StopHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_CurrentWeekKeyTapped()
        {
            var r = this.runner;
            r.Run<CurrentWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_PreviousWeekKeyTapped()
        {
            var r = this.runner;
            r.Run<PreviousWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_NextWeekKeyTapped()
        {
            var r = this.runner;
            r.Run<NextWeekKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_DateChanged()
        {
            var r = this.runner;
            r.Run<DateChangedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void timer_Elapsed()
        {
            var r = this.runner;
            r.Run<TimerHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private long setupIf1;
        private readonly StatisticsUi ui;
        private readonly MethodRunner runner;
    }
}
