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

        public event Action InKeyTapped;

        public event Action OutKeyTapped;

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

        private void inKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.InKeyTapped?.Invoke()).Start();
        }

        private void outKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.OutKeyTapped?.Invoke()).Start();
        }
    }
}
