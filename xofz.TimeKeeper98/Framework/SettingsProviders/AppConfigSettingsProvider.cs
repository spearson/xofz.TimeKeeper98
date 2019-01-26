namespace xofz.TimeKeeper98.Framework.SettingsProviders
{
    using xofz.TimeKeeper98.Properties;

    public sealed class AppConfigSettingsProvider
        : SettingsProvider
    {
        GlobalSettingsHolder SettingsProvider.Provide()
        {
            return new GlobalSettingsHolder
            {
                TimestampFormat = @"MM/dd hh:mm:ss tt",
                EditTimestampFormat = @"MM/dd/yyyy hh:mm:ss tt",
                TitleText = Settings.Default.TitleText,
                Prompt = Settings.Default.Prompt
            };
        }
    }
}
