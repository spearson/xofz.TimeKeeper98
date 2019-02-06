namespace xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers
{
    using System;

    public class PaddedMinutesTimeSpanViewer : PaddedTimeSpanViewer
    {
        public override string ReadableString(TimeSpan timeSpan)
        {
            return ((long)timeSpan.TotalHours).ToString().PadLeft(3)
                   + "h "
                   + timeSpan.Minutes.ToString().PadLeft(2)
                   + 'm';
        }
    }
}
