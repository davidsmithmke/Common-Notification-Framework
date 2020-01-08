using System.Collections.Generic;
using Washable.Logging.Common;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public class ChannelManagerConfiguration
        : IChannelManagerConfiguration
    {
        public ChannelManagerConfiguration(ILogger logger)
        {
            Logger = logger;

            channelConfigurations = new List<INotificationChannelConfiguration>();
        }

        public IEnumerable<INotificationChannelConfiguration> ChannelConfigurations => channelConfigurations;

        protected ILogger Logger { get; }

        private List<INotificationChannelConfiguration> channelConfigurations;

        public void AddConfiguration(INotificationChannelConfiguration configuration)
        {
            channelConfigurations.Add(item: configuration);
        }
    }
}
