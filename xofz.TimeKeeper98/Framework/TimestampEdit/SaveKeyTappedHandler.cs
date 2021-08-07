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
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampEditUi ui)
        {
            var r = this.runner;
            var accepted = true;
            r?.Run<UiReaderWriter, GlobalSettingsHolder, Messenger>(
                (uiRW, settings, m) =>
                {
                    if (settings.Prompt)
                    {
                        var response = uiRW.Read(
                            m.Subscriber,
                            () => m.Question(@"Save edit?"));
                        accepted = response == Response.Yes;
                    }
                });
            if (!accepted)
            {
                return;
            }

            r?.Run<
                TimestampReader, 
                UiReaderWriter>(
                (reader, uiRW) =>
                {
                    var newTimestamp = uiRW.Read(
                        ui,
                        () => ui.EditedTimestamp);
                    var allColl = reader.ReadAll();
                    var allLL = allColl as LinkedList<DateTime>
                                        ?? new LinkedList<DateTime>(allColl);
                    const byte two = 2;
                    if (allLL.Count < two)
                    {
                        goto checkNow;
                    }

                    var previousTimestamp = allLL
                        .Last
                        ?.Previous
                        ?.Value;
                    if (newTimestamp < previousTimestamp)
                    {
                        r.Run<Messenger>(m =>
                        {
                            uiRW.Write(
                                m.Subscriber,
                                () =>
                                {
                                    m.GiveError(
                                        ErrorMessages.TooEarly);
                                });
                        });

                        return;
                    }

                    checkNow:
                    var now = DateTime.Now;
                    r.Run<TimeProvider>(provider =>
                    {
                        now = provider.Now();
                    });

                    if (newTimestamp > now)
                    {
                        r.Run<Messenger>(m =>
                        {
                            uiRW.Write(
                                m.Subscriber,
                                () =>
                                {
                                    m.GiveError(
                                        ErrorMessages.TooLate);
                                });
                        });

                        return;
                    }

                    r.Run<DataWatcher, TimestampWriter>(
                        (watcher, writer) =>
                    {
                        watcher.Stop();
                        writer.EditLastTimestamp(newTimestamp);
                        watcher.Start();
                    });

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
                            default:
                                navReader.ReadTimestamps(
                                    out var defaultNav);
                                defaultNav?.Invoke();
                                break;
                        }
                    });
                });
        }

        protected readonly MethodRunner runner;
    }
}
