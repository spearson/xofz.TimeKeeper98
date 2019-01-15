namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;
    using xofz.TimeKeeper98.UI;    

    public partial class UserControlTimestampEditUi 
        : UserControlUi, TimestampEditUi
    {
        public UserControlTimestampEditUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do SaveKeyTapped;

        public virtual event Do CancelKeyTapped;

        public virtual event Do SaveCurrentKeyTapped;

        string TimestampEditUi.TimestampFormat
        {
            get => this.dateTimePicker.CustomFormat;

            set => this.dateTimePicker.CustomFormat = value;
        }

        DateTime TimestampEditUi.EditedTimestamp
        {
            get => this.dateTimePicker.Value;

            set => this.dateTimePicker.Value = value;
        }

        private void saveKey_Click(object sender, EventArgs e)
        {
            var skt = this.SaveKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => skt.Invoke());
        }

        private void cancelKey_Click(object sender, EventArgs e)
        {
            var ckt = this.CancelKeyTapped;
            if (ckt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => ckt.Invoke());
        }

        private void saveCurrentKey_Click(object sender, EventArgs e)
        {
            var sckt = this.SaveCurrentKeyTapped;
            if (sckt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => sckt.Invoke());
        }

        private void dateTimePicker_KeyPress(
            object sender, 
            KeyPressEventArgs e)
        {
            if ((Keys) e.KeyChar != Keys.Enter)
            {
                return;
            }

            var skt = this.SaveKeyTapped;
            if (skt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(o => skt.Invoke());
        }
    }
}
