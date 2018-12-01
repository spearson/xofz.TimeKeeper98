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
            w.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, rw) =>
            {
                var format = settings.TimestampFormat;
                rw.Write(
                    this.ui,
                    () => this.ui.TimestampFormat = format);
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
            w.Run<TimestampReader, UiReaderWriter>((reader, rw) =>
            {
                var lastTimestamp = new LinkedList<DateTime>(reader.Read())
                    .Last
                    .Value;
                rw.Write(
                    this.ui,
                    () => this.ui.EditedTimestamp = lastTimestamp);
            });

            w.Run<Navigator, UiReaderWriter>((n, rw) =>
            {
                var hnUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                this.setOldActiveKeyLabel(
                    rw.Read(
                        hnUi,
                        () => hnUi.ActiveKeyLabel));
                rw.Write(
                    hnUi,
                    () => hnUi.ActiveKeyLabel = null);
                var homeUi = n.GetUi<HomePresenter, HomeUi>();
                rw.Write(
                    homeUi,
                    () => homeUi.Editing = true);
            });
        }

        private void setOldActiveKeyLabel(string oldActiveKeyLabel)
        {
            this.oldActiveKeyLabel = oldActiveKeyLabel;
        }

        public override void Stop()
        {
            var w = this.web;
            w.Run<Navigator, UiReaderWriter>((n, rw) =>
            {
                var homeUi = n.GetUi<HomePresenter, HomeUi>();
                rw.Write(
                    homeUi,
                    () => homeUi.Editing = false);
            });
        }

        private void ui_SaveKeyTapped()
        {
            var w = this.web;
            
            w.Run<TimestampReader, UiReaderWriter>((reader, rw) =>
            {
                var timestamp = rw.Read(
                    this.ui,
                    () => this.ui.EditedTimestamp);
                var allTimes = new LinkedList<DateTime>(reader.Read());
                if (allTimes.Count < 2)
                {
                    goto checkNow;
                }

                var previousTimestamp = allTimes
                    .Last
                    ?.Previous
                    ?.Value;
                if (timestamp < previousTimestamp)
                {
                    w.Run<Messenger>(m =>
                    {
                        rw.Write(
                            m.Subscriber,
                            () => m.GiveError(
                                "Time must be after previous timestamp."));
                    });

                    return;
                }

                checkNow:
                if (timestamp > DateTime.Now)
                {
                    w.Run<Messenger>(m =>
                    {
                        rw.Write(
                            m.Subscriber,
                            () => m.GiveError(
                                "Time must be before present time."));
                    });

                    return;
                }

                w.Run<TimestampWriter>(writer =>
                {
                    writer.EditLastTimestamp(timestamp);
                });

                w.Run<Navigator>(n =>
                {
                    switch (this.oldActiveKeyLabel)
                    {
                        case "Timestamps":
                            n.Present<TimestampsPresenter>();
                            break;
                        case "Statistics":
                            n.Present<StatisticsPresenter>();
                            break;
                    }
                });
            });
        }

        private void ui_CancelKeyTapped()
        {
            var w = this.web;
            w.Run<Navigator>(n =>
            {
                var navUi = n.GetUi<HomeNavPresenter, HomeNavUi>();
                switch (this.oldActiveKeyLabel)
                {
                    case "Timestamps":
                        n.Present<TimestampsPresenter>();
                        break;
                    case "Statistics":
                        n.Present<StatisticsPresenter>();
                        break;
                }
            });
        }

        private long setupIf1;
        private volatile string oldActiveKeyLabel;
        private readonly TimestampEditUi ui;
        private readonly ShellUi shell;
        private readonly MethodWeb web;
    }
}
