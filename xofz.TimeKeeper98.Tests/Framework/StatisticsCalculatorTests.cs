namespace xofz.TimeKeeper98.Tests.Framework
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using Xunit;
    using Xunit.Abstractions;

    public class StatisticsCalculatorTests
    {
        public class Context
        {
            static Context()
            {
                for (var i = 0; i < timestampCount; ++i)
                {
                    allOfTheTimes.Add(
                        fixture.Create<DateTime>());
                }
            }

            protected Context()
            {
                this.web = new MethodWebV2();
                this.calc = new TestStatsCalc(
                    this.web);
                this.dateCalc = new DateCalculator();
                this.reader = A.Fake<TimestampReader>();
                this.provider = new TimeProvider();

                var w = this.web;
                w.RegisterDependency(
                    this.dateCalc);
                w.RegisterDependency(
                    this.reader);
                w.RegisterDependency(
                    this.provider);

                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(allOfTheTimes);
            }

            protected readonly MethodWebV2 web;
            protected readonly TestStatsCalc calc;
            protected TimeProvider provider;
            protected readonly TimestampReader reader;
            protected DateCalculator dateCalc;
            protected static Fixture fixture = new Fixture();

            protected static readonly ICollection<DateTime> allOfTheTimes
                = new LinkedList<DateTime>();

            protected const short timestampCount = 0xFFF;
        }

        public class TestStatsCalc
            : StatisticsCalculator
        {
            public TestStatsCalc(
                MethodRunner runner)
                : base(runner)
            {
            }

            public virtual ICollection<DateTime> AllOfThem()
            {
                return this.allTimes();
            }
        }

        public class When_ClockedIn_is_called : Context
        {
            [Fact]
            public void Returns_true_if_odd_count()
            {
                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(
                        new[]
                        {
                            DateTime.Now
                        });

                Assert.True(
                    this.calc.ClockedIn());
            }

            [Fact]
            public void Returns_false_if_even()
            {
                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(
                        new[]
                        {
                            new DateTime(1999, 12, 31, 11, 59, 59),
                            DateTime.Now
                        });

                Assert.False(
                    this.calc.ClockedIn());
            }
        }

        public class When_allTimes_is_called : Context
        {
            public When_allTimes_is_called(
                ITestOutputHelper outputter)
            {
                this.outputter = outputter;
            }

            [Fact]
            public void Calls_reader_ReadAll()
            {
                this.calc.AllOfThem();

                A
                    .CallTo(() => this.reader.ReadAll())
                    .MustHaveHappened();
            }

            [Fact]
            public void Returns_all_of_them()
            {
                this.outputter.WriteLine(
                    timestampCount.ToString());
                Assert.Equal(
                    timestampCount,
                    this.calc.AllOfThem()?.Count ?? 0);
            }

            protected readonly ITestOutputHelper outputter;
        }

        public class When_TimeWorkedThisWeek_is_called : Context
        {
            public When_TimeWorkedThisWeek_is_called()
            {
                this.dateCalc = A.Fake<DateCalculator>();
                var w = this.web;
                w.RegisterDependency(
                    this.dateCalc);
                w.Unregister<DateCalculator>();
            }

            [Fact]
            public void Calls_dateCalc_StartOfWeek()
            {
                this.calc.TimeWorkedThisWeek();

                A
                    .CallTo(() => this.dateCalc.StartOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void Calls_dateCalc_EndOfWeek()
            {
                this.calc.TimeWorkedThisWeek();

                A
                    .CallTo(() => this.dateCalc.EndOfWeek())
                    .MustHaveHappened();
            }

            [Fact]
            public void If_no_dateCalc_returns_TimeSpan_Zero()
            {
                this.web.Unregister<DateCalculator>();

                Assert.Equal(
                    TimeSpan.Zero,
                    this.calc.TimeWorkedThisWeek());
            }

            [Fact]
            public void Otherwise_returns_time_worked_for_the_week()
            {
                var w = this.web;
                w.Unregister<DateCalculator>();
                w.RegisterDependency(
                    A.Fake<DateCalculator>());
                w.Run<DateCalculator>(fakeDater =>
                {
                    A
                        .CallTo(() => fakeDater.StartOfWeek())
                        .Returns(new DateTime(
                            2020,
                            11,
                            24));
                    A
                        .CallTo(() => fakeDater.EndOfWeek())
                        .Returns(new DateTime(
                            2020,
                            11,
                            25));
                });

                var allTimes = new LinkedList<DateTime>(new[]
                {
                    new DateTime(2020, 11, 24, 7, 0, 0),
                    new DateTime(2020, 11, 24, 1, 45, 0),
                    new DateTime(2020, 11, 24, 2, 40, 0),
                    new DateTime(2020, 11, 24, 5, 40, 0),
                });
                A
                    .CallTo(() => this.reader.ReadAll())
                    .Returns(allTimes);

                Assert.Equal(
                    new TimeSpan(0, 2, 15, 0),
                    this.calc.TimeWorkedThisWeek());
            }
        }
    }
}
