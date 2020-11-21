namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using Xunit;

    public class NavigatorUiReaderTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.reader = new NavigatorUiReader(
                    this.web);
                this.nav = A.Fake<Navigator>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.statsUi = A.Fake<StatisticsUi>();

                var w = this.web;
                w.RegisterDependency(
                    this.nav);
                A
                    .CallTo(() => this.nav.GetUi<HomeNavPresenter, HomeNavUi>(
                        null,
                        Presenter.DefaultUiFieldName))
                    .Returns(this.homeNavUi);
                A
                    .CallTo(() =>
                        this.nav.GetUi<StatisticsPresenter, StatisticsUi>(
                            null,
                            Presenter.DefaultUiFieldName))
                    .Returns(this.statsUi);
            }

            protected readonly MethodWeb web;
            protected readonly UiReader reader;
            protected readonly Navigator nav;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
        }

        public class When_ReadHomeNav_is_called : Context
        {
            [Fact]
            public void Reads_the_home_nav_ui()
            {
                this.reader.ReadHomeNav(
                    out var ui);

                Assert.Same(
                    ui,
                    this.homeNavUi);
            }
        }

        public class When_ReadStatistics_is_called : Context
        {
            [Fact]
            public void Reads_the_stats_ui()
            {
                this.reader.ReadStatistics(
                    out var ui);

                Assert.Same(
                    ui,
                    this.statsUi);
            }
        }
    }
}
