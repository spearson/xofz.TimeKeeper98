namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.UI;

    public class OutKeyTappedHandler
    {
        public OutKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            w.Run<
                UiReaderWriter, 
                TimestampWriter,
                DataWatcher>(
                (uiRW, writer, watcher) =>
            {
                uiRW.WriteSync(
                    ui,
                    () => ui.OutKeyVisible = false);
                watcher.Stop();
                if (!writer.Write())
                {
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.OutKeyVisible = true;
                        });
                    watcher.Start();;
                    return;
                }

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.InKeyVisible = true;
                        ui.EditKeyEnabled = true;
                    });
                watcher.Start();
            });
        }

        protected readonly MethodWeb web;
    }
}
