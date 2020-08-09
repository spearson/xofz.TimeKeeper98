namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.HomeNav;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class HomeNavPresenter
        : Presenter
    {
        public HomeNavPresenter(
            HomeNavUi ui,
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
            r.Run<EventSubscriber>(subscriber =>
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
                    nameof(this.ui.ConfigKeyTapped),
                    this.ui_ConfigKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.ExitKeyTapped),
                    this.ui_ExitKeyTapped);
            });

            r.Run<Navigator>(nav => 
                nav.RegisterPresenter(this));
        }

        private void ui_StatisticsKeyTapped()
        {
            var r = this.runner;
            r.Run<StatisticsKeyTappedHandler>(
                handler =>
                {
                    handler.Handle();
                });
        }

        private void ui_TimestampsKeyTapped()
        {
            var r = this.runner;
            r.Run<TimestampsKeyTappedHandler>(
                handler =>
                {
                    handler.Handle();
                });
        }

        private void ui_DailyKeyTapped()
        {
            var r = this.runner;
            r.Run<DailyKeyTappedHandler>(
                handler =>
                {
                    handler.Handle();
                });
        }

        private void ui_ConfigKeyTapped()
        {
            var r = this.runner;
            r.Run<ConfigKeyTappedHandler>(
                handler =>
                {
                    handler.Handle();
                });
        }

        private void ui_ExitKeyTapped()
        {
            var r = this.runner;
            r.Run<ExitKeyTappedHandler>(
                handler =>
                {
                    handler.Handle();
                });
        }

        private long setupIf1;
        private readonly HomeNavUi ui;
        private readonly MethodRunner runner;
    }
}