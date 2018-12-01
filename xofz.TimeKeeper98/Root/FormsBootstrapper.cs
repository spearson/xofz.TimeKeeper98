namespace xofz.TimeKeeper98.Root
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
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

        public virtual Form MainForm => this.mainForm;

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
            while (!finished.WaitOne(0))
            {
                pumper.Pump();
            }
        }

        protected virtual void onBootstrap()
        {
            var s = this.mainForm;
            Messenger fm = new FormsMessenger();
            fm.Subscriber = s;

            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                () => new MethodWeb(),
                fm));

            var w = e.Get<SetupMethodWebCommand>().Web;
            HomeUi homeUi = null;
            HomeNavUi homeNavUi = null;
            StatisticsUi statsUi = null;
            TimestampsUi timestampsUi = null;
            TimestampEditUi editUi = null;
            w.Run<UiReaderWriter, Lotter>(
                (rw, lotter) =>
            {
                rw.WriteSync(
                    s,
                    () =>
                    {
                        homeUi = new UserControlHomeUi();
                        homeNavUi = new UserControlHomeNavUi(lotter);
                        statsUi = new UserControlStatisticsUi();
                        timestampsUi = new UserControlTimestampsUi(lotter);
                        editUi = new UserControlTimestampEditUi();
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
                .Execute(new SetupTimestampEditCommand(
                    editUi,
                    homeUi,
                    w))
                .Execute(new SetupMainCommand(
                    s,
                    w))
                .Execute(new SetupShutdownCommand(
                    s,
                    w));

            w.Run<Navigator>(
                n =>
                {
                    n.Present<HomePresenter>();
                    n.PresentFluidly<HomeNavPresenter>();
                    n.PresentFluidly<TimestampsPresenter>();
                });
        }

        private void setMainForm(FormMainUi mainForm)
        {
            this.mainForm = mainForm;
        }

        protected long bootstrappedIf1;
        protected FormMainUi mainForm;
        private readonly CommandExecutor executor;
    }
}
