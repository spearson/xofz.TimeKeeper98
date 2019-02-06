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
        public UserControlHomeNavUi(Lotter lotter)
        {
            this.InitializeComponent();

            var tk = this.timestampsKey;
            var sk = this.statisticsKey;
            var dk = this.dailyKey;
            var ek = this.exitKey;
            var ck = this.configKey;
            this.navKeys = lotter.Materialize(
                new[]
                {
                    tk,
                    sk,
                    dk,
                    ck,
                    ek
                });
            tk.Text = NavKeyLabels.Timestamps;
            sk.Text = NavKeyLabels.Statistics;
            dk.Text = NavKeyLabels.Daily;
            ck.Text = NavKeyLabels.Config;
            ek.Text = NavKeyLabels.Exit;
            
        }

        private UserControlHomeNavUi()
        {
            this.InitializeComponent();
        }

        public event Do StatisticsKeyTapped;

        public event Do TimestampsKeyTapped;

        public event Do DailyKeyTapped;

        public event Do ConfigKeyTapped;

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
                        return;
                    }
                }

                foreach (var eachKey in nk)
                {
                    eachKey.BackColor = SystemColors.Control;
                }
            }
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

        private void dailyKey_Click(object sender, EventArgs e)
        {
            var dkt = this.DailyKeyTapped;
            if (dkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
                dkt.Invoke());
        }

        private void configKey_Click(object sender, EventArgs e)
        {
            var ckt = this.ConfigKeyTapped;
            if (ckt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
                ckt.Invoke());
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

        protected readonly Lot<Button> navKeys;
    }
}
