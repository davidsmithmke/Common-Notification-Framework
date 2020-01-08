using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using WashableSoftware.Crosscutting.Notifications.Core.Templates;
using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Console
{
    public class ConsoleChannel
        : ChannelBase, INotificationChannel
    {
        public INotificationChannel Configure(ITemplateManager templateManager, IConsoleChannelConfiguration configuration)
        {
            base.Configure(templateManager: templateManager, configuration: configuration);

            UseTimestamp = configuration.UseTimestamp;

            Logger.Trace("Console notification channel extended configuration complete.");

            return this;
        }

        new public INotificationChannel Configure(ITemplateManager templateManager, INotificationChannelConfiguration configuration)
        {
            if (configuration is IConsoleChannelConfiguration)
                Configure(templateManager: templateManager, configuration: configuration as IConsoleChannelConfiguration);

            base.Configure(templateManager: templateManager, configuration: configuration);

            return this;
        }

        override public INotification GenerateNotification(object data)
        {
            ValidateConfiguration();

            Logger.Trace("Generating console notification.");
            var message = TemplateManager.ProcessTemplate(name: Template, data: data);

            if (UseTimestamp == true)
            {
                Logger.Trace("Prepending timestamp to console notification.");
                message = string.Format("{0:HH:mm:ss}: {1}", DateTime.Now, message);
            }

            var notification = new Notification() { Message = message, Subject = String.Empty };
            Logger.Debug("Console notification generated.");

            return notification;
        }

        protected bool UseTimestamp { get; private set; }
    }
}
