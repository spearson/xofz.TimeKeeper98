namespace xofz.TimeKeeper98.Framework.TimeSpanViewers
{
    using System;

    public class MinutesTimeSpanViewer : TimeSpanViewer
    {
        public override string ReadableString(TimeSpan timeSpan)
        {
            return (long) timeSpan.TotalHours
                   + "h "
                   + timeSpan.Minutes
                   + 'm';
        }
    }
}
