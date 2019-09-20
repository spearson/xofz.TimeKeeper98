namespace xofz.TimeKeeper98.Framework.SettingsProviders
{
    using System.IO;
    using xofz.Framework;
    using xofz.TimeKeeper98.Properties;

    public class AppConfigSettingsProvider
        : SettingsProvider
    {
        public AppConfigSettingsProvider(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        GlobalSettingsHolder SettingsProvider.Provide()
        {
            this.checkAndRecreate();

            var settings = new GlobalSettingsHolder
            {
                TimestampFormat = @"MM/dd hh:mm:ss tt",
                EditTimestampFormat = @"yyyy/MM/dd hh:mm:ss tt"
            };
            try
            {
                settings.TitleText = Settings.Default.TitleText;
            }
            catch
            {
                settings.TitleText = @"x(z) TimeKeeper98";
            }

            try
            {
                settings.Prompt = Settings.Default.Prompt;
            }
            catch
            {
                settings.Prompt = true;
            }

            try
            {
                settings.ShowSeconds = Settings.Default.ShowSeconds;
            }
            catch
            {
                settings.ShowSeconds = false;
            }

            return settings;
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

        protected readonly MethodRunner runner;
    }
}
