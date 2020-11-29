namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework;
    using xofz.TimeKeeper98.Framework.Home;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class HomePresenter
        : Presenter
    {
        public HomePresenter(
            HomeUi ui, 
            ShellUi shell,
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.web = web;
        }

        public void Setup()
        {
            const byte one = 1;
            if (Interlocked.Exchange(
                    ref this.setupIf1,
                    one) == one)
            {
                return;
            }

            var w = this.web;
            w?.Run<EventSubscriber>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.InKeyTapped),
                    this.ui_InKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.OutKeyTapped),
                    this.ui_OutKeyTapped);
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.EditKeyTapped),
                    this.ui_EditKeyTapped);
                w.Run<xofz.Framework.Timer>(t =>
                    {
                        subscriber.Subscribe(
                            t,
                            nameof(t.Elapsed),
                            this.timer_Elapsed);
                    },
                    DependencyNames.Timer);
            });

            w?.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            w?.Run<Navigator>(nav =>
            {
                Do refreshHome = () =>
                {
                    w.Run<TimerHandler>(handler =>
                    {
                        handler.Handle(this.ui);
                    });
                };

                w.RegisterDependency(
                    refreshHome,
                    MethodNames.RefreshHome);

                nav.RegisterPresenter(this);
            });
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            w?.Run<StartHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_InKeyTapped()
        {
            var w = this.web;
            w?.Run<InKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_OutKeyTapped()
        {
            var w = this.web;
            w?.Run<OutKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_EditKeyTapped()
        {
            var w = this.web;
            w?.Run<Navigator>(nav =>
            {
                Do presentEditor = nav.Present<TimestampEditPresenter>;
                w.Run<EditKeyTappedHandler>(handler =>
                {
                    handler.Handle(
                        this.ui,
                        presentEditor);
                });
            });
        }

        private void timer_Elapsed()
        {
            var w = this.web;
            w?.Run<TimerHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private long setupIf1;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
