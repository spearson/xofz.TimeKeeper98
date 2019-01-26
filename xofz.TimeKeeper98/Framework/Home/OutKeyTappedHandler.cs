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

            var accepted = true;
            w.Run<GlobalSettingsHolder>(settings =>
            {
                if (settings.Prompt)
                {
                    w.Run<UiReaderWriter, Messenger>((uiRW, m) =>
                    {
                        accepted = uiRW.Read(
                                       m.Subscriber,
                                       () => m.Question(
                                           @"Really clock out?")) ==
                                   Response.Yes;
                    });
                }
            });

            if (!accepted)
            {
                return;
            }

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
                    () => ui.OutKeyVisible = false);
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
