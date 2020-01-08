using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using WashableSoftware.Crosscutting.Notifications.Core.Templates;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public interface INotificationChannel
    {
        INotificationChannel Configure(ITemplateManager templateManager, INotificationChannelConfiguration configuration);
        INotification GenerateNotification(object data);
        void InjectDependencies(ILogger logger);
        string Name { get; }
        INotificationProvider Provider { get; }
        Task SendAsync(INotification notification);
        Task SendAsync(object data);
    }
}
