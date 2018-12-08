namespace xofz.TimeKeeper98.Framework.Statistics
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            StatisticsUi ui)
        {
            var w = this.web;
            w.Run<DateCalculator, UiReaderWriter>((calc, rw) =>
            {
                var startOfWeek = calc.StartOfWeek();
                var endOfWeek = calc.Friday();
                rw.WriteSync(
                    ui,
                    () =>
                    {
                        ui.StartDate = startOfWeek;
                        ui.EndDate = endOfWeek;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
