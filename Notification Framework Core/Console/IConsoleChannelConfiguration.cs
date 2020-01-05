using MountMaryUniversity.Crosscutting.Notifications.Core.Channels;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Console
{
    public interface IConsoleChannelConfiguration
        : INotificationChannelConfiguration
    {
        bool UseTimestamp { get; set; }
    }
}