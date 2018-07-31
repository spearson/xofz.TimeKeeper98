namespace xofz.TimeKeeper98.Framework
{
    using System;

    public interface TimestampWriter
    {
        void Write();

        void EditLastTimestamp(DateTime newTimestamp);
    }
}
