using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public interface IChannelManagerConfiguration
    {
        void AddConfiguration(INotificationChannelConfiguration configuration);
        IEnumerable<INotificationChannelConfiguration> ChannelConfigurations { get; }
    }
}
