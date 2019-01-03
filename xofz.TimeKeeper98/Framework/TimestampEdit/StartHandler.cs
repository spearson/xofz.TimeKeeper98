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
            w.Run<UiReaderWriter>(uiRW =>
            {
                w.Run<TimestampReader>(reader =>
                    {
                        var allColl = reader.ReadAll();

                        var ll = allColl as LinkedList<DateTime>
                                 ?? new LinkedList<DateTime>(allColl);
                        if (ll.Count < 1)
                        {
                            return;
                        }

                        var lastTimestamp = ll
                            .Last
                            .Value;
                        uiRW.Write(
                            ui,
                            () => ui.EditedTimestamp = lastTimestamp);
                    });

                w.Run<SettingsHolder>(settings =>
                    {
                        settings.LastVisitedKeyLabel = uiRW.Read(
                            hnUi,
                            () => hnUi.ActiveKeyLabel);
                        uiRW.Write(
                            hnUi,
                            () => hnUi.ActiveKeyLabel = null);
                    });

                uiRW.Write(
                    homeUi,
                    () => homeUi.Editing = true);
            });
        }

        protected readonly MethodWeb web;
    }
}
