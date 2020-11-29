namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class CurrentWeekKeyTappedHandler
    {
        public CurrentWeekKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r?.Run<DateCalculator, UiReaderWriter>(
                (calc, uiRW) =>
                {
                    var start = calc.StartOfWeek();
                    var end = calc.Friday();
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.StartDate = start;
                            ui.EndDate = end;
                        });
                });
        }

        protected readonly MethodRunner runner;
    }
}
