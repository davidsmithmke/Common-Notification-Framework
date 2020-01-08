using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using WashableSoftware.Crosscutting.Notifications.Core.Templates;
using System;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public abstract class ChannelBase
        : INotificationChannel
    {
        public INotificationChannel Configure(ITemplateManager templateManager, INotificationChannelConfiguration configuration)
        {
            #region Validate Requirements
            // Template provider is not null
            if (templateManager == null)
            {
                var error = "Cannot configure a channel using a null template manager.";
                Logger.Error(error);
                throw new ArgumentNullException(message: error, paramName: nameof(templateManager));
            }

            // Channel configuration is not null
            if (configuration == null)
            {
                var error = "Cannot configure a channel using a null channel configuration.";
                Logger.Error(error);
                throw new ArgumentNullException(message: error, paramName: nameof(configuration));
            }

            // Channel name is not null or empty
            if (String.IsNullOrWhiteSpace(configuration.Name))
            {
                var error = "Cannot configure a channel with a null or empty name.";
                Logger.Error(error);
                throw new ArgumentException(message: error, paramName: nameof(configuration));
            }

            // Provider is not null
            if (configuration.Provider == null)
            {
                var error = "Cannot configure a channel with a null provider.";
                Logger.Error(error);
                throw new ArgumentException(message: error);
            }

            // Template is specified
            if (String.IsNullOrWhiteSpace(configuration.Template))
            {
                var error = "Cannot configure a channel without a template.";
                Logger.Error(error);
                throw new ArgumentException(message: error);
            }

            // Template is registered with template provider
            if (templateManager.IsTemplateRegistered(name: configuration.Template) == false)
            {
                var error = String.Format("Template '{0}' is not registered with the template provider.", configuration.Template);
                Logger.Error(error);
                throw new ArgumentException(message: error);
            }
            #endregion

            TemplateManager = templateManager;
            Name = configuration.Name;
            Provider = configuration.Provider;
            Template = configuration.Template;

            Logger.Trace("Notification channel base configuration complete.");

            return this;
        }

        public abstract INotification GenerateNotification(object data);

        public void InjectDependencies(ILogger logger)
        {
            Logger = logger;

            Logger.Trace("Logger injected.");
        }

        protected ILogger Logger { get; private set; }

        public string Name { get; private set; }

        public INotificationProvider Provider { get; private set; }

        async public Task SendAsync(INotification notification)
        {
            ValidateConfiguration();

            Logger.Debug("Sending notification via provider.");

            await Provider.SendAsync(notification: notification);
        }

        async public Task SendAsync(object data)
        {
            INotification notification = GenerateNotification(data: data);
            await Provider.SendAsync(notification: notification);
        }

        protected string Template { get; private set; }

        protected ITemplateManager TemplateManager { get; private set; }

        protected void ValidateConfiguration()
        {
            // Template provider is not null
            if (TemplateManager == null)
            {
                var error = "Invalid channel configuration.  Template manager not configured.";
                Logger.Error(error);
                throw new InvalidChannelException(message: error);
            }

            // Channel name is not null or empty
            if (String.IsNullOrWhiteSpace(Name))
            {
                var error = "Invalid channel configuration.  Channel name cannot be null or empty.";
                Logger.Error(error);
                throw new InvalidChannelException(message: error);
            }

            // Provider is not null
            if (Provider == null)
            {
                var error = "Invalid channel configuration.  Provider cannot be null.";
                Logger.Error(error);
                throw new ArgumentException(message: error);
            }

            // Template is specified
            if (String.IsNullOrWhiteSpace(Template))
            {
                var error = "Invalid channel configuration.  Template name cannot be null or empty.";
                Logger.Error(error);
                throw new InvalidChannelException(message: error);
            }

            // Template is registered with template provider
            if (TemplateManager.IsTemplateRegistered(name: Template) == false)
            {
                var error = String.Format("Invalid channel configuration.  Template '{0}' is not registered with the template provider.", Template);
                Logger.Error(error);
                throw new InvalidChannelException(message: error);
            }
        }
    }
}
