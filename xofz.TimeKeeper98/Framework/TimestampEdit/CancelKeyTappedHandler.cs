namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class CancelKeyTappedHandler
    {
        public CancelKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle()
        {
            var r = this.runner;
            r.Run<SettingsHolder, NavLogicReader>(
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
                        case NavKeyLabels.Config:
                            navReader.ReadConfig(
                                out var navToConfig);
                            navToConfig?.Invoke();
                            break;
                    }
                });
        }

        protected readonly MethodRunner runner;
    }
}
