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
            w.Run<xofz.Framework.Timer>(t =>
                {
                    t.Stop();
                    w.Run<LatchHolder>(timerLatch =>
                        {
                            timerLatch.Latch.WaitOne();
                        }
                        , DependencyNames.Latch);
                },
                DependencyNames.Timer);
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
                writer.Write();
                watcher.Start();
            });
            w.Run<StartHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodWeb web;
    }
}
