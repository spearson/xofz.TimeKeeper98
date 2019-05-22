namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.UI;

    public class InKeyTappedHandler
    {
        public InKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var r = this.runner;
            var accepted = true;
            r.Run<GlobalSettingsHolder>(settings =>
            {
                if (settings.Prompt)
                {
                    r.Run<UiReaderWriter, Messenger>((uiRW, m) =>
                    {
                        accepted = uiRW.Read(
                                       m.Subscriber,
                                       () => m.Question(
                                           @"Really clock in?")) ==
                                   Response.Yes;
                    });
                }
            });

            if (!accepted)
            {
                return;
            }

            r.Run<xofz.Framework.Timer>(t =>
                {
                    t.Stop();
                    r.Run<LatchHolder>(timerLatch =>
                        {
                            timerLatch.Latch.WaitOne();
                        }
                        , DependencyNames.Latch);
                },
                DependencyNames.Timer);

            r.Run<
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

            r.Run<StartHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodRunner runner;
    }
}
