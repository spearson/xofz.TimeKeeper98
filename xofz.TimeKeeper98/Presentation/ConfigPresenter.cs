namespace xofz.TimeKeeper98.Presentation
{
    using System.Threading;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.TimeKeeper98.Framework.Config;
    using xofz.TimeKeeper98.UI;
    using xofz.UI;

    public sealed class ConfigPresenter
        : Presenter
    {
        public ConfigPresenter(
            ConfigUi ui, 
            ShellUi shell,
            MethodRunner runner) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.runner = runner;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(
                    ref this.setupIf1, 
                    1, 
                    0) == 1)
            {
                return;
            }

            var r = this.runner;
            r.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            r.Run<EventSubscriber>(sub =>
            {
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.PromptSelected),
                    this.ui_PromptSelected);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.PromptUnselected),
                    this.ui_PromptUnselected);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.KeyboardKeyTapped),
                    this.ui_KeyboardKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveTitleTextKeyTapped),
                    this.ui_SaveTitleTextKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.ResetTitleTextKeyTapped),
                    this.ui_ResetTitleTextKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.DefaultTitleTextKeyTapped),
                    this.ui_DefaultTitleTextKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.ShowSecondsSelected),
                    this.ui_ShowSecondsSelected);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.ShowSecondsUnselected),
                    this.ui_ShowSecondsUnselected);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.SaveIntervalKeyTapped),
                    this.ui_SaveIntervalKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.ResetIntervalKeyTapped),
                    this.ui_ResetIntervalKeyTapped);
                sub.Subscribe(
                    this.ui,
                    nameof(this.ui.PublishKeyTapped),
                    this.ui_PublishKeyTapped);
                r.Run<Navigator>(nav =>
                {
                    var homeUi = nav.GetUi<HomePresenter, HomeUi>();
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.InKeyTapped),
                        this.homeUi_InKeyTapped);
                    sub.Subscribe(
                        homeUi,
                        nameof(homeUi.OutKeyTapped),
                        this.homeUi_OutKeyTapped);
                });
            });

            r.Run<Navigator>(nav =>
                nav.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var r = this.runner;
            r.Run<StartHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            Interlocked.CompareExchange(
                ref this.startedIf1, 
                1, 
                0);
        }

        public override void Stop()
        {
            Interlocked.CompareExchange(
                ref this.startedIf1, 
                0, 
                1);
        }

        private void ui_PromptSelected()
        {
            var r = this.runner;
            r.Run<PromptSelectedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_KeyboardKeyTapped()
        {
            var r = this.runner;
            r.Run<KeyboardKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_PromptUnselected()
        {
            var r = this.runner;
            r.Run<PromptUnselectedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_SaveTitleTextKeyTapped()
        {
            var r = this.runner;
            r.Run<SaveTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_ResetTitleTextKeyTapped()
        {
            var r = this.runner;
            r.Run<ResetTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_DefaultTitleTextKeyTapped()
        {
            var r = this.runner;
            r.Run<DefaultTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_ShowSecondsSelected()
        {
            var r = this.runner;
            r.Run<ShowSecondsSelectedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_ShowSecondsUnselected()
        {
            var r = this.runner;
            r.Run<ShowSecondsUnselectedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_SaveIntervalKeyTapped()
        {
            var r = this.runner;
            r.Run<SaveIntervalKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private void ui_ResetIntervalKeyTapped()
        {
            var r = this.runner;
            r.Run<ResetIntervalKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private void ui_PublishKeyTapped()
        {
            var r = this.runner;
            r.Run<PublishKeyTappedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void homeUi_InKeyTapped()
        {
            if (Interlocked.Read(
                    ref this.startedIf1) != 1)
            {
                return;
            }

            var r = this.runner;
            r.Run<HomeUiInKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private void homeUi_OutKeyTapped()
        {
            if (Interlocked.Read(
                    ref this.startedIf1) != 1)
            {
                return;
            }

            var r = this.runner;
            r.Run<HomeUiOutKeyTappedHandler>(handler =>
            {
                handler.Handle(
                    this.ui);
            });
        }

        private long setupIf1, startedIf1;
        private readonly ConfigUi ui;
        private readonly MethodRunner runner;
    }
}
