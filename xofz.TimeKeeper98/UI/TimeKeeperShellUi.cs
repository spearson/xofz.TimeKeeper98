namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface TimeKeeperShellUi 
        : ShellUi, MainUi
    {
        ShellUi NavUi { get; }
    }
}
