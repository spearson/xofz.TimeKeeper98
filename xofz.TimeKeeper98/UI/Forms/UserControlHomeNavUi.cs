namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlHomeNavUi 
        : UserControlUi, HomeNavUi
    {
        public UserControlHomeNavUi(Materializer materializer)
        {
            this.materializer = materializer;

            this.InitializeComponent();

            this.navKeys = materializer.Materialize(
                new[]
                {
                    this.timestampsKey,
                    this.statisticsKey,
                    this.exitKey
                });
        }

        private UserControlHomeNavUi()
        {
            this.InitializeComponent();
        }

        public event Do StatisticsKeyTapped;

        public event Do TimestampsKeyTapped;

        public event Do ExitKeyTapped;

        string HomeNavUi.ActiveKeyLabel
        {
            get
            {
                var nk = this.navKeys;
                foreach (var navKey in nk)
                {
                    if (navKey.BackColor == SystemColors.ControlDark)
                    {
                        return navKey.Text;
                    }
                }

                return string.Empty;
            }
            set
            {
                var nk = this.navKeys;
                foreach (var navKey in nk)
                {
                    if (navKey.Text == value)
                    {
                        foreach (var keyToReset in nk)
                        {
                            keyToReset.BackColor = SystemColors.Control;
                        }

                        navKey.BackColor = SystemColors.ControlDark;
                        break;
                    }
                }
            }
        }

        private void statisticsKey_Click(object sender, EventArgs e)
        {
            var skt = this.StatisticsKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
                skt.Invoke());
        }

        private void exitKey_Click(object sender, EventArgs e)
        {
            var ekt = this.ExitKeyTapped;
            if (ekt == null)
            {
                return;
            }
            ThreadPool.QueueUserWorkItem(o =>
                ekt.Invoke());
        }

        private void timestampsKey_Click(object sender, EventArgs e)
        {
            var tkt = this.TimestampsKeyTapped;
            if (tkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
                tkt.Invoke());
        }

        private MaterializedEnumerable<Button> navKeys;
        private readonly Materializer materializer;
    }
}
