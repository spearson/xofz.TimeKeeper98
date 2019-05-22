namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var r = this.runner;
            r.Run<DateCalculator, UiReaderWriter>(
                (calc, uiRW) =>
            {
                var startOfWeek = calc.StartOfWeek();
                var endOfWeek = calc.Friday();
                uiRW.WriteSync(
                    ui,
                    () =>
                    {
                        ui.StartDate = startOfWeek;
                        ui.EndDate = endOfWeek;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
