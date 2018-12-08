namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class CurrentWeekKeyTappedHandler
    {
        public CurrentWeekKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<DateCalculator, UiReaderWriter>(
                (calc, rw) =>
                {
                    var start = calc.StartOfWeek();
                    var end = calc.Friday();
                    rw.Write(
                        ui,
                        () =>
                        {
                            ui.StartDate = start;
                            ui.EndDate = end;
                        });
                });
        }
        protected readonly MethodWeb web;
    }
}
