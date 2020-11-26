namespace xofz.TimeKeeper98.Tests.Framework
{
    using System;
    using FakeItEasy;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using Xunit;

    public class DateCalculatorTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWebV2();
                this.calc = new DateCalculator(
                    this.web);
                this.provider = new TimeProvider();

                var w = this.web;
                w.RegisterDependency(
                    this.provider);
            }

            protected TimeProvider provider;
            protected readonly MethodWebV2 web;
            protected readonly DateCalculator calc;
        }

        public class When_StartOfWeek_is_called : Context
        {
            [Fact]
            public void Hits_provider_Now()
            {
                this.provider = A.Fake<TimeProvider>();
                var w = this.web;
                w.RegisterDependency(
                    this.provider);
                w.Unregister<TimeProvider>();

                this.calc.StartOfWeek();

                A
                    .CallTo(() => this.provider.Now())
                    .MustHaveHappened();
            }

            [Fact]
            public void Returns_Monday()
            {
                Assert.Equal(
                    DayOfWeek.Monday,
                    this.calc.StartOfWeek().DayOfWeek);
            }
        }

        public class When_EndOfWeek_is_called : Context
        {
            [Fact]
            public void Returns_Sunday()
            {
                Assert.Equal(
                    DayOfWeek.Sunday,
                    this.calc.EndOfWeek().DayOfWeek);
            }
        }
    }
}
