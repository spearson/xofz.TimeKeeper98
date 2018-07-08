namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
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
            w.Run<DateCalculator>(calc =>
            {
                var startOfWeek = calc.StartOfWeek();
                var endOfWeek = calc.Friday();
                UiHelpers.Write(
                    this.ui,
                    () =>
                    {
                        this.ui.StartDate = startOfWeek;
                        this.ui.EndDate = endOfWeek;
                    });
                this.ui.WriteFinished.WaitOne();
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

            w.Run<Navigator>(n =>
            {
                var homeNavUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                UiHelpers.Write(
                    homeNavUi,
                    () => { homeNavUi.ActiveKeyLabel = "Statistics"; });
            });

            w.Run<xofz.Framework.Timer, EventRaiser>(
                (t, er) =>
                {
                    er.Raise(
                        t,
                        nameof(t.Elapsed));
                    t.Start(1000);
                },
                "StatisticsTimer");
        }

        public override void Stop()
        {
            var w = this.web;
            w.Run<xofz.Framework.Timer>(
                t =>
                {
                    t.Stop();
                },
                "StatisticsTimer");
        }

        private void ui_CurrentWeekKeyTapped()
        {
            var w = this.web;
            var calc = w.Run<DateCalculator>();
            var start = calc.StartOfWeek();
            var end = calc.Friday();

            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.StartDate = start;
                    this.ui.EndDate = end;
                });
        }

        private void ui_PreviousWeekKeyTapped()
        {
            var currentStart = UiHelpers.Read(
                this.ui,
                () => this.ui.StartDate);
            var currentEnd = UiHelpers.Read(
                this.ui,
                () => this.ui.EndDate);
            var newStart = currentStart.AddDays(-7);
            var newEnd = currentEnd.AddDays(-7);

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.StartDate = newStart;
                this.ui.EndDate = newEnd;
            });
        }

        private void ui_NextWeekKeyTapped()
        {
            var currentStart = UiHelpers.Read(
                this.ui,
                () => this.ui.StartDate);
            var currentEnd = UiHelpers.Read(
                this.ui,
                () => this.ui.EndDate);
            var newStart = currentStart.AddDays(7);
            var newEnd = currentEnd.AddDays(7);

            UiHelpers.Write(this.ui, () =>
            {
                this.ui.StartDate = newStart;
                this.ui.EndDate = newEnd;
            });
        }

        private void ui_DateChanged()
        {
            this.computeStatistics();
        }

        private void timer_Elapsed()
        {
            this.computeStatistics();
        }

        private void computeStatistics()
        {
            var startDate = UiHelpers.Read(this.ui, () => this.ui.StartDate);
            var endDate = UiHelpers.Read(this.ui, () => this.ui.EndDate).AddDays(1);
            var w = this.web;
            var calc = w.Run<StatisticsCalculator>();
            var timeWorked = calc.TimeWorked(startDate, endDate);
            var viewer = w.Run<TimeSpanViewer>();
            var readableString = viewer.ReadableString(timeWorked);
            // ReSharper disable once AccessToModifiedClosure
            // because we are waiting on the UI write to finish,
            // this variable will not be overwritten by its second assignment
            // until it is ready
            UiHelpers.Write(
                this.ui, 
                () =>
                {
                    this.ui.TimeWorked = readableString;
                });
            this.ui.WriteFinished.WaitOne();

            var avgDaily = calc.AverageDailyTimeWorked(startDate, endDate);
            readableString = viewer.ReadableString(avgDaily);
            // ReSharper disable once AccessToModifiedClosure
            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.AvgDailyTimeWorked = readableString;
                });
            this.ui.WriteFinished.WaitOne();

            var minDaily = calc.MinDailyTimeWorked(startDate, endDate);
            readableString = viewer.ReadableString(minDaily);
            // ReSharper disable once AccessToModifiedClosure
            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.MinDailyTimeWorked = readableString;
                });
            this.ui.WriteFinished.WaitOne();

            var maxDaily = calc.MaxDailyTimeWorked(startDate, endDate);
            readableString = viewer.ReadableString(maxDaily);
            // ReSharper disable once AccessToModifiedClosure
            UiHelpers.Write(
                this.ui,
                () =>
                {
                    this.ui.MaxDailyTimeWorked = readableString;
                });
            this.ui.WriteFinished.WaitOne();
        }

        private int setupIf1;
        private readonly StatisticsUi ui;
        private readonly MethodWeb web;
    }
}
