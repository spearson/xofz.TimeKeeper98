namespace xofz.TimeKeeper98.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlStatisticsUi 
        : UserControlUi, StatisticsUi
    {
        public UserControlStatisticsUi()
        {
            this.InitializeComponent();
        }

        public virtual event Do DateChanged;

        public virtual event Do PreviousWeekKeyTapped;

        public virtual event Do CurrentWeekKeyTapped;

        public virtual event Do NextWeekKeyTapped;

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

        protected virtual void startDatePicker_DateChanged(
            object sender, 
            DateRangeEventArgs e)
        {
            var dc = this.DateChanged;
            if (dc == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => dc.Invoke());
        }

        protected virtual void endDatePicker_DateChanged(
            object sender, 
            DateRangeEventArgs e)
        {
            var dc = this.DateChanged;
            if (dc == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => dc.Invoke());
        }

        protected virtual void previousWeekKey_Click(
            object sender, 
            EventArgs e)
        {
            var pwkt = this.PreviousWeekKeyTapped;
            if (pwkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => pwkt.Invoke());
        }

        protected virtual void nextWeekKey_Click(
            object sender, 
            EventArgs e)
        {
            var nwkt = this.NextWeekKeyTapped;
            if (nwkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => nwkt.Invoke());
        }

        protected virtual void currentWeekKey_Click(
            object sender, 
            EventArgs e)
        {
            var cwkt = this.CurrentWeekKeyTapped;
            if (cwkt == null)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(
                o => cwkt.Invoke());
        }
    }
}
