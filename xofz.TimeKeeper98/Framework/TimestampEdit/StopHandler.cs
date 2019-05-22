namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.UI;

    public class StopHandler
    {
        public StopHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeUi homeUi)
        {
            var w = this.runner;
            w.Run<UiReaderWriter>(uiRW =>
            {
                uiRW.Write(
                    homeUi,
                    () =>
                    {
                        homeUi.Editing = false;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
