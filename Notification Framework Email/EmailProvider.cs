using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace WashableSoftware.Crosscutting.Notifications.Email
{
    public class EmailProvider
        : ProviderBase, INotificationProvider
    {
        public EmailProvider()
            : base()
        { }

        public EmailProvider(ILogger logger)
            : base(logger: logger) { }

        public INotificationProvider Configure(IEmailProviderConfiguration configuration)
        {
            base.Configure(configuration: configuration);

            DefaultEmail = configuration.DefaultFrom;

            SmtpClient = new SmtpClient()
            {
                Host = configuration.SmtpServerAddress,
                Port = configuration.SmtpServerPort,
                EnableSsl = configuration.SmtpEnableSsl,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            Logger.Trace("Email notification provider extended configuration complete.");

            return this;
        }

        new public INotificationProvider Configure(INotificationProviderConfiguration configuration)
        {
            if (configuration is IEmailProviderConfiguration)
                return Configure(configuration: configuration as IEmailProviderConfiguration);

            base.Configure(configuration: configuration);

            return this;
        }

        protected string DefaultEmail { get; set; }

        override async public Task SendAsync(INotification notification)
        {
            var emailNotification = notification as EmailNotification;
            if (emailNotification == null)
            {
                var error = "Invalid notification type.";
                Logger.Error(message: error);
                throw new ArgumentException(message: error, paramName: nameof(notification));
            }

            var message = new MailMessage();
            foreach (var recipient in emailNotification.To)
            {
                message.To.Add(new MailAddress(recipient));
            }
            message.From = new MailAddress(!String.IsNullOrWhiteSpace(emailNotification.From) ? emailNotification.From : DefaultEmail);
            message.Subject = notification.Subject;
            message.Body = notification.Message;
            message.IsBodyHtml = true;

            try
            {
                await SmtpClient.SendMailAsync(message: message);

                Logger.Debug("Email notification sent.");
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }

        protected SmtpClient SmtpClient { get; set; }
    }
}
