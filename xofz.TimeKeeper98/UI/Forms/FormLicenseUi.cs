namespace xofz.TimeKeeper98.UI.Forms
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class FormLicenseUi 
        : FormUi, LicenseUi
    {
        public FormLicenseUi(Form shell)
        {
            this.shell = shell;
            this.InitializeComponent();

            var h = this.Handle;
        }

        private FormLicenseUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do AcceptKeyTapped;

        public virtual event Do RejectKeyTapped;

        void PopupUi.Display()
        {
            var s = this.shell;
            if (s == null)
            {
                this.Show();
                return;
            }

            this.Location = s.Location;
            this.Show(s);
        }

        private void rejectKey_Click(object sender, System.EventArgs e)
        {
            var rkt = this.RejectKeyTapped;
            if (rkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => rkt.Invoke());
        }

        private void acceptKey_Click(object sender, System.EventArgs e)
        {
            var akt = this.AcceptKeyTapped;
            if (akt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => akt.Invoke());
        }

        private void this_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            e.Cancel = true;
            var rkt = this.RejectKeyTapped;
            if (rkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => rkt.Invoke());
        }

        protected readonly Form shell;
    }
}
