namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.UI;

    public class InKeyTappedHandler
    {
        public InKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            w.Run<UiReaderWriter, TimestampWriter>(
                (uiRW, writer) =>
            {
                uiRW.WriteSync(
                    ui,
                    () => ui.InKeyVisible = false);
                if (!writer.Write())
                {
                    uiRW.Write(
                        ui,
                        () => ui.InKeyVisible = true);
                    return;
                }

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.OutKeyVisible = true;
                        ui.EditKeyEnabled = true;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}
