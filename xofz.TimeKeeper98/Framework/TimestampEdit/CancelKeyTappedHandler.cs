namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class CancelKeyTappedHandler
    {
        public CancelKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            Do presentTimestamps,
            Do presentStatistics,
            Do presentDaily)
        {
            var w = this.web;
            w.Run<SettingsHolder>(
                sh =>
                {
                    switch (sh.LastVisitedKeyLabel)
                    {
                        case NavKeyLabels.Timestamps:
                            presentTimestamps?.Invoke();
                            break;
                        case NavKeyLabels.Statistics:
                            presentStatistics?.Invoke();
                            break;
                        case NavKeyLabels.Daily:
                            presentDaily?.Invoke();
                            break;
                    }
                });
        }

        protected readonly MethodWeb web;
    }
}
