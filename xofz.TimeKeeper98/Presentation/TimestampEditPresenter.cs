using xofz.TimeKeeper98.Framework.TimestampEdit;

namespace xofz.TimeKeeper98.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;
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
            this.shell = shell;
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
                    nameof(this.ui.SaveKeyTapped),
                    this.ui_SaveKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.CancelKeyTapped),
                    this.ui_CancelKeyTapped);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            HomeNavUi hnUi = null;
            HomeUi homeUi = null;
            w.Run<Navigator>(n =>
            {
                hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                homeUi = n.GetUi<HomePresenter, HomeUi>();
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
            w.Run<Navigator>(n =>
            {
                homeUi = n.GetUi<HomePresenter, HomeUi>();
            });

            w.Run<StopHandler>(handler =>
            {
                handler.Handle(homeUi);
            });
        }

        private void ui_SaveKeyTapped()
        {
            var w = this.web;

            Do presentTimestamps = null;
            Do presentStatistics = null;
            w.Run<Navigator>(n =>
            {
                presentTimestamps = n.Present<TimestampsPresenter>;
                presentStatistics = n.Present<StatisticsPresenter>;
            });

            w.Run<SaveKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui,
                    presentTimestamps,
                    presentStatistics);
            });
        }

        private void ui_CancelKeyTapped()
        {
            var w = this.web;
            Do presentTimestamps = null;
            Do presentStatistics = null;
            w.Run<Navigator>(
                n =>
                {
                    presentTimestamps = n.Present<TimestampsPresenter>;
                    presentStatistics = n.Present<StatisticsPresenter>;
                });
            w.Run<CancelKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    presentTimestamps,
                    presentStatistics);
            });
        }

        private long setupIf1;
        private readonly TimestampEditUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
