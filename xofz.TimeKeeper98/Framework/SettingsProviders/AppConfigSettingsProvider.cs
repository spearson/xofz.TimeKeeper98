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

            var settings = new GlobalSettingsHolder();
            var appConfig = Settings.Default;

            try
            {
                settings.TitleText = appConfig.TitleText;
            }
            catch
            {
                // swallow
            }

            try
            {
                settings.Prompt = appConfig.Prompt;
            }
            catch
            {
                // swallow
            }

            try
            {
                settings.ShowSeconds = appConfig.ShowSeconds;
            }
            catch
            {
                // swallow
            }

            try
            {
                var interval = appConfig.TimerIntervalSeconds;
                if (interval < 1)
                {
                    interval = 1;
                }

                settings.TimerIntervalSeconds = interval;
            }
            catch
            {
                // swallow
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
