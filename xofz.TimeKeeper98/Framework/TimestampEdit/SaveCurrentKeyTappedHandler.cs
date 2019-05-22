namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using System;
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveCurrentKeyTappedHandler
    {
        public SaveCurrentKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var r = this.runner;
            r.Run<UiReaderWriter>(uiRW =>
            {
                var currentTime = DateTime.Now;
                uiRW.WriteSync(
                    ui,
                    () =>
                    {
                        ui.EditedTimestamp = currentTime;
                    });
            });
            r.Run<SaveKeyTappedHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodRunner runner;
    }
}
