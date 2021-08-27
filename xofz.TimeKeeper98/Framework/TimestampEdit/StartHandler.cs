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
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            TimestampEditUi ui,
            HomeNavUi hnUi,
            HomeUi homeUi)
        {
            var r = this.runner;
            r?.Run<UiReaderWriter>(uiRW =>
            {
                r.Run<TimestampReader>(reader =>
                    {
                        var allColl = reader.ReadAll();

                        var ll = allColl as XLinkedList<DateTime>
                                 ?? XLinkedList<DateTime>.Create(allColl);
                        const byte one = 1;
                        if (ll.Count < one)
                        {
                            return;
                        }

                        var lastTimestamp = ll
                            .Tail;
                        uiRW.Write(
                            ui,
                            () =>
                            {
                                ui.EditedTimestamp = lastTimestamp;
                            });
                    });

                r.Run<SettingsHolder>(settings =>
                    {
                        settings.LastVisitedKeyLabel = uiRW.Read(
                            hnUi,
                            () => hnUi.ActiveKeyLabel);
                        uiRW.Write(
                            hnUi,
                            () =>
                            {
                                hnUi.ActiveKeyLabel = null;
                            });
                    });

                uiRW.Write(
                    homeUi,
                    () =>
                    {
                        homeUi.Editing = true;
                    });
            });
        }

        protected readonly MethodRunner runner;
    }
}
