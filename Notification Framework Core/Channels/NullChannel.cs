using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public class NullChannel
        : INotificationChannel
    {
        public NullChannel()
        { }

        public NullChannel(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; set; }

        public string Name => "Null Channel";

        public INotificationProvider Provider => null;

        public INotificationChannel Configure(ITemplateManager templateManager, INotificationChannelConfiguration configuration)
        {
            Logger?.Debug("Null channel configuration method invoked.");

            return this;
        }

        public INotification GenerateNotification(object data)
        {
            Logger?.Debug("Null channel notification generation method invoked.");

            return null;
        }

        public void InjectDependencies(ILogger logger)
        {
            Logger = logger;
        }

        public async Task SendAsync(INotification notification)
        {
            Logger?.Warn("Attempted to send notification via null channel.");

            return;
        }

        public async Task SendAsync(object data)
        {
            Logger?.Warn("Attempted to send notification via null channel.");

            return;
        }
    }
}
