namespace xofz.TimeKeeper98.UI
{
    using xofz.UI;

    public interface LicenseUi 
        : PopupUi
    {
        event Do AcceptKeyTapped;

        event Do RejectKeyTapped;
    }
}
