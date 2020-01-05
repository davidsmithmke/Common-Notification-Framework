using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public interface IChannelManager
    {
        INotificationChannel CreateChannel<T>(INotificationChannelConfiguration configuration) where T : INotificationChannel, new();
        INotificationChannel GetChannel(string name);
        IChannelManager RegisterChannel(INotificationChannel channel);
        INotificationChannel RegisterChannel<T>(INotificationChannelConfiguration configuration) where T : INotificationChannel, new();
    }
}
