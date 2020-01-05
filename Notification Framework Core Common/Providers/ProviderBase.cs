using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using System;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    abstract public class ProviderBase
        : INotificationProvider
    {
        public ProviderBase(ILogger logger)
        {
            Logger = logger;
        }

        public INotificationProvider Configure(INotificationProviderConfiguration configuration)
        {
            #region Validate Requirements
            // Provider name is not null
            if (string.IsNullOrWhiteSpace(configuration.Name))
            {
                var error = "Cannot configure a provider using a null or empty name.";
                Logger.Error(error);
                throw new ArgumentNullException(message: error, paramName: nameof(configuration));
            }
            #endregion

            Name = configuration.Name;

            Logger.Debug("Notification provider base configuration complete.");

            return this;
        }

        public ILogger Logger { get; }

        public string Name { get; private set; }

        abstract public Task SendAsync(INotification notification);
    }
}
