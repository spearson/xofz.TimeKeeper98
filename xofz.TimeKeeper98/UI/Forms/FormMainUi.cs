namespace xofz.TimeKeeper98.UI.Forms
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.TimeKeeper98.Properties;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class FormMainUi 
        : FormUi, MainUi, ShellUi, TitleUi
    {
        public FormMainUi()
        {
            this.InitializeComponent();

            this.Icon = Resources.TimeKeeper98_Icon;

            var h = this.Handle;
        }

        public event Do ShutdownRequested;

        public virtual ShellUi NavUi => this.navUi;

        void ShellUi.SwitchUi(Ui newUi)
        {
            var control = newUi as Control;
            ControlHelpers.SafeReplace(
                control, 
                this.screenPanel);
        }

        string TitleUi.Title
        {
            get => this.Text;

            set => this.Text = value;
        }

        private void this_FormClosing(
            object sender, 
            FormClosingEventArgs e)
        {
            e.Cancel = true;

            var sr = this.ShutdownRequested;
            if (sr == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => sr.Invoke());
        }

        
    }
}
