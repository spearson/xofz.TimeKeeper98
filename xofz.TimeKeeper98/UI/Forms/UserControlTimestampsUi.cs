namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserControlTimestampsUi :
        UserControlUi, TimestampsUi
    {
        public UserControlTimestampsUi(
            Lotter lotter)
        {
            this.lotter = lotter;

            this.InitializeComponent();
        }

        private UserControlTimestampsUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do CurrentKeyTapped;

        public virtual event Do StatisticsRangeKeyTapped;

        public virtual event Do<bool> ShowDurationChanged;

        Lot<string> TimestampsUi.InTimes
        {
            get => this.lotter.Materialize(
                this.timesInTextBox.Lines);

            set
            {
                if (value == null)
                {
                    return;
                }

                var lines = new string[value.Count];
                var i = 0;
                foreach (var timeIn in value)
                {
                    lines[i] = timeIn;
                    ++i;
                }

                this.timesInTextBox.Lines = lines;
            }
        }

        Lot<string> TimestampsUi.OutTimes
        {
            get => this.lotter.Materialize(
                this.timesOutTextBox.Lines);

            set
            {
                if (value == null)
                {
                    return;
                }

                var lines = new string[value.Count];
                var i = 0;
                foreach (var timeOut in value)
                {
                    lines[i] = timeOut;
                    ++i;
                }

                this.timesOutTextBox.Lines = lines;
            }
        }

        void TimestampsUi.SetSplicedInOutTimes(
            Lot<string> inOutTimes)
        {
            var tslb = this.timesSplicedListBox;
            tslb.Items.Clear();
            if (inOutTimes == null)
            {
                return;
            }

            bool isInTime = true;
            foreach (var inOutTime in inOutTimes)
            {
                if (isInTime)
                {
                    tslb.Items.Add(
                        inOutTime + " IN");
                    goto switchTimeType;
                }

                tslb.Items.Add(
                    inOutTime + " OUT");

                switchTimeType:
                isInTime = !isInTime;
            }
        }

        protected virtual void showDurationsCheckBox_CheckedChanged(
            object sender, 
            EventArgs e)
        {
            var sdc = this.ShowDurationChanged;
            if (sdc == null)
            {
                return;
            }

            var shouldShow = this.showDurationsCheckBox.Checked;
            ThreadPool.QueueUserWorkItem(
                o => sdc.Invoke(shouldShow));
        }

        protected virtual void statisticsRangeKey_Click(
            object sender, 
            EventArgs e)
        {
            var srkt = this.StatisticsRangeKeyTapped;
            if (srkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => srkt.Invoke());
        }

        protected virtual void currentKey_Click(
            object sender,
            EventArgs e)
        {
            var ckt = this.CurrentKeyTapped;
            if (ckt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => ckt.Invoke());
        }

        protected readonly Lotter lotter;
    }
}
