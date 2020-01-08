using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using WashableSoftware.Crosscutting.Notifications.Core.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashableSoftware.Crosscutting.Notifications.Email
{
    public class EmailChannel
        : ChannelBase, INotificationChannel
    {
        public INotificationChannel Configure(ITemplateManager templateManager, IEmailChannelConfiguration configuration)
        {
            #region Validate Requirements
            // Channel name is not null or empty
            if (configuration.To == null || configuration.To.Count() == 0)
            {
                var error = "Cannot configure an email channel with no recipients.";
                Logger.Error(error);
                throw new ArgumentException(message: error, paramName: nameof(configuration));
            }
            #endregion

            base.Configure(templateManager: templateManager, configuration: configuration);

            From = configuration.From;
            Subject = configuration.Subject;
            To = configuration.To;

            Logger.Trace("Email notification channel extended configuration complete.");

            return this;
        }

        new public INotificationChannel Configure(ITemplateManager templateManager, INotificationChannelConfiguration configuration)
        {
            if (configuration is IEmailChannelConfiguration)
                return Configure(templateManager: templateManager, configuration: configuration as IEmailChannelConfiguration);

            base.Configure(templateManager: templateManager, configuration: configuration);

            return this;
        }

        protected string From { get; set;}

        override public INotification GenerateNotification(object data)
        {
            ValidateConfiguration();

            Logger.Trace("Generating email notification.");
            var message = TemplateManager.ProcessTemplate(name: Template, data: data);

            var notification = new EmailNotification() { Message = message, Subject = Subject, To = To, From = From };
            Logger.Debug("Email notification generated.");

            return notification;
        }

        protected string Subject { get; set; }

        protected IEnumerable<string> To { get; set; }
    }
}
