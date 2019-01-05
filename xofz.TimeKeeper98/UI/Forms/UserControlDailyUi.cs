namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlDailyUi 
        : UserControlUi, DailyUi
    {
        public UserControlDailyUi(
            Lotter lotter)
        {
            this.lotter = lotter;

            InitializeComponent();
        }

        private UserControlDailyUi()
        {
            this.InitializeComponent();
        }

        public event Do CurrentKeyTapped;

        public event Do StatisticsRangeKeyTapped;

        Lot<string> DailyUi.Info
        {
            get => this.lotter.Materialize(
                this.infoTextBox.Lines);

            set
            {
                var itb = this.infoTextBox;
                itb.Clear();
                if (value == null)
                {
                    return;
                }

                var firstItem = true;
                foreach (var datum in value)
                {
                    if (firstItem)
                    {
                        itb.AppendText(datum);
                        firstItem = false;
                        continue;
                    }
                    
                    itb.AppendText(
                        Environment.NewLine + datum);
                }
            }
        }

        private void currentKey_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (this.currentKey.Checked)
            {
                var ckt = this.CurrentKeyTapped;
                if (ckt == null)
                {
                    return;
                }

                ThreadPool.QueueUserWorkItem(o => ckt.Invoke());
                return;
            }

            var srkt = this.StatisticsRangeKeyTapped;
            if (srkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => srkt.Invoke());
        }

        protected readonly Lotter lotter;
    }
}
