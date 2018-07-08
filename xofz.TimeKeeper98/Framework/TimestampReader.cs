namespace xofz.TimeKeeper98.Framework
{
    using System;
    using System.Collections.Generic;

    public interface TimestampReader
    {
        IEnumerable<DateTime> Read();
    }
}
