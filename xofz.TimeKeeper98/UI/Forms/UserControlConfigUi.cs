namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlConfigUi 
        : UserControlUi, ConfigUi
    {
        public UserControlConfigUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do ShowSecondsSelected;

        public virtual event Do ShowSecondsUnselected;

        public virtual event Do SaveIntervalKeyTapped;

        public virtual event Do ResetIntervalKeyTapped;

        public virtual event Do PublishKeyTapped;

        public virtual event Do PromptSelected;

        public virtual event Do PromptUnselected;

        public virtual event Do KeyboardKeyTapped;

        public virtual event Do SaveTitleTextKeyTapped;

        public virtual event Do ResetTitleTextKeyTapped;

        public virtual event Do DefaultTitleTextKeyTapped;

        bool ConfigUi.PromptChecked
        {
            get => this.promptCheckBox.Checked;

            set => this.promptCheckBox.Checked = value;
        }

        bool ConfigUi.ShowSecondsChecked
        {
            get => this.showSecondsCheckBox.Checked;

            set => this.showSecondsCheckBox.Checked = value;
        }

        int ConfigUi.TimerIntervalSeconds
        {
            get
            {
                try
                {
                    return Convert
                        .ToInt32(
                            Math.Round(
                                    this.timerIntervalPicker.Value,
                                    0));
                }
                catch
                {
                    return 0;
                }
                
            }

            set => this.timerIntervalPicker.Value = value;
        }

        string ConfigUi.TitleText
        {
            get => this.titleTextTextBox.Text;

            set => this.titleTextTextBox.Text = value;
        }

        string ConfigUi.TotalTimestampCount
        {
            get => this.totalTimeStampCountLabel.Text;

            set => this.totalTimeStampCountLabel.Text = value;
        }

        string ConfigUi.InRangeTimestampCount
        {
            get => this.statisticsRangeTimestampCountLabel.Text;

            set => this.statisticsRangeTimestampCountLabel.Text = value;
        }

        string ConfigUi.ThisWeekTimestampCount
        {
            get => this.thisWeekTimestampCountLabel.Text;

            set => this.thisWeekTimestampCountLabel.Text = value;
        }

        void ConfigUi.FocusTitleTextTextBox()
        {
            this.titleTextTextBox.Focus();
            this.titleTextTextBox.SelectAll();
        }

        protected virtual void showSecondsCheckBox_CheckedChanged(
            object sender, 
            System.EventArgs e)
        {
            if (this.showSecondsCheckBox.Checked)
            {
                var sss = this.ShowSecondsSelected;
                if (sss == null)
                {
                    return;
                }

                ThreadPool.QueueUserWorkItem(
                    o => sss.Invoke());
                return;
            }

            var ssu = this.ShowSecondsUnselected;
            if (ssu == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => ssu.Invoke());
        }

        protected virtual void promptCheckBox_CheckedChanged(
            object sender,
            System.EventArgs e)
        {
            if (this.promptCheckBox.Checked)
            {
                var ps = this.PromptSelected;
                if (ps == null)
                {
                    return;
                }

                ThreadPool.QueueUserWorkItem(
                    o => ps.Invoke());
                return;
            }

            var pu = this.PromptUnselected;
            if (pu == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => pu.Invoke());
        }

        protected virtual void saveTitleTextKey_Click(
            object sender, 
            System.EventArgs e)
        {
            var sttkt = this.SaveTitleTextKeyTapped;
            if (sttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => sttkt.Invoke());
        }

        protected virtual void resetTitleTextKey_Click(
            object sender,
            System.EventArgs e)
        {
            var rttkt = this.ResetTitleTextKeyTapped;
            if (rttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => rttkt.Invoke());
        }

        protected virtual void defaultTitleTextKeyTapped_Click(
            object sender, 
            System.EventArgs e)
        {
            var dttkt = this.DefaultTitleTextKeyTapped;
            if (dttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => dttkt.Invoke());
        }

        protected virtual void keyboardKey_Click(
            object sender,
            System.EventArgs e)
        {
            var kkt = this.KeyboardKeyTapped;
            if (kkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => kkt.Invoke());
        }

        protected virtual void publishKey_Click(
            object sender, 
            System.EventArgs e)
        {
            var pkt = this.PublishKeyTapped;
            if (pkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => pkt.Invoke());
        }

        protected virtual void SaveIntervalKey_Click(
            object sender, 
            EventArgs e)
        {
            var sikt = this.SaveIntervalKeyTapped;
            if (sikt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => sikt.Invoke());
        }

        protected virtual void resetIntervalKey_Click(
            object sender, 
            EventArgs e)
        {
            var rikt = this.ResetIntervalKeyTapped;
            if (rikt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o =>
                rikt.Invoke());
        }

        protected virtual void timerIntervalPicker_KeyPress(
            object sender,
            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            var skt = this.SaveIntervalKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => skt.Invoke());
        }
    }
}
