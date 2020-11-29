namespace xofz.TimeKeeper98.Framework.Home
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class EditKeyTappedHandler
    {
        public EditKeyTappedHandler(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        public virtual void Handle(
            HomeUi ui,
            Do presentEditor)
        {
            var r = this.runner;

            presentEditor?.Invoke();
        }

        protected readonly MethodRunner runner;
    }
}
