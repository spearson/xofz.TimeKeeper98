namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface ConfigUi 
        : Ui
    {
        event Do PromptSelected;

        event Do PromptUnselected;

        event Do KeyboardKeyTapped;

        event Do SaveTitleTextKeyTapped;

        event Do ResetTitleTextKeyTapped;

        event Do DefaultTitleTextKeyTapped;

        event Do ShowSecondsSelected;

        event Do ShowSecondsUnselected;

        event Do SaveIntervalKeyTapped;

        event Do ResetIntervalKeyTapped;

        event Do PublishKeyTapped;

        bool PromptChecked { get; set; }

        bool ShowSecondsChecked { get; set; }

        int TimerIntervalSeconds { get; set; }

        string TitleText { get; set; }

        string TotalTimestampCount { get; set; }

        string InRangeTimestampCount { get; set; }

        string ThisWeekTimestampCount { get; set; }

        void FocusTitleTextTextBox();
    }
}
