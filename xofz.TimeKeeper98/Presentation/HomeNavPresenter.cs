namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class HomeNavPresenter : Presenter
    {
        public HomeNavPresenter(
            HomeNavUi ui,
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
            w.Run<EventSubscriber>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.StatisticsKeyTapped),
                    this.ui_StatisticsKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.TimestampsKeyTapped),
                    this.ui_TimestampsKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.DailyKeyTapped),
                    this.ui_DailyKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.ExitKeyTapped),
                    this.ui_ExitKeyTapped);
            });

            w.Run<Navigator>(nav => nav.RegisterPresenter(this));
        }

        private void ui_StatisticsKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator>(nav => nav.Present<StatisticsPresenter>());
        }

        private void ui_TimestampsKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator>(nav => nav.Present<TimestampsPresenter>());
        }

        private void ui_DailyKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator>(nav => nav.Present<DailyPresenter>());
        }

        private void ui_ExitKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator>(nav => nav.Present<ShutdownPresenter>());
        }

        private long setupIf1;
        private readonly HomeNavUi ui;
        private readonly MethodWeb web;
    }
}