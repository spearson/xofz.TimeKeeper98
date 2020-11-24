namespace xofz.TimeKeeper98.Tests.Framework.Timestamps
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.Framework.Lots;
    using xofz.Framework.Lotters;
    using xofz.Framework.Transformation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Timestamps;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class StartHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new StartHandler(
                    this.web);
                this.ui = A.Fake<TimestampsUi>();
                this.uiReader = A.Fake<UiReader>();
                this.homeNavUi = A.Fake<HomeNavUi>();
                this.statsUi = A.Fake<StatisticsUi>();
                this.uiRW = new UiReaderWriter();
                this.settings = new SettingsHolder();
                this.provider = A.Fake<TimeProvider>();
                this.calc = A.Fake<DateCalculator>();
                this.stampReader = A.Fake<TimestampReader>();
                this.lotter = new LinkedListLotter();
                this.splitter = A.Fake<EnumerableSplitter>();
                this.splicer = A.Fake<EnumerableSplicer>();
                this.viewer = A.Fake<TimeSpanViewer>();

                var w = this.web;
                w.RegisterDependency(
                    this.uiReader);
                w.RegisterDependency(
                    this.uiRW);
                w.RegisterDependency(
                    this.settings);
                w.RegisterDependency(
                    this.provider);
                w.RegisterDependency(
                    this.calc);
                w.RegisterDependency(
                    this.stampReader);
                w.RegisterDependency(
                    this.lotter);
                w.RegisterDependency(
                    this.splitter);
                w.RegisterDependency(
                    this.splicer);
                w.RegisterDependency(
                    this.viewer);

                this.fixture = new Fixture();
                this.inTime = this.fixture.Create<DateTime>();
                this.outTime = this.inTime.AddHours(4);
                this.inTimes = new LinkedListLot<DateTime>(
                    new []
                    {
                        this.inTime
                    });
                this.outTimes = new LinkedListLot<DateTime>(
                    new[]
                    {
                        this.outTime
                    });

                A
                    .CallTo(() => this.splitter.Split(
                        A<IEnumerable<DateTime>>.Ignored,
                        2))
                    .Returns(
                        new[]
                        {
                            this.inTimes,
                            this.outTimes
                        });
                A
                    .CallTo(() => this.splicer.Splice(
                        A<Lot<DateTime>[]>.Ignored))
                    .Returns(
                        new LinkedListLot<DateTime>(
                            new[]
                            {
                                this.inTime,
                                this.outTime
                            }));
                A
                    .CallTo(() => this.calc.StartOfWeek())
                    .Returns(this.inTime.Date);
                A
                    .CallTo(() => this.calc.EndOfWeek())
                    .Returns(this.outTime.AddDays(1));
                this.statsUi.StartDate = this.inTime.Date;
                this.statsUi.EndDate = this.outTime.AddDays(1);
                A
                    .CallTo(() => this.stampReader.ReadAll())
                    .Returns(new[] {this.inTime, this.outTime});
            }

            protected readonly MethodWeb web;
            protected readonly StartHandler handler;
            protected readonly TimestampsUi ui;
            protected readonly UiReader uiReader;
            protected readonly HomeNavUi homeNavUi;
            protected readonly StatisticsUi statsUi;
            protected readonly UiReaderWriter uiRW;
            protected readonly SettingsHolder settings;
            protected readonly TimeProvider provider;
            protected readonly DateCalculator calc;
            protected readonly TimestampReader stampReader;
            protected readonly Lotter lotter;
            protected readonly EnumerableSplitter splitter;
            protected readonly EnumerableSplicer splicer;
            protected readonly TimeSpanViewer viewer;
            protected readonly DateTime inTime, outTime;
            protected readonly Lot<DateTime> inTimes, outTimes;
            protected readonly Fixture fixture;
        }

        public class When_Handle1_is_called : Context
        {
            [Fact]
            public void Calls_uiReader_ReadHomeNav()
            {
                this.handler.Handle(
                    this.ui);

                HomeNavUi hnUi;
                A
                    .CallTo(() => this.uiReader.ReadHomeNav(
                        out hnUi))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_uiReader_ReadStatistics()
            {
                this.handler.Handle(
                    this.ui);

                StatisticsUi sUi;
                A
                    .CallTo(() => this.uiReader.ReadStatistics(
                        out sUi))
                    .MustHaveHappened();
            }
        }

        public class When_Handle2_is_called : Context
        {
            [Fact]
            public void
                Sets_homeNavUi_ActiveKeyLabel_to_NavKeyLabels_Timestamps()
            {
                this.homeNavUi.ActiveKeyLabel = null;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                Assert.Equal(
                    NavKeyLabels.Timestamps,
                    this.homeNavUi.ActiveKeyLabel);
            }

            [Fact]
            public void Calls_provider_Now()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.provider.Now())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_show_current_calls_calc_StartOfWeek()
            {
                this.settings.ShowCurrent = true;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.calc.StartOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_calls_calc_EndOfWeek()
            {
                this.settings.ShowCurrent = true;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.calc.EndOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Otherwise_reads_statsUi_StartDate()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.statsUi.StartDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Also_reads_statsUi_EndDate()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.statsUi.EndDate)
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_stampReader_ReadAll()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.stampReader.ReadAll())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_splitter_Split()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.splitter.Split(
                        A<IEnumerable<DateTime>>.Ignored,
                        2))
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_InTimes()
            {
                this.ui.InTimes = null;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                Assert.NotNull(
                    this.ui.InTimes);
                Assert.Equal(
                    1,
                    this.ui.InTimes.Count);
            }

            [Fact]
            public void Sets_ui_OutTimes()
            {
                this.ui.OutTimes = null;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                Assert.NotNull(
                    this.ui.OutTimes);
                Assert.Equal(
                    1,
                    this.ui.OutTimes.Count);
            }

            [Fact]
            public void Calls_splicer_Splice()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.splicer.Splice(
                        A<Lot<DateTime>[]>.That.Contains(
                            this.inTimes)))
                    .MustHaveHappened();
                A
                    .CallTo(() => this.splicer.Splice(
                        A<Lot<DateTime>[]>.That.Contains(
                            this.outTimes)))
                    .MustHaveHappened();
            }

            [Fact]
            public void
                If_show_durations_calls_viewer_ReadableString_for_each_duration()
            {
                this.settings.ShowDurations = true;

                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.viewer.ReadableString(
                        this.outTime - this.inTime))
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_ui_SetSplicedInOutTimes()
            {
                this.handler.Handle(
                    this.ui,
                    this.homeNavUi,
                    this.statsUi);

                A
                    .CallTo(() => this.ui.SetSplicedInOutTimes(
                        A<Lot<string>>.Ignored))
                    .MustHaveHappened();
            }
        }
    }
}
