namespace xofz.TimeKeeper98.Presentation
{
    using System;
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui, 
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

            this.ui.InKeyTapped += this.ui_InKeyTapped;
            this.ui.OutKeyTapped += this.ui_OutKeyTapped;
            var w = this.web;
            var calc = w.Run<StatisticsCalculator>();
            var currentlyIn = calc.ClockedIn();
            UiHelpers.Write(this.ui, () =>
            {
                this.ui.InKeyVisible = !currentlyIn;
                this.ui.OutKeyVisible = currentlyIn;
            });

            this.timer_Elapsed();
            w.Run<xofz.Framework.Timer, EventSubscriber>(
                (t, subscriber) =>
                {
                    subscriber.Subscribe(
                        t,
                        nameof(t.Elapsed),
                        this.timer_Elapsed);
                },
                "HomeTimer");
            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            w.Run<xofz.Framework.Timer, EventRaiser>((t, er) =>
                {
                    er.Raise(
                        t,
                        nameof(t.Elapsed));
                    t.Start(1000);
                },
                "HomeTimer");
        }

        private void ui_InKeyTapped()
        {
            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.InKeyVisible = false;
                    this.ui.OutKeyVisible = true;
                });
            this.ui.WriteFinished.WaitOne();
            this.writeTimestamp();
        }

        private void ui_OutKeyTapped()
        {
            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.InKeyVisible = true;
                    this.ui.OutKeyVisible = false;
                });
            this.ui.WriteFinished.WaitOne();
            this.writeTimestamp();
        }

        private void writeTimestamp()
        {
            var w = this.web;
            w.Run<TimestampWriter>(
                writer => writer.Write());
        }

        private void timer_Elapsed()
        {
            var w = this.web;
            var calc = w.Run<StatisticsCalculator>();
            var timeThisWeek = calc.TimeWorkedThisWeek();
            w.Run<TimeSpanViewer>(viewer =>
            {
                var readableString = viewer.ReadableString(
                    timeThisWeek);
                UiHelpers.Write(
                    this.ui,
                    () => this.ui.TimeWorkedThisWeek = readableString);
                this.ui.WriteFinished.WaitOne();
            });
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
