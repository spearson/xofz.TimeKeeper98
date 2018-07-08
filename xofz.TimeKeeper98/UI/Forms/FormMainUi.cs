﻿namespace xofz.TimeKeeper98.UI.Forms
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class FormMainUi : FormUi, MainUi, ShellUi
    {
        public FormMainUi()
        {
            this.InitializeComponent();
        }

        public event Action ShutdownRequested;

        public virtual ShellUi NavUi => this.navUi;

        void ShellUi.SwitchUi(Ui newUi)
        {
            var control = newUi as Control;
            ControlHelpers.SafeReplace(control, this.screenPanel);
        }

        private void this_FormClosing(
            object sender, 
            FormClosingEventArgs e)
        {
            e.Cancel = true;

            new Thread(() => this.ShutdownRequested?.Invoke())
                .Start();
        }
    }
}
