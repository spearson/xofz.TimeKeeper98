namespace xofz.TimeKeeper98.Root
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.Framework;
    using xofz.Framework.Materialization;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Root.Commands;
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
            if (Interlocked.CompareExchange(ref this.bootstrappedIf1, 1, 0) == 1)
            {
                return;
            }

            this.setMainForm(new FormMainUi());
            var mf = this.mainForm;
            Messenger fm = new FormsMessenger();
            fm.Subscriber = mf;

            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                () => new MethodWeb(),
                fm));

            var w = e.Get<SetupMethodWebCommand>().Web;
            var homeUi = new UserControlHomeUi();
            e
                .Execute(new SetupHomeCommand(
                    homeUi,
                    new UserControlHomeNavUi(
                        new LinkedListMaterializer()),
                    mf,
                    mf.NavUi,
                    w))
                .Execute(new SetupStatisticsCommand(
                    new UserControlStatisticsUi(),
                    homeUi,
                    w))
                .Execute(new SetupTimestampsCommand(
                    new UserControlTimestampsUi(
                        new LinkedListMaterializer()),
                    homeUi,
                    w))
                .Execute(new SetupTimestampEditCommand(
                    new UserControlTimestampEditUi(),
                    homeUi,
                    w))
                .Execute(new SetupMainCommand(
                    mf,
                    w))
                .Execute(new SetupShutdownCommand(
                    mf,
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

        private int bootstrappedIf1;
        private FormMainUi mainForm;
        private readonly CommandExecutor executor;
    }
}
