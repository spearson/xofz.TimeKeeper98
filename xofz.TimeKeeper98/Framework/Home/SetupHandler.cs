namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            
            w.Run<
                StatisticsCalculator,
                TimestampReader,
                UiReaderWriter>(
                (calc, reader, rw) =>
            {
                var currentlyIn = calc.ClockedIn();
                var editKeyEnabled = false;
                foreach (var timestamp in reader.Read())
                {
                    editKeyEnabled = true;
                    break;
                }

                rw.Write(ui, () =>
                {
                    ui.InKeyVisible = !currentlyIn;
                    ui.OutKeyVisible = currentlyIn;
                    ui.EditKeyEnabled = editKeyEnabled;
                });
            });

            w.Run<VersionReader, UiReaderWriter>((vr, rw) =>
            {
                var appVersion = vr.Read();
                var coreVersion = vr.ReadCoreVersion();
                rw.Write(
                    ui,
                    () =>
                    {
                        ui.Version = appVersion;
                        ui.CoreVersion = coreVersion;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
