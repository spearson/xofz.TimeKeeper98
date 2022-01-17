namespace xofz.TimeKeeper98.Tests.Presentation
{
    using FakeItEasy;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.Presentation.NavLogicReaders;
    using Xunit;

    public class NavigatorNavLogicReaderTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.reader = new NavigatorNavLogicReader(
                    this.web);
                this.nav = A.Fake<Navigator>();
                var w = this.web;
                w.RegisterDependency(
                    this.nav);
            }

            protected readonly MethodWeb web;
            protected readonly NavLogicReader reader;
            protected readonly Navigator nav;
        }

        public class When_ReadTimestamps_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadTimestamps(
                    out var present);

                Assert.NotNull(present);
            }
        }

        public class When_ReadStatistics_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadStatistics(
                    out var present);

                Assert.NotNull(present);
            }
        }

        public class When_ReadDaily_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadDaily(
                    out var present);

                Assert.NotNull(present);
            }
        }

        public class When_ReadConfig_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadConfig(
                    out var present);

                Assert.NotNull(present);
            }
        }

        public class When_ReadLicense_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadLicense(
                    out var present);

                Assert.NotNull(present);
            }
        }

        public class When_ReadExit_is_called : Context
        {
            [Fact]
            public void Assigns_the_value()
            {
                this.reader.ReadExit(
                    out var present);

                Assert.NotNull(present);
            }
        }
    }
}
