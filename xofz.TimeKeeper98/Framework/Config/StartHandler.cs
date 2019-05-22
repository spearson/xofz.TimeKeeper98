namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r.Run<UiReader, UiReaderWriter>((reader, uiRW) =>
            {
                reader.ReadHomeNav(out var homeNavUi);
                uiRW.Write(
                    homeNavUi,
                    () =>
                    {
                        homeNavUi.ActiveKeyLabel = NavKeyLabels.Config;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
