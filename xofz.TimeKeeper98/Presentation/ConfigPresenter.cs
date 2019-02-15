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
            MethodWeb web) 
            : base(ui, shell)
        {
            this.ui = ui;
            this.web = web;
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

            var w = this.web;
            w.Run<SetupHandler>(handler =>
            {
                handler.Handle(this.ui);
            });

            w.Run<EventSubscriber>(sub =>
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
                    nameof(this.ui.PublishKeyTapped),
                    this.ui_PublishKeyTapped);
            });

            w.Run<Navigator>(nav => nav.RegisterPresenter(this));
        }

        public override void Start()
        {
            base.Start();

            var w = this.web;
            w.Run<StartHandler>(handler => handler.Handle());
        }

        private void ui_PromptSelected()
        {
            var w = this.web;
            w.Run<PromptSelectedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_KeyboardKeyTapped()
        {
            var w = this.web;
            w.Run<KeyboardKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_PromptUnselected()
        {
            var w = this.web;
            w.Run<PromptUnselectedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_SaveTitleTextKeyTapped()
        {
            var w = this.web;
            w.Run<SaveTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_ResetTitleTextKeyTapped()
        {
            var w = this.web;
            w.Run<ResetTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_DefaultTitleTextKeyTapped()
        {
            var w = this.web;
            w.Run<DefaultTitleTextKeyTappedHandler>(handler =>
            {
                handler.Handle(this.ui);
            });
        }

        private void ui_ShowSecondsSelected()
        {
            var w = this.web;
            w.Run<ShowSecondsSelectedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_ShowSecondsUnselected()
        {
            var w = this.web;
            w.Run<ShowSecondsUnselectedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private void ui_PublishKeyTapped()
        {
            var w = this.web;
            w.Run<PublishKeyTappedHandler>(handler =>
            {
                handler.Handle();
            });
        }

        private long setupIf1;
        private readonly ConfigUi ui;
        private readonly MethodWeb web;
    }
}
