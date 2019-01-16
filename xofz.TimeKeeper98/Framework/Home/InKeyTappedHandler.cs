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
            w.Run<
                UiReaderWriter, 
                TimestampWriter,
                DataWatcher>(
                (uiRW, writer, watcher) =>
            {
                uiRW.WriteSync(
                    ui,
                    () => ui.InKeyVisible = false);
                watcher.Stop();
                if (!writer.Write())
                {
                    uiRW.Write(
                        ui,
                        () => ui.InKeyVisible = true);
                    watcher.Start();
                    return;
                }

                uiRW.Write(
                    ui,
                    () =>
                    {
                        ui.OutKeyVisible = true;
                        ui.EditKeyEnabled = true;
                    });
                watcher.Start();
            });
        }

        protected readonly MethodWeb web;
    }
}
