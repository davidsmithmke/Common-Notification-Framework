using MountMaryUniversity.Crosscutting.Notifications.Core.Channels;
using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Manager
{
    public class NotificationManager
        : INotificationManager
    {
        public NotificationManager(ITemplateManager templateManager, IProviderManager providerManager, IChannelManager channelManager, ILogger logger)
        {
            Logger = logger;

            TemplateManager = templateManager;
            ProviderManager = providerManager;
            ChannelManager = channelManager;
        }

        protected ITemplateManager TemplateManager { get; }
        protected IProviderManager ProviderManager { get; }
        protected IChannelManager ChannelManager { get; }
        protected ILogger Logger { get; }

        public INotificationChannel GetChannel(string channelName, bool suppressErrors = false)
        {
            var channel = ChannelManager.GetChannel(name: channelName, suppressErrors: suppressErrors);

            return channel;
        }

        public Task SendNotificationAsync(INotificationChannel channel, INotification notification)
        {
            var result = channel.SendAsync(notification: notification);

            return result;
        }

        public Task SendNotificationAsync(string channelName, INotification notification)
        {
            var channel = GetChannel(channelName: channelName);
            var result = channel.SendAsync(notification: notification);

            return result;
        }

        public Task SendNotificationAsync(INotificationChannel channel, object data)
        {
            var result = channel.SendAsync(data: data);

            return result;
        }

        public Task SendNotificationAsync(string channelName, object data)
        {
            var channel = GetChannel(channelName: channelName);
            var result = channel.SendAsync(data: data);

            return result;
        }
    }
}
