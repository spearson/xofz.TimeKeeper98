namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHandler
    {
        public SetupHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var r = this.runner;
            r?.Run<GlobalSettingsHolder, UiReaderWriter>(
                (settings, uiRW) =>
                {
                    var format = settings.EditTimestampFormat;
                    uiRW.Write(
                        ui,
                        () =>
                        {
                            ui.TimestampFormat = format;
                        });
                });
        }

        protected readonly MethodRunner runner;
    }
}
