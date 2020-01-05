using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public class NotificationChannelConfiguration
        : INotificationChannelConfiguration
    {
        public string Name { get; set; }
        public INotificationProvider Provider { get; set; }
        public string Template { get; set; }
    }
}
