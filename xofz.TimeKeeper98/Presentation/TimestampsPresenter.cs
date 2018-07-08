namespace xofz.TimeKeeper98.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Framework.Transformation;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
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
            w.Run<Navigator, EventSubscriber>((n, subscriber) =>
            {
                var homeUi = n.GetUi<HomePresenter, HomeUi>();
                subscriber.Subscribe(
                    homeUi,
                    nameof(homeUi.InKeyTapped),
                    this.homeUi_InKeyTapped);
                subscriber.Subscribe(
                    homeUi,
                    nameof(homeUi.OutKeyTapped),
                    this.homeUi_OutKeyTapped);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 1, 0);
            this.startInternal();
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(ref this.startedIf1, 0, 1);
        }

        private void startInternal()
        {
            var w = this.web;
            w.Run<Navigator>(n =>
            {
                var homeNavUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                UiHelpers.Write(
                    homeNavUi,
                    () => { homeNavUi.ActiveKeyLabel = "Timestamps"; });
            });
            w.Run<
                DateCalculator,
                TimestampReader,
                Materializer,
                EnumerableSplitter>(
                (calc, reader, mz, splitter) =>
                {
                    var start = calc.StartOfWeek();
                    var end = calc.EndOfWeek().AddDays(1);
                    var allTimes = reader.Read();
                    var timesThisWeek = new LinkedList<DateTime>();
                    foreach (var time in allTimes)
                    {
                        if (time < start)
                        {
                            continue;
                        }

                        if (time > end)
                        {
                            continue;
                        }

                        timesThisWeek.AddLast(time);
                    }

                    var splitTimesThisWeek = splitter.Split(
                        timesThisWeek,
                        2);
                    var inTimes = splitTimesThisWeek[0];
                    var uiTimesIn = mz.Materialize(
                        EnumerableHelpers.Select(
                            inTimes,
                            this.formatTimestamp));
                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.InTimes = uiTimesIn; });

                    var outTimes = splitTimesThisWeek[1];
                    var uiTimesOut = mz.Materialize(
                        EnumerableHelpers.Select(
                            outTimes,
                            this.formatTimestamp));

                    UiHelpers.Write(
                        this.ui,
                        () => { this.ui.OutTimes = uiTimesOut; });

                    w.Run<EnumerableSplicer>(splicer =>
                    {
                        var llme = new LinkedListMaterializedEnumerable<string>(
                            EnumerableHelpers.Select(
                                splicer.Splice(
                                    new[]
                                    {
                                        inTimes,
                                        outTimes
                                    }),
                                this.formatTimestamp));

                        UiHelpers.Write(
                            this.ui,
                            () => { this.ui.SetSplicedInOutTimes(llme); });
                    });
                });

            base.Start();
        }

        private void homeUi_InKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.Start();
            }
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(ref this.startedIf1) == 1)
            {
                this.Start();
            }
        }

        private string formatTimestamp(DateTime timeStamp)
        {
            return timeStamp.ToString(
                "MM/dd hh:mm:ss tt");
        }

        private long setupIf1, startedIf1;
        private readonly TimestampsUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
