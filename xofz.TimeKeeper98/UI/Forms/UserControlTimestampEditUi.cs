namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;
    using xofz.TimeKeeper98.UI;    

    public partial class UserControlTimestampEditUi 
        : UserControlUi, TimestampEditUi
    {
        public UserControlTimestampEditUi()
        {
            this.InitializeComponent();
        }

        public event Do SaveKeyTapped;

        public event Do CancelKeyTapped;

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
    }
}
