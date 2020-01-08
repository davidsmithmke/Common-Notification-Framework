using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;

namespace WashableSoftware.Crosscutting.Notifications.Core.Console
{
    public interface IConsoleChannelConfiguration
        : INotificationChannelConfiguration
    {
        bool UseTimestamp { get; set; }
    }
}