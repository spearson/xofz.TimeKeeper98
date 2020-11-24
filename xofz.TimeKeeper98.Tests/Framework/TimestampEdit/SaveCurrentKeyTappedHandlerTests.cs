namespace xofz.TimeKeeper98.Tests.Framework.TimestampEdit
{
    using System;
    using FakeItEasy;
    using Ploeh.AutoFixture;
    using xofz.Framework;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.TimestampEdit;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;
    using Xunit;

    public class SaveCurrentKeyTappedHandlerTests
    {
        public class Context
        {
            protected Context()
            {
                this.web = new MethodWeb();
                this.handler = new SaveCurrentKeyTappedHandler(
                    this.web);
                this.ui = A.Fake<TimestampEditUi>();
                this.uiRW = new UiReaderWriter();
                this.provider = A.Fake<TimeProvider>();
                this.saveHandler = A.Fake<SaveKeyTappedHandler>();
                this.fixture = new Fixture();

                var w = this.web;
                w.RegisterDependency(
                    this.provider);
                w.RegisterDependency(
                    this.saveHandler);
                w.RegisterDependency(
                    this.uiRW);
            }

            protected readonly MethodWeb web;
            protected readonly SaveCurrentKeyTappedHandler handler;
            protected readonly TimestampEditUi ui;
            protected readonly UiReaderWriter uiRW;
            protected readonly TimeProvider provider;
            protected readonly SaveKeyTappedHandler saveHandler;
            protected readonly Fixture fixture;
        }

        public class When_Handle_is_called : Context
        {
            [Fact]
            public void Reads_provider_Now()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.provider.Now())
                    .MustHaveHappened();
            }

            [Fact]
            public void Sets_ui_EditedTimestamp()
            {
                var now = this.fixture.Create<DateTime>();
                A
                    .CallTo(() => this.provider.Now())
                    .Returns(now);
                this.ui.EditedTimestamp = DateTime.MinValue;

                this.handler.Handle(
                    this.ui);

                Assert.Equal(
                    now,
                    this.ui.EditedTimestamp);
            }

            [Fact]
            public void Calls_saveHandler_Handle()
            {
                this.handler.Handle(
                    this.ui);

                A
                    .CallTo(() => this.saveHandler.Handle(
                        this.ui))
                    .MustHaveHappened();
            }
        }
    }
}
