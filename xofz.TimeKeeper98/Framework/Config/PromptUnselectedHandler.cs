﻿namespace xofz.TimeKeeper98.Framework.Config
{
    using xofz.Framework;
    using xofz.TimeKeeper98.UI;

    public class PromptUnselectedHandler
    {
        public PromptUnselectedHandler(
            MethodWeb web)
        {
            this.web = web;
        }

        public virtual void Handle(
            ConfigUi ui)
        {
            var w = this.web;
            w.Run<GlobalSettingsHolder>(settings =>
            {
                settings.Prompt = false;
            });
            w.Run<ConfigSaver>(saver => { saver.Save(); });
        }

        protected readonly MethodWeb web;
    }
}
