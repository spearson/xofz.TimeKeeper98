namespace xofz.TimeKeeper98.Framework
{
    using System;

    public class TimeSpanViewer
    {
        public virtual string ReadableString(TimeSpan timeSpan)
        {
            return (long)timeSpan.TotalHours + "h "
                   + timeSpan.Minutes + "m "
                   + timeSpan.Seconds + "s";
        }
    }
}
