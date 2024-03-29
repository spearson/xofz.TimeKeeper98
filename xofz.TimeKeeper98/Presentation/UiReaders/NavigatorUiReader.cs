﻿namespace xofz.TimeKeeper98.Presentation.UiReaders
{
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Presentation.Presenters;
    using xofz.TimeKeeper98.UI;

    public sealed class NavigatorUiReader 
        : UiReader
    {
        public NavigatorUiReader(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        void UiReader.ReadHomeNav(
            out HomeNavUi ui)
        {
            var nav = this.runner?.Run<Navigator>();
            if (nav == null)
            {
                ui = null;
                return;
            }

            ui = nav.GetUi<HomeNavPresenter, HomeNavUi>();
        }

        void UiReader.ReadStatistics(
            out StatisticsUi ui)
        {
            var nav = this.runner?.Run<Navigator>();
            if (nav == null)
            {
                ui = null;
                return;
            }

            ui = nav.GetUi<StatisticsPresenter, StatisticsUi>();
        }

        private readonly MethodRunner runner;
    }
}
