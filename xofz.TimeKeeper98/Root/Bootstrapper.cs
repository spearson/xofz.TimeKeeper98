namespace xofz.TimeKeeper98.Root
{
    using System;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Framework.Main;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.ConfigSavers;
    using xofz.TimeKeeper98.Framework.DataWatchers;
    using xofz.TimeKeeper98.Framework.SettingsProviders;
    using xofz.TimeKeeper98.Presentation.NavLogicReaders;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.Presentation.UiReaders;
    using xofz.TimeKeeper98.Root.Commands;
    using xofz.TimeKeeper98.UI;
    using xofz.TimeKeeper98.UI.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public class Bootstrapper
    {
        public Bootstrapper()
            : this(
                new CommandExecutor())
        {
        }

        protected Bootstrapper(
            CommandExecutor executor)
            : this(
                executor,
                new FormsUiMessagePumper(), 
                () => new FormMainUi(),
                () => new UserControlHomeUi(), 
                lotter => new UserControlHomeNavUi(
                    lotter),
                () => new UserControlStatisticsUi(),
                lotter => new UserControlTimestampsUi(lotter),
                () => new UserControlTimestampEditUi(),
                lotter => new UserControlDailyUi(lotter),
                () => new UserControlConfigUi(),
                shell => new FormLicenseUi(shell as FormUi),
                runner => new AppConfigConfigSaver(runner),
                runner => new AppConfigSettingsProvider(runner),
                runner => new FileTimestampManager(runner),
                web => new FileDataWatcher(web),
                () => new FormsMessenger())
        {
        }

        protected Bootstrapper(
            UiMessagePumper pumper,
            Gen<TimeKeeperShellUi> newMainShell,
            Gen<HomeUi> newHomeUi,
            Gen<Lotter, HomeNavUi> newHomeNavUi,
            Gen<StatisticsUi> newStatsUi,
            Gen<Lotter, TimestampsUi> newTimestampsUi,
            Gen<TimestampEditUi> newEditUi,
            Gen<Lotter, DailyUi> newDailyUi,
            Gen<ConfigUi> newConfigUi,
            Gen<Ui, LicenseUi> newLicenseUi,
            Gen<Messenger> newMessenger = null)
            : this(
                new CommandExecutor(),
                pumper,
                newMainShell,
                newHomeUi,
                newHomeNavUi,
                newStatsUi,
                newTimestampsUi,
                newEditUi,
                newDailyUi,
                newConfigUi,
                newLicenseUi,
                runner => new AppConfigConfigSaver(runner),
                runner => new AppConfigSettingsProvider(runner),
                runner => new FileTimestampManager(runner),
                web => new FileDataWatcher(web),
                newMessenger)
        {
        }

        protected Bootstrapper(
            CommandExecutor executor,
            UiMessagePumper pumper,
            Gen<TimeKeeperShellUi> newMainShell,
            Gen<HomeUi> newHomeUi,
            Gen<Lotter, HomeNavUi> newHomeNavUi,
            Gen<StatisticsUi> newStatsUi,
            Gen<Lotter, TimestampsUi> newTimestampsUi,
            Gen<TimestampEditUi> newEditUi,
            Gen<Lotter, DailyUi> newDailyUi,
            Gen<ConfigUi> newConfigUi,
            Gen<Ui, LicenseUi> newLicenseUi,
            Gen<Messenger> newMessenger = null)
            : this(
                executor,
                pumper,
                newMainShell,
                newHomeUi,
                newHomeNavUi,
                newStatsUi,
                newTimestampsUi,
                newEditUi,
                newDailyUi,
                newConfigUi,
                newLicenseUi,
                runner => new AppConfigConfigSaver(runner),
                runner => new AppConfigSettingsProvider(runner),
                runner => new FileTimestampManager(runner),
                web => new FileDataWatcher(web),
                newMessenger)
        {
        }

        protected Bootstrapper(
            Gen<MethodRunner, ConfigSaver> newConfigSaver,
            Gen<MethodRunner, SettingsProvider> newSettingsProvider)
            : this(
                new CommandExecutor(),
                new FormsUiMessagePumper(),
                () => new FormMainUi(),
                () => new UserControlHomeUi(),
                lotter => new UserControlHomeNavUi(lotter),
                () => new UserControlStatisticsUi(),
                lotter => new UserControlTimestampsUi(lotter),
                () => new UserControlTimestampEditUi(),
                lotter => new UserControlDailyUi(lotter),
                () => new UserControlConfigUi(),
                shell => new FormLicenseUi(shell as System.Windows.Forms.Form),
                newConfigSaver,
                newSettingsProvider,
                runner => new FileTimestampManager(runner),
                web => new FileDataWatcher(web),
                () => new FormsMessenger())
        {
        }

        protected Bootstrapper(
            CommandExecutor executor,
            Gen<MethodRunner, ConfigSaver> newConfigSaver,
            Gen<MethodRunner, SettingsProvider> newSettingsProvider)
            : this(
                executor,
                new FormsUiMessagePumper(), 
                () => new FormMainUi(),
                () => new UserControlHomeUi(),
                lotter => new UserControlHomeNavUi(lotter),
                () => new UserControlStatisticsUi(),
                lotter => new UserControlTimestampsUi(lotter),
                () => new UserControlTimestampEditUi(),
                lotter => new UserControlDailyUi(lotter),
                () => new UserControlConfigUi(),
                shell => new FormLicenseUi(shell as System.Windows.Forms.Form),
                newConfigSaver,
                newSettingsProvider,
                runner => new FileTimestampManager(runner),
                web => new FileDataWatcher(web),
                () => new FormsMessenger())
        {
        }

        protected Bootstrapper(
            Gen<MethodRunner, TimestampReaderWriter> newReaderWriter,
            Gen<MethodWeb, DataWatcher> newDataWatcher)
            : this(
                new CommandExecutor(),
                new FormsUiMessagePumper(), 
                () => new FormMainUi(),
                () => new UserControlHomeUi(),
                lotter => new UserControlHomeNavUi(lotter),
                () => new UserControlStatisticsUi(),
                lotter => new UserControlTimestampsUi(lotter),
                () => new UserControlTimestampEditUi(),
                lotter => new UserControlDailyUi(lotter),
                () => new UserControlConfigUi(),
                shell => new FormLicenseUi(shell as FormUi),
                runner => new AppConfigConfigSaver(runner),
                runner => new AppConfigSettingsProvider(runner),
                newReaderWriter,
                newDataWatcher,
                () => new FormsMessenger())
        {
        }

        protected Bootstrapper(
            CommandExecutor executor,
            Gen<MethodRunner, TimestampReaderWriter> newReaderWriter,
            Gen<MethodWeb, DataWatcher> newDataWatcher)
            : this(
                executor,
                new FormsUiMessagePumper(),
                () => new FormMainUi(),
                () => new UserControlHomeUi(),
                lotter => new UserControlHomeNavUi(lotter),
                () => new UserControlStatisticsUi(),
                lotter => new UserControlTimestampsUi(lotter),
                () => new UserControlTimestampEditUi(),
                lotter => new UserControlDailyUi(lotter),
                () => new UserControlConfigUi(),
                shell => new FormLicenseUi(shell as FormUi),
                runner => new AppConfigConfigSaver(runner),
                runner => new AppConfigSettingsProvider(runner),
                newReaderWriter,
                newDataWatcher,
                () => new FormsMessenger())
        {
        }

        protected Bootstrapper(
            CommandExecutor executor,
            UiMessagePumper pumper,
            Gen<TimeKeeperShellUi> newMainShell,
            Gen<HomeUi> newHomeUi,
            Gen<Lotter, HomeNavUi> newHomeNavUi,
            Gen<StatisticsUi> newStatsUi,
            Gen<Lotter, TimestampsUi> newTimestampsUi,
            Gen<TimestampEditUi> newEditUi,
            Gen<Lotter, DailyUi> newDailyUi,
            Gen<ConfigUi> newConfigUi,
            Gen<Ui, LicenseUi> newLicenseUi,
            Gen<MethodRunner, ConfigSaver> newConfigSaver,
            Gen<MethodRunner, SettingsProvider> newSettingsProvider,
            Gen<MethodRunner, TimestampReaderWriter> newReaderWriter,
            Gen<MethodWeb, DataWatcher> newDataWatcher,
            Gen<Messenger> newMessenger)
        {
            this.executor = executor;
            this.pumper = pumper;
            this.newMainShell = newMainShell;
            this.newHomeUi = newHomeUi;
            this.newHomeNavUi = newHomeNavUi;
            this.newStatsUi = newStatsUi;
            this.newTimestampsUi = newTimestampsUi;
            this.newEditUi = newEditUi;
            this.newDailyUi = newDailyUi;
            this.newConfigUi = newConfigUi;
            this.newLicenseUi = newLicenseUi;
            this.newConfigSaver = newConfigSaver;
            this.newSettingsProvider = newSettingsProvider;
            this.newReaderWriter = newReaderWriter;
            this.newDataWatcher = newDataWatcher;
            this.newMessenger = newMessenger;
        }

        public virtual object Shell => this.mainShell;

        public virtual void Bootstrap()
        {
            const byte one = 1;
            if (Interlocked.Exchange(
                    ref this.bootstrappedIf1,
                    one) == one)
            {
                return;
            }

            var shellFactory = this.newMainShell;
            if (shellFactory == null)
            {
                return;
            }

            this.setMainShell(shellFactory());
            var finished = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    this.onBootstrap();
                    finished.Set();
                });

            var p = this.pumper;
            while (!finished.WaitOne(0, false))
            {
                p?.Pump();
            }
        }

        protected virtual void onBootstrap()
        {
            var s = this.mainShell;
            if (s == null)
            {
                return;
            }

            var m = this.newMessenger?.Invoke();
            if (m != null)
            {
                m.Subscriber = s;
            }

            var e = this.executor;
            e?.Execute(new SetupMethodWebCommand(
                new MethodWebV2(),
                m,
                this.newConfigSaver,
                this.newSettingsProvider));

            var w = e?.Get<SetupMethodWebCommand>()?.W;
            w?.Run<EventSubscriber>(sub =>
            {
                var cd = AppDomain.CurrentDomain;
                UnhandledExceptionEventHandler handler = this.handleException;
                sub.Subscribe(
                    cd,
                    nameof(cd.UnhandledException),
                    handler);
            });
            w?.RegisterDependency(s);

            HomeUi homeUi = null;
            HomeNavUi homeNavUi = null;
            StatisticsUi statsUi = null;
            TimestampsUi timestampsUi = null;
            TimestampEditUi editUi = null;
            DailyUi dailyUi = null;
            ConfigUi configUi = null;
            LicenseUi licenseUi = null;
            w?.Run<UiReaderWriter, Lotter>(
                (uiRW, lotter) =>
                {
                    uiRW.WriteSync(
                        s,
                        () =>
                        {
                            homeUi = this.newHomeUi?.Invoke();
                            homeNavUi = this.newHomeNavUi?.Invoke(lotter);
                            statsUi = this.newStatsUi?.Invoke();
                            timestampsUi = this.newTimestampsUi?.Invoke(lotter);
                            editUi = this.newEditUi?.Invoke();
                            dailyUi = this.newDailyUi?.Invoke(lotter);
                            configUi = this.newConfigUi?.Invoke();
                            licenseUi = this.newLicenseUi?.Invoke(s);
                        });
                });

            var homeFinished = new ManualResetEvent(false);
            var homeNavFinished = new ManualResetEvent(false);
            var statsFinished = new ManualResetEvent(false);
            var editFinished = new ManualResetEvent(false);
            var timestampsFinished = new ManualResetEvent(false);
            var dailyFinished = new ManualResetEvent(false);
            var mainFinished = new ManualResetEvent(false);
            var shutdownFinished = new ManualResetEvent(false);
            var licenseFinished = new ManualResetEvent(false);
            var configFinished = new ManualResetEvent(false);

            w?.Run<Do<Do>>(invoker =>
            {
                invoker.Invoke(
                    () =>
                {
                    e?.Execute(
                        new SetupHomeCommand(
                            homeUi,
                            s,
                            this.newReaderWriter,
                            this.newDataWatcher,
                            w));
                    homeFinished.Set();
                });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupHomeNavCommand(
                                homeNavUi,
                                s.NavUi,
                                new NavigatorNavLogicReader(w),
                                w));
                        homeNavFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupStatisticsCommand(
                                statsUi,
                                homeUi,
                                w));
                        statsFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupTimestampEditCommand(
                                editUi,
                                homeUi,
                                w));
                        editFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupMainCommand(
                                s,
                                w,
                                new SettingsHolder()));
                        mainFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupShutdownCommand(
                                w));
                        shutdownFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupLicenseCommand(
                                licenseUi,
                                w));
                        licenseFinished.Set();
                    });

                homeFinished.WaitOne();

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupTimestampsCommand(
                                timestampsUi,
                                homeUi,
                                w));
                        timestampsFinished.Set();
                    });

                invoker.Invoke(
                    () =>
                    {
                        e?.Execute(
                            new SetupDailyCommand(
                                dailyUi,
                                homeUi,
                                new NavigatorUiReader(w),
                                w));
                        dailyFinished.Set();
                    });
            });

            // update to single-file format
            w?.Run<FileTimestampManager>(manager =>
            {
                manager.ConvertToSingleFile();
            });

            w?.Run<DataWatcher>(watcher =>
            {
                watcher.Start();
            });

            w?.Run<Navigator>(
                nav =>
                {
                    nav.Present<HomePresenter>();

                    w.Run<Do<Do>>(invoker =>
                    {
                        homeNavFinished.WaitOne();
                    });
                    
                    nav.PresentFluidly<HomeNavPresenter>();

                    w.Run<Do<Do>>(invoker =>
                    {
                        timestampsFinished.WaitOne();
                    });

                    nav.PresentFluidly<TimestampsPresenter>();
                });

            w?.Run<Do<Do>>(invoker =>
            {
                dailyFinished.WaitOne();
                invoker.Invoke(() =>
                {
                    e?.Execute(
                        new SetupConfigCommand(
                            configUi,
                            homeUi,
                            w));
                    configFinished.Set();
                });

                statsFinished.WaitOne();
                editFinished.WaitOne();
                mainFinished.WaitOne();
                shutdownFinished.WaitOne();
                licenseFinished.WaitOne();
                configFinished.WaitOne();
            });
        }

        protected virtual void setMainShell(
            TimeKeeperShellUi mainShell)
        {
            this.mainShell = mainShell;
        }

        protected virtual void handleException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            var w = this.executor?.Get<SetupMethodWebCommand>()?.W;
            w?.Run<LogEditor>(le =>
                {
                    LogHelpers.AddEntry(le, e);
                },
                LogNames.Exceptions);
        }

        protected long bootstrappedIf1;
        protected TimeKeeperShellUi mainShell;
        protected readonly CommandExecutor executor;
        protected readonly UiMessagePumper pumper;
        protected readonly Gen<TimeKeeperShellUi> newMainShell;
        protected readonly Gen<HomeUi> newHomeUi;
        protected readonly Gen<Lotter, HomeNavUi> newHomeNavUi;
        protected readonly Gen<StatisticsUi> newStatsUi;
        protected readonly Gen<Lotter, TimestampsUi> newTimestampsUi;
        protected readonly Gen<TimestampEditUi> newEditUi;
        protected readonly Gen<Lotter, DailyUi> newDailyUi;
        protected readonly Gen<ConfigUi> newConfigUi;
        protected readonly Gen<Ui, LicenseUi> newLicenseUi;
        protected readonly Gen<Messenger> newMessenger;
        protected readonly Gen<MethodRunner, ConfigSaver> newConfigSaver;
        protected readonly Gen<MethodRunner, SettingsProvider> newSettingsProvider;
        protected readonly Gen<MethodRunner, TimestampReaderWriter> newReaderWriter;
        protected readonly Gen<MethodWeb, DataWatcher> newDataWatcher;
    }
}
