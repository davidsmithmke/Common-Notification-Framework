using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using System.Threading.Tasks;

namespace WashableSoftware.Crosscutting.Notifications.Core.Providers
{
    public interface INotificationProvider
    {
        INotificationProvider Configure(INotificationProviderConfiguration configuration);
        string Name { get; }
        Task SendAsync(INotification notification);
    }
}
