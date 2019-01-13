namespace xofz.TimeKeeper98.Root
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.SettingsProviders;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.TimeKeeper98.UI.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper()
            : this(new CommandExecutor())
        {
        }

        public FormsBootstrapper(
            CommandExecutor executor)
        {
            this.executor = executor;
        }

        public virtual Form Shell => this.mainForm;

        public virtual void Bootstrap()
        {
            if (Interlocked.CompareExchange(
                ref this.bootstrappedIf1, 1, 0) == 1)
            {
                return;
            }

            this.setMainForm(new FormMainUi());
            var finished = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    this.onBootstrap();
                    finished.Set();
                });

            UiMessagePumper pumper = new FormsUiMessagePumper();
            while (!finished.WaitOne(0, false))
            {
                pumper.Pump();
            }
        }

        protected virtual void onBootstrap()
        {
            var s = this.mainForm;
            Messenger m = new FormsMessenger();
            m.Subscriber = s;

            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                () => new MethodWeb(),
                m,
                new AppConfigSettingsProvider()));
            var w = e.Get<SetupMethodWebCommand>().W;
            w.Run<EventSubscriber>(sub =>
            {
                var cd = AppDomain.CurrentDomain;
                UnhandledExceptionEventHandler handler = this.handleException;
                sub.Subscribe(
                    cd,
                    nameof(cd.UnhandledException),
                    handler);
            });
            w.RegisterDependency(s);

            HomeUi homeUi = null;
            HomeNavUi homeNavUi = null;
            StatisticsUi statsUi = null;
            TimestampsUi timestampsUi = null;
            TimestampEditUi editUi = null;
            DailyUi dailyUi = null;
            w.Run<UiReaderWriter, Lotter>(
                (uiRW, lotter) =>
            {
                uiRW.WriteSync(
                    s,
                    () =>
                    {
                        homeUi = new UserControlHomeUi();
                        homeNavUi = new UserControlHomeNavUi(lotter);
                        statsUi = new UserControlStatisticsUi();
                        timestampsUi = new UserControlTimestampsUi(lotter);
                        editUi = new UserControlTimestampEditUi();
                        dailyUi = new UserControlDailyUi(lotter);
                    });
            });

            e
                .Execute(new SetupHomeCommand(
                    homeUi,
                    homeNavUi,
                    s,
                    s.NavUi,
                    w))
                .Execute(new SetupStatisticsCommand(
                    statsUi,
                    homeUi,
                    w))
                .Execute(new SetupTimestampsCommand(
                    timestampsUi,
                    homeUi,
                    w))
                .Execute(new SetupDailyCommand(
                    dailyUi,
                    homeUi,
                    w))
                .Execute(new SetupTimestampEditCommand(
                    editUi,
                    homeUi,
                    w))
                .Execute(new SetupMainCommand(
                    s,
                    w))
                .Execute(new SetupShutdownCommand(
                    w));

            // update to single-file format
            w.Run<FileTimestampManager>(manager =>
            {
                manager.ConvertToSingleFile();
            });

            w.Run<DataWatcher>(watcher =>
            {
                watcher.Start();
            });

            w.Run<Navigator>(
                n =>
                {
                    n.Present<HomePresenter>();
                    n.PresentFluidly<HomeNavPresenter>();
                    n.PresentFluidly<TimestampsPresenter>();
                });
        }

        protected virtual void setMainForm(FormMainUi mainForm)
        {
            this.mainForm = mainForm;
        }

        protected virtual void handleException(
            object sender, 
            UnhandledExceptionEventArgs e)
        {
            var w = this.executor.Get<SetupMethodWebCommand>().W;
            w.Run<LogEditor>(le =>
                {
                    LogHelpers.AddEntry(le, e);
                },
                LogNames.Exceptions);
        }

        protected long bootstrappedIf1;
        protected FormMainUi mainForm;
        protected readonly CommandExecutor executor;
    }
}
