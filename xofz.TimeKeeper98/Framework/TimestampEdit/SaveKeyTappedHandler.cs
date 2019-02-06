namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using System;
    using System.Collections.Generic;
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SaveKeyTappedHandler
    {
        public SaveKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var w = this.web;
            w.Run<
                TimestampReader, 
                UiReaderWriter>(
                (reader, uiRW) =>
                {
                    var newTimestamp = uiRW.Read(
                        ui,
                        () => ui.EditedTimestamp);
                    var allColl = reader.ReadAll();
                    var allTimestamps = allColl as LinkedList<DateTime>
                                        ?? new LinkedList<DateTime>(allColl);
                    if (allTimestamps.Count < 2)
                    {
                        goto checkNow;
                    }

                    var previousTimestamp = allTimestamps
                        .Last
                        ?.Previous
                        ?.Value;
                    if (newTimestamp < previousTimestamp)
                    {
                        w.Run<Messenger>(m =>
                        {
                            uiRW.Write(
                                m.Subscriber,
                                () => m.GiveError(
                                    ErrorMessages.TooEarly));
                        });

                        return;
                    }

                    checkNow:
                    if (newTimestamp > DateTime.Now)
                    {
                        w.Run<Messenger>(m =>
                        {
                            uiRW.Write(
                                m.Subscriber,
                                () => m.GiveError(
                                    ErrorMessages.TooLate));
                        });

                        return;
                    }

                    w.Run<DataWatcher, TimestampWriter>(
                        (watcher, writer) =>
                    {
                        watcher.Stop();
                        writer.EditLastTimestamp(newTimestamp);
                        watcher.Start();
                    });

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
                            case NavKeyLabels.Config:
                                navReader.ReadConfig(
                                    out var navToConfig);
                                navToConfig?.Invoke();
                                break;
                        }
                    });
                });
        }

        protected readonly MethodWeb web;
    }
}
