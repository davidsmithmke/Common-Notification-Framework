using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using WashableSoftware.Crosscutting.Notifications.Core.Notifications;
using System.Threading.Tasks;

namespace WashableSoftware.Crosscutting.Notifications.Core.Manager
{
    public interface INotificationManager
    {
        INotificationChannel GetChannel(string channelName, bool suppressErrors = false);
        Task SendNotificationAsync(INotificationChannel channel, INotification notification);
        Task SendNotificationAsync(string channelName, INotification notification);
        Task SendNotificationAsync(INotificationChannel channel, object data);
        Task SendNotificationAsync(string channelName, object data);
    }
}
