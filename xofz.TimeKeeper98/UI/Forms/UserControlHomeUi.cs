namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class UserControlHomeUi 
        : UserControlUi, HomeUi
    {
        public UserControlHomeUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do InKeyTapped;

        public virtual event Do OutKeyTapped;

        public virtual event Do EditKeyTapped;

        bool HomeUi.InKeyVisible
        {
            get => this.inKey.Visible;

            set => this.inKey.Visible = value;
        }

        bool HomeUi.OutKeyVisible
        {
            get => this.outKey.Visible;

            set => this.outKey.Visible = value;
        }

        bool HomeUi.EditKeyEnabled
        {
            get => this.editKey.Enabled;

            set => this.editKey.Enabled = value;
        }

        bool HomeUi.Editing
        {
            get => this.editing;

            set
            {
                this.editing = value;
                this.editKey.BackColor = value
                    ? System.Drawing.SystemColors.ControlDark
                    : System.Drawing.SystemColors.Control;
            }
        }

        private bool editing;

        void ShellUi.SwitchUi(Ui newUi)
        {
            var control = newUi as Control;
            ControlHelpers.SafeReplace(
                control,
                this.screenPanel);
        }

        string HomeUi.TimeWorkedThisWeek
        {
            get => this.timeThisWeekLabel.Text;

            set => this.timeThisWeekLabel.Text = value;
        }

        string HomeUi.TimeWorkedToday
        {
            get => this.timeTodayLabel.Text;

            set => this.timeTodayLabel.Text = value;
        }

        private const string VersionFlavorText = @"v";

        string HomeUi.Version
        {
            get
            {
                var text = this.versionLabel.Text;
                if (text?.Contains(VersionFlavorText)
                    ?? false)
                {
                    return text.Substring(VersionFlavorText.Length);
                }

                return string.Empty;
            }

                set => this.versionLabel.Text = VersionFlavorText + value;
        }

        protected const string CoreVersionFlavorText =
            @"Powered by x(z) Core98 v";

        string HomeUi.CoreVersion
        {
            get
            {
                var text = this.coreVersionLabel.Text;
                if (text?.Contains(CoreVersionFlavorText)
                    ?? false)
                {
                    return text.Substring(CoreVersionFlavorText.Length);
                }

                return string.Empty;
            }

            set => this.coreVersionLabel.Text = CoreVersionFlavorText + value;
        }

        protected virtual void inKey_Click(
            object sender, 
            EventArgs e)
        {
            var ikt = this.InKeyTapped;
            if (ikt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => ikt.Invoke());
        }

        protected virtual void outKey_Click(
            object sender, 
            EventArgs e)
        {
            var okt = this.OutKeyTapped;
            if (okt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => okt.Invoke());
        }

        protected virtual void editKey_Click(
            object sender, 
            EventArgs e)
        {
            var ekt = this.EditKeyTapped;
            if (ekt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => ekt.Invoke());
        }
    }
}
