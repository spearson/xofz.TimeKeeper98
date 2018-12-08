namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using System;
    using System.Collections.Generic;
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.UI;

    public class StartHandler
    {
        public StartHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            TimestampEditUi ui,
            HomeNavUi hnUi,
            HomeUi homeUi)
        {
            var w = this.web;
            w.Run<TimestampReader, UiReaderWriter>(
                (reader, rw) =>
                {
                    var ll = new LinkedList<DateTime>(reader.Read());
                    if (ll.Count < 1)
                    {
                        return;
                    }

                    var lastTimestamp = ll
                        .Last
                        .Value;
                    rw.Write(
                        ui,
                        () => ui.EditedTimestamp = lastTimestamp);
            });

            w.Run<UiReaderWriter, SettingsHolder>(
                (rw, sh) =>
                {
                    sh.LastVisitedKeyLabel = rw.Read(
                        hnUi,
                        () => hnUi.ActiveKeyLabel);
                    rw.Write(
                        hnUi,
                        () => hnUi.ActiveKeyLabel = null);
                });

            w.Run<UiReaderWriter>(rw =>
            {
                rw.Write(
                    homeUi,
                    () => homeUi.Editing = true);
            });
        }

        protected readonly MethodWeb web;
    }
}
