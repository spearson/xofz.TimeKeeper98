using xofz.UI;

namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class SetupHandler
    {
        public SetupHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var w = this.web;
            w.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, rw) =>
                {
                    var format = settings.TimestampFormat;
                    rw.Write(
                        ui,
                        () => ui.TimestampFormat = format);
                });
        }

        protected readonly MethodWeb web;
    }
}
