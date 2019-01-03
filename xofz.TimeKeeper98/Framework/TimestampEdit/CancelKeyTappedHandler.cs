﻿namespace xofz.TimeKeeper98.Framework.TimestampEdit
{
    using xofz.Framework;

    public class CancelKeyTappedHandler
    {
        public CancelKeyTappedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            Do presentTimestamps,
            Do presentStatistics)
        {
            var w = this.web;
            w.Run<SettingsHolder>(
                sh =>
                {
                    switch (sh.LastVisitedKeyLabel)
                    {
                        case @"Timestamps":
                            presentTimestamps?.Invoke();
                            break;
                        case @"Statistics":
                            presentStatistics?.Invoke();
                            break;
                    }
                });
        }

        protected readonly MethodWeb web;
    }
}
