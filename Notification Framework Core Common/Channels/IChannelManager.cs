namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public interface IChannelManager
    {
        INotificationChannel CreateChannel(INotificationChannelConfiguration configuration);
        INotificationChannel GetChannel(string name, bool suppressErrors = false);
        INotificationChannel RegisterChannel(INotificationChannel channel);
        INotificationChannel RegisterChannel(INotificationChannelConfiguration configuration);
    }
}
