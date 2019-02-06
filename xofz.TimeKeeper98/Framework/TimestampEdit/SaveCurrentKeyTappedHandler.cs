namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using System;
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveCurrentKeyTappedHandler
    {
        public SaveCurrentKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var w = this.web;
            w.Run<UiReaderWriter>(uiRW =>
            {
                var currentTime = DateTime.Now;
                uiRW.WriteSync(
                    ui,
                    () => ui.EditedTimestamp = currentTime);
            });

            w.Run<SaveKeyTappedHandler>(handler =>
            {
                handler.Handle(ui);
            });
        }

        protected readonly MethodWeb web;
    }
}
