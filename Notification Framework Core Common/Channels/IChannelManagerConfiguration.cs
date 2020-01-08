using System.Collections.Generic;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public interface IChannelManagerConfiguration
    {
        void AddConfiguration(INotificationChannelConfiguration configuration);
        IEnumerable<INotificationChannelConfiguration> ChannelConfigurations { get; }
    }
}
