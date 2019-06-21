namespace xofz.TimeKeeper98.UI
{
    using System;
    using xofz.UI;

    public interface TimestampEditUi : Ui
    {
        event Do SaveKeyTapped;

        event Do CancelKeyTapped;

        event Do SaveCurrentKeyTapped;

        DateTime EditedTimestamp { get; set; }

        string TimestampFormat { get; set; }
    }
}
