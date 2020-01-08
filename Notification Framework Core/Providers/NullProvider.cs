using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public class NullProvider
        : INotificationProvider
    {
        public NullProvider()
        { }

        public NullProvider(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; set; }

        public string Name => "Null Provider";

        public INotificationProvider Configure(INotificationProviderConfiguration configuration)
        {
            Logger?.Debug("Null provider configuration method invoked.");

            return this;
        }

        public async Task SendAsync(INotification notification)
        {
            Logger?.Warn("Attempted to send notification via null provider.");

            return;
        }
    }
}
