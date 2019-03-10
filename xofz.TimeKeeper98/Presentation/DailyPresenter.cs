namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
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
            if (Interlocked.CompareExchange(
                    ref this.setupIf1, 
                    1, 
                    0) == 1)
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
                w.Run<Navigator>(nav =>
                {
                    var homeUi = nav.GetUi<HomePresenter, HomeUi>();
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

            w.Run<Navigator>(nav =>
            {
                Do refreshDaily = () =>
                {
                    if (Interlocked.Read(ref this.startedIf1) != 1)
                    {
                        return;
                    }

                    w.Run<StartHandler>(handler =>
                        handler.Handle(
                            this.ui));
                };

                w.RegisterDependency(
                    refreshDaily,
                    MethodNames.RefreshDaily);
                nav.RegisterPresenter(this);
            });
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            w.Run<StartHandler>(handler =>
                handler.Handle(
                    this.ui));
            Interlocked.CompareExchange(
                ref this.startedIf1, 
                1, 
                0);
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
            w.Run<CurrentKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private void ui_StatisticsRangeKeyTapped()
        {
            var w = this.web;
            w.Run<StatisticsRangeKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) != 1)
            {
                return;
            }

            var w = this.web;
            w.Run<HomeUiOutKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private long setupIf1, startedIf1;
        private readonly DailyUi ui;
        private readonly MethodWeb web;
    }
}
