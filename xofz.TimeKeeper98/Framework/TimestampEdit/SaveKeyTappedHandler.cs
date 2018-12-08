﻿namespace xofz.TimeKeeper98.Framework.TimestampEdit
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
            TimestampEditUi ui,
            Do presentTimestamps,
            Do presentStatistics)
        {
            var w = this.web;
            w.Run<TimestampReader, UiReaderWriter>(
                (reader, rw) =>
                {
                    var newTimestamp = rw.Read(
                        ui,
                        () => ui.EditedTimestamp);
                    var allTimestamps = new LinkedList<DateTime>(
                        reader.Read());
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
                            rw.Write(
                                m.Subscriber,
                                () => m.GiveError(
                                    "Time must be after previous timestamp."));
                        });

                        return;
                    }

                    checkNow:
                    if (newTimestamp > DateTime.Now)
                    {
                        w.Run<Messenger>(m =>
                        {
                            rw.Write(
                                m.Subscriber,
                                () => m.GiveError(
                                    "Time must be before present time."));
                        });

                        return;
                    }

                    w.Run<TimestampWriter>(writer =>
                    {
                        writer.EditLastTimestamp(newTimestamp);
                    });

                    w.Run<SettingsHolder>(sh =>
                    {
                        switch (sh.LastVisitedKeyLabel)
                        {
                            case "Timestamps":
                                presentTimestamps();
                                break;
                            case "Statistics":
                                presentStatistics();
                                break;
                        }
                    });
                });
        }

        protected readonly MethodWeb web;
    }
}