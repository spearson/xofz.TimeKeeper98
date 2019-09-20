namespace xofz.TimeKeeper98.Root.Commands
{
    using System;
    using System.Reflection;
    using System.Threading;
    using xofz.Framework;
    using xofz.Framework.Transformation;
    using xofz.Root;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.DataWatchers;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.Framework.PaddedTimeSpanViewers;
    using xofz.TimeKeeper98.Framework.TimeSpanViewers;
    using xofz.TimeKeeper98.Presentation;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public class SetupHomeCommand : Command
    {
        public SetupHomeCommand(
            HomeUi ui,
            ShellUi shell,
            Gen<MethodRunner, TimestampReaderWriter> newReaderWriter,
            MethodWeb web)
        {
            this.ui = ui;
            this.shell = shell;
            this.newReaderWriter = newReaderWriter;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();

            var w = this.web;
            new HomePresenter(
                    this.ui,
                    this.shell,
                    w)
                .Setup();

            new FileDataWatcher(
                    w)
                .Setup();
        }

        protected virtual void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new DateCalculator());
            w.RegisterDependency(
                new EnumerableTrapper<DateTime>());
            w.RegisterDependency(
                this.newReaderWriter?.Invoke(w));
            w.RegisterDependency(
                new FieldHolder());
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                DependencyNames.Timer);
            w.RegisterDependency(
                new MinutesTimeSpanViewer());
            w.RegisterDependency(
                new MinutesPaddedTimeSpanViewer());
            w.RegisterDependency(
                new StatisticsCalculator(w));
            w.RegisterDependency(
                new VersionReader(
                    Assembly.GetExecutingAssembly()));
            w.RegisterDependency(
                new InKeyTappedHandler(w));
            w.RegisterDependency(
                new OutKeyTappedHandler(w));
            w.RegisterDependency(
                new TimerHandler(w));
            w.RegisterDependency(
                new StartHandler(w));
            w.RegisterDependency(
                new SetupHandler(w));
            w.RegisterDependency(
                new LatchHolder
                {
                    Latch = new ManualResetEvent(true)
                },
                DependencyNames.Latch);
        }

        protected readonly HomeUi ui;
        protected readonly ShellUi shell;
        protected readonly Gen<MethodRunner, TimestampReaderWriter> newReaderWriter;
        protected readonly MethodWeb web;
    }
}
