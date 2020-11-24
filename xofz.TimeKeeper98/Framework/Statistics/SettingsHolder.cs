namespace xofz.TimeKeeper98.Framework.Statistics
{
    using System;

    public class SettingsHolder
    {
        public virtual TimeSpan WeekLength { get; set; }
            = TimeSpan.FromDays(7);
    }
}
