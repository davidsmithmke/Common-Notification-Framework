using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
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
