namespace xofz.TimeKeeper98.UI
{
    using System;
    using xofz.UI;

    public interface TimestampEditUi : Ui
    {
        event Do SaveKeyTapped;

        event Do CancelKeyTapped;

        string TimestampFormat { get; set; }

        DateTime EditedTimestamp { get; set; }
    }
}
