namespace xofz.TimeKeeper98.UI.Forms
{
    using xofz.UI.Forms;

    public partial class UserControlTimestampsUi :
        UserControlUi, TimestampsUi
    {
        public UserControlTimestampsUi(Materializer materializer)
        {
            this.materializer = materializer;

            this.InitializeComponent();
        }

        private UserControlTimestampsUi()
        {
            this.InitializeComponent();
        }

        MaterializedEnumerable<string> TimestampsUi.InTimes
        {
            get => this.materializer.Materialize(
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

        MaterializedEnumerable<string> TimestampsUi.OutTimes
        {
            get => this.materializer.Materialize(
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
            MaterializedEnumerable<string> inOutTimes)
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
                        inOutTime + " ---- IN");
                    goto switchTimeType;
                }

                tslb.Items.Add(
                    inOutTime + " ---- OUT");

                switchTimeType:
                isInTime = !isInTime;
            }
        }

        private readonly Materializer materializer;
    }
}
