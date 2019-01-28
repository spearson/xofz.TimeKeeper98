namespace xofz.TimeKeeper98.Framework.SettingsProviders
{
    using System.IO;
    using xofz.TimeKeeper98.Properties;

    public class AppConfigSettingsProvider
        : SettingsProvider
    {
        GlobalSettingsHolder SettingsProvider.Provide()
        {
            this.checkAndRecreate();
            return new GlobalSettingsHolder
            {
                TimestampFormat = @"MM/dd hh:mm:ss tt",
                EditTimestampFormat = @"MM/dd/yyyy hh:mm:ss tt",
                TitleText = Settings.Default.TitleText,
                Prompt = Settings.Default.Prompt
            };
        }

        protected virtual void checkAndRecreate()
        {
            var path = nameof(xofz) 
                       + '.'
                       + nameof(TimeKeeper98) 
                       + @".exe.config";
            try
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(
                        path,
                        Constants.DefaultSettings);
                }
            }
            catch
            {
                // try again next time...
            }
        }
    }
}
