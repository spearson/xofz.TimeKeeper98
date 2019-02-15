namespace xofz.TimeKeeper98.UI.Forms
{
    using System.Threading;
    using xofz.UI.Forms;

    public partial class UserConfigConfigUi 
        : UserControlUi, ConfigUi
    {
        public UserConfigConfigUi()
        {
            InitializeComponent();
        }

        public virtual event Do ShowSecondsSelected;

        public virtual event Do ShowSecondsUnselected;

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

        string ConfigUi.TitleText
        {
            get => this.titleTextTextBox.Text;

            set => this.titleTextTextBox.Text = value;
        }

        void ConfigUi.FocusTitleTextTextBox()
        {
            this.titleTextTextBox.Focus();
            this.titleTextTextBox.SelectAll();
        }

        private void showSecondsCheckBox_CheckedChanged(
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

                ThreadPool.QueueUserWorkItem(o => sss.Invoke());
                return;
            }

            var ssu = this.ShowSecondsUnselected;
            if (ssu == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => ssu.Invoke());
        }

        private void promptCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.promptCheckBox.Checked)
            {
                var ps = this.PromptSelected;
                if (ps == null)
                {
                    return;
                }

                ThreadPool.QueueUserWorkItem(o => ps.Invoke());
                return;
            }

            var pu = this.PromptUnselected;
            if (pu == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => pu.Invoke());
        }

        private void saveTitleTextKey_Click(object sender, System.EventArgs e)
        {
            var sttkt = this.SaveTitleTextKeyTapped;
            if (sttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => sttkt.Invoke());
        }

        private void resetTitleTextKey_Click(object sender, System.EventArgs e)
        {
            var rttkt = this.ResetTitleTextKeyTapped;
            if (rttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => rttkt.Invoke());
        }

        private void defaultTitleTextKeyTapped_Click(object sender, System.EventArgs e)
        {
            var dttkt = this.DefaultTitleTextKeyTapped;
            if (dttkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => dttkt.Invoke());
        }

        private void keyboardKey_Click(object sender, System.EventArgs e)
        {
            var kkt = this.KeyboardKeyTapped;
            if (kkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => kkt.Invoke());
        }

        private void publishKey_Click(object sender, System.EventArgs e)
        {
            var pkt = this.PublishKeyTapped;
            if (pkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => pkt.Invoke());
        }
    }
}
