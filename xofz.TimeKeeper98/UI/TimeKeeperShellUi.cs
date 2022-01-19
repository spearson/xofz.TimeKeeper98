namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;
    using xofz.UI.Main;

    public interface TimeKeeperShellUi 
        : ShellUi, MainUi
    {
        ShellUi NavUi { get; }
    }
}
