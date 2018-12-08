﻿namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.UI;
    using xofz.TimeKeeper98.UI;

    public class OutKeyTappedHandler
    {
        public OutKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            HomeUi ui)
        {
            var w = this.web;
            w.Run<UiReaderWriter, TimestampWriter>(
                (rw, writer) =>
            {
                rw.WriteSync(
                    ui,
                    () =>
                    {
                        ui.OutKeyVisible = false;
                    });

                if (!writer.Write())
                {
                    rw.WriteSync(
                        ui,
                        () =>
                        {
                            ui.OutKeyVisible = true;
                        });
                    return;
                }

                rw.WriteSync(
                    ui,
                    () =>
                    {
                        ui.InKeyVisible = true;
                        ui.EditKeyEnabled = true;
                    });
            });
        }

        protected readonly MethodWeb web;
    }
}