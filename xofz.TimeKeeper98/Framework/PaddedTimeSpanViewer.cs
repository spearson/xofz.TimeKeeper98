namespace xofz.TimeKeeper98.Framework
{
    using System;

    public class PaddedTimeSpanViewer
    {
        public virtual string ReadableString(TimeSpan timeSpan)
        {
            return ((long)timeSpan.TotalHours).ToString().PadLeft(3)
                   + "h "
                   + timeSpan.Minutes.ToString().PadLeft(2) 
                   + "m "
                   + timeSpan.Seconds.ToString().PadLeft(2) 
                   + 's';
        }
    }
}
