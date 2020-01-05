using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using System.Threading.Tasks;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public interface INotificationProvider
    {
        INotificationProvider Configure(INotificationProviderConfiguration configuration);
        string Name { get; }
        Task SendAsync(INotification notification);
    }
}
