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
    using xofz.TimeKeeper98.Framework.ConfigSavers;
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
            var w = new MethodWebV2();
            e.Execute(new SetupMethodWebCommand(
                w, 
                new NavigatorV2(w), 
                m,
                new AppConfigConfigSaver(w), 
                new AppConfigSettingsProvider()));
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
            ConfigUi configUi = null;
            LicenseUi licenseUi = null;
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
                        configUi = new UserConfigConfigUi();
                        licenseUi = new FormLicenseUi(s);
                    });
            });

            var homeFinished = new ManualResetEvent(false);
            var homeNavFinished = new ManualResetEvent(false);
            var timestampsFinished = new ManualResetEvent(false);
            var dailyFinished = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    e.Execute(
                        new SetupHomeCommand(
                            homeUi,
                            s,
                            w));
                    homeFinished.Set();
                });

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    e.Execute(
                        new SetupHomeNavCommand(
                            homeNavUi,
                            s.NavUi,
                            new NavigatorNavLogicReader(w),
                            w));
                    homeNavFinished.Set();
                });

            ThreadPool.QueueUserWorkItem(
                o => e.Execute(
                    new SetupStatisticsCommand(
                        statsUi,
                        homeUi,
                        w)));

            ThreadPool.QueueUserWorkItem(
                o => e.Execute(
                    new SetupTimestampEditCommand(
                        editUi,
                        homeUi,
                        w)));

            ThreadPool.QueueUserWorkItem(
                o => e.Execute(
                    new SetupMainCommand(
                        s,
                        w)));

            ThreadPool.QueueUserWorkItem(
                o => e.Execute(
                    new SetupShutdownCommand(
                        w)));

            ThreadPool.QueueUserWorkItem(
                o => e.Execute(
                    new SetupLicenseCommand(
                        licenseUi,
                        w)));

            homeFinished.WaitOne();

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    e.Execute(
                        new SetupTimestampsCommand(
                            timestampsUi,
                            homeUi,
                            w));
                    timestampsFinished.Set();
                });

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    e.Execute(
                        new SetupDailyCommand(
                            dailyUi,
                            homeUi,
                            new NavigatorUiReader(w),
                            w));
                    dailyFinished.Set();
                });

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

                    homeNavFinished.WaitOne();
                    n.PresentFluidly<HomeNavPresenter>();

                    timestampsFinished.WaitOne();
                    n.PresentFluidly<TimestampsPresenter>();
                });

            dailyFinished.WaitOne();
            ThreadPool.QueueUserWorkItem(o =>
            {
                e.Execute(
                    new SetupConfigCommand(
                        configUi,
                        homeUi,
                        w));
            });
        }

        protected virtual void setMainForm(
            FormMainUi mainForm)
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
