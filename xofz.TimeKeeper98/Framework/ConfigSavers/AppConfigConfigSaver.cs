namespace xofz.TimeKeeper98.Framework.ConfigSavers
{
    using System.IO;
    using System.Text;
    using xofz.Framework;

    public sealed class AppConfigConfigSaver : ConfigSaver
    {
        public AppConfigConfigSaver(
            MethodRunner runner)
        {
            this.runner = runner;
        }

        void ConfigSaver.Save()
        {
            var r = this.runner;
            r.Run<GlobalSettingsHolder>(settings =>
            {
                var sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                          "<configuration>\r\n" +
                          "    <configSections>\r\n" +
                          "        <sectionGroup name=\"applicationSettings\" type=\"System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" >\r\n" +
                          "            <section name=\"xofz.TimeKeeper98.Properties.Settings\" type=\"System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" requirePermission=\"false\" />\r\n" +
                          "        </sectionGroup>\r\n" +
                          "    </configSections>\r\n" +
                          "    <startup>\r\n" +
                          "        <supportedRuntime version=\"v2.0.50727\" />\r\n" +
                          "    </startup>\r\n" +
                          "    <applicationSettings>\r\n" +
                          "        <xofz.TimeKeeper98.Properties.Settings>\r\n"+ 
                          "            <setting name=\"TitleText\" serializeAs=\"String\">\r\n");
                sb.Append("                <value>");
                sb.Append(settings.TitleText);
                sb.Append("</value>\r\n");
                sb.Append("            </setting>\r\n");
                sb.Append("            <setting name=\"Prompt\" serializeAs=\"String\">\r\n");
                sb.Append("                <value>");
                sb.Append(settings.Prompt);
                sb.Append("</value>\r\n");
                sb.Append("            </setting>\r\n");
                sb.Append("            <setting name=\"ShowSeconds\" serializeAs=\"String\">\r\n");
                sb.Append("                <value>");
                sb.Append(settings.ShowSeconds);
                sb.Append("</value>\r\n");
                sb.Append("            </setting>\r\n");
                sb.Append("            <setting name=\"TimerIntervalSeconds\" serializeAs=\"String\">\r\n");
                sb.Append("                <value>");
                sb.Append(settings.TimerIntervalSeconds);
                sb.Append("</value>\r\n");
                sb.Append("            </setting>\r\n");
                sb.Append("        </xofz.TimeKeeper98.Properties.Settings>\r\n" +
                    "    </applicationSettings>\r\n" +
                    "</configuration>\r\n");
                try
                {
                    File.WriteAllText(
                        nameof(xofz)
                        + '.'
                        + nameof(TimeKeeper98) +
                        @".exe.config",
                        sb.ToString());
                }
                catch
                {
                    // try again next time...
                }
            });
        }

        private readonly MethodRunner runner;
    }
}
