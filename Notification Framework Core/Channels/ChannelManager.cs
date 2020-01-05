using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using System;
using System.Collections.Generic;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public class ChannelManager
        : IChannelManager
    {
        public ChannelManager(ITemplateManager templateManager, ILogger logger)
        {
            Channels = new Dictionary<string, INotificationChannel>();

            TemplateManager = templateManager;
            Logger = logger;
        }

        private Dictionary<string, INotificationChannel> Channels;

        public INotificationChannel CreateChannel<T>(INotificationChannelConfiguration configuration) where T : INotificationChannel, new()
        {
            INotificationChannel channel = new T();
            channel.InjectDependencies(logger: Logger);

            try
            {
                channel.Configure(templateManager: TemplateManager, configuration: configuration);
            }
            catch (ArgumentNullException)
            {
                Logger.Error("Failed to configure channel.");
                throw new InvalidChannelException("Failed to configure channel.");
            }
            catch (ArgumentException)
            {
                Logger.Error("Failed to configure channel.");
                throw new InvalidChannelException("Failed to configure channel.");
            }

            return channel;
        }

        public INotificationChannel GetChannel(string name)
        {
            return Channels[name];
        }

        protected ILogger Logger { get; }

        public IChannelManager RegisterChannel(INotificationChannel channel)
        {
            #region Validate Requirements
            // Channel cannot be null
            if (channel == null)
            {
                Logger.Error("Invalid channel.  Cannot register a null channel.");
                throw new InvalidChannelException("Cannot register a null channel.");
            }

            // Channel must have a name
            if (String.IsNullOrWhiteSpace(channel.Name))
            {
                Logger.Error("Invalid channel.  Cannot register a channel with a null or empty name.");
                throw new InvalidChannelException(message: "Channel name cannot be blank or null.");
            }
            #endregion

            Channels.Add(key: channel.Name, value: channel);

            return this;
        }

        public INotificationChannel RegisterChannel<T>(INotificationChannelConfiguration configuration) where T : INotificationChannel, new()
        {
            var channel = CreateChannel<T>(configuration: configuration);
            RegisterChannel(channel: channel);

            return channel;
        }

        public ITemplateManager TemplateManager { get; }
    }
}
