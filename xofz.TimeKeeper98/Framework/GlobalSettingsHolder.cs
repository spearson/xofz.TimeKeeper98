namespace xofz.TimeKeeper98.Framework
{
    public class GlobalSettingsHolder
    {
        public virtual string TimestampFormat { get; set; }
            = @"MM/dd hh:mm:ss tt";

        public virtual string EditTimestampFormat { get; set; }
            = @"yyyy/MM/dd hh:mm:ss tt";

        public virtual string TitleText { get; set; }
            = @"x(z) TimeKeeper98";

        public virtual bool Prompt { get; set; }
            = true;

        public virtual bool ShowSeconds { get; set; }
            = false;

        public virtual int TimerIntervalSeconds { get; set; }
            = 1;
    }
}
