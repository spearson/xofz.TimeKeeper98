﻿namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface ConfigUi : Ui
    {
        event Do PromptSelected;

        event Do PromptUnselected;

        event Do KeyboardKeyTapped;

        event Do SaveTitleTextKeyTapped;

        event Do ResetTitleTextKeyTapped;

        event Do DefaultTitleTextKeyTapped;

        event Do ShowSecondsSelected;

        event Do ShowSecondsUnselected;

        bool PromptChecked { get; set; }

        bool ShowSecondsChecked { get; set; }

        string TitleText { get; set; }

        void FocusTitleTextTextBox();
    }
}