namespace xofz.TimeKeeper98.Framework
{
    using System;

    public interface TimestampWriter
    {
        bool Write();

        void EditLastTimestamp(DateTime newTimestamp);
    }
}
