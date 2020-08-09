namespace xofz.TimeKeeper98.Framework
{
    using System;

    public class TimeProvider
    {
        public virtual DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
