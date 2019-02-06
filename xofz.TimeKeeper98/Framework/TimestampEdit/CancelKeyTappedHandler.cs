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

        public virtual void Handle()
        {
            var w = this.web;
            w.Run<SettingsHolder, NavLogicReader>(
                (settings, navReader) =>
                {
                    switch (settings.LastVisitedKeyLabel)
                    {
                        case NavKeyLabels.Timestamps:
                            navReader.ReadTimestamps(
                                out var navToTimestamps);
                            navToTimestamps?.Invoke();
                            break;
                        case NavKeyLabels.Statistics:
                            navReader.ReadStatistics(
                                out var navToStats);
                            navToStats?.Invoke();
                            break;
                        case NavKeyLabels.Daily:
                            navReader.ReadDaily(
                                out var navToDaily);
                            navToDaily?.Invoke();
                            break;
                    }
                });
        }

        protected readonly MethodWeb web;
    }
}
