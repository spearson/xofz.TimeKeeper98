namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<UiReader, UiReaderWriter>((reader, uiRW) =>
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

        protected readonly MethodWeb web;
    }
}
