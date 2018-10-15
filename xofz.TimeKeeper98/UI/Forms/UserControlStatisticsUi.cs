namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlStatisticsUi : UserControlUi, StatisticsUi
    {
        public UserControlStatisticsUi()
        {
            this.InitializeComponent();
        }

        public event Do DateChanged;

        public event Do PreviousWeekKeyTapped;

        public event Do CurrentWeekKeyTapped;

        public event Do NextWeekKeyTapped;

        DateTime StatisticsUi.StartDate
        {
            get => this.startDatePicker.SelectionRange.Start;

            set => this.startDatePicker.SetDate(value);
        }

        DateTime StatisticsUi.EndDate
        {
            get => this.endDatePicker.SelectionRange.Start;

            set => this.endDatePicker.SetDate(value);
        }

        string StatisticsUi.TimeWorked
        {
            get => this.timeWorkedLabel.Text;

            set => this.timeWorkedLabel.Text = value;
        }

        string StatisticsUi.AvgDailyTimeWorked
        {
            get => this.avgDailyLabel.Text;

            set => this.avgDailyLabel.Text = value;
        }

        string StatisticsUi.MinDailyTimeWorked
        {
            get => this.minDailyLabel.Text;

            set => this.minDailyLabel.Text = value;
        }

        string StatisticsUi.MaxDailyTimeWorked
        {
            get => this.maxDailyLabel.Text;

            set => this.maxDailyLabel.Text = value;
        }

        private void startDatePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            new Thread(() => this.DateChanged?.Invoke()).Start();
        }

        private void endDatePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            new Thread(() => this.DateChanged?.Invoke()).Start();
        }

        private void previousWeekKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.PreviousWeekKeyTapped?.Invoke()).Start();
        }

        private void nextWeekKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.NextWeekKeyTapped?.Invoke()).Start();
        }

        private void currentWeekKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.CurrentWeekKeyTapped?.Invoke()).Start();
        }
    }
}
