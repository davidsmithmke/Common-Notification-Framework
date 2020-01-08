using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using System;
using System.Collections.Generic;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public class ChannelManager
        : IChannelManager
    {
        public ChannelManager(IChannelManagerConfiguration configuration, ITemplateManager templateManager, ILoggerProvider loggerProvider)
        {
            Channels = new Dictionary<string, INotificationChannel>();

            TemplateManager = templateManager;
            LoggerProvider = loggerProvider;
            Logger = loggerProvider.GetLogger(targetType: typeof(ChannelManager));

            Configure(configuration: configuration);
        }

        private Dictionary<string, INotificationChannel> Channels;

        protected ILoggerProvider LoggerProvider { get; }
        protected ILogger Logger { get; }
        protected ITemplateManager TemplateManager { get; }

        private void Configure(IChannelManagerConfiguration configuration)
        {
            Logger?.Trace("Beginning channel manager configuration.");

            foreach (var channelConfiguration in configuration.ChannelConfigurations)
            {
                Logger?.Debug($"Registering channel '{channelConfiguration.Name}' of type {channelConfiguration.ChannelType.Name}.");
                RegisterChannel(configuration: channelConfiguration);
            }

            Logger?.Trace("Channel manager configuration complete.");
        }

        public INotificationChannel CreateChannel(INotificationChannelConfiguration configuration)
        {
            Logger?.Trace($"Creating new channel '{configuration.Name}' of type {configuration.ChannelType.Name}.");

            INotificationChannel channel = (INotificationChannel)Activator.CreateInstance(configuration.ChannelType);

            if (channel == null)
            {
                Logger?.Warn($"Failed to create channel '{configuration.Name}' of type {configuration.ChannelType.Name}.");
                return null;
            }

            try
            {
                channel.InjectDependencies(logger: LoggerProvider.GetLogger(targetType: configuration.ChannelType));
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

            Logger?.Debug($"Created channel '{configuration.Name}' of type {configuration.ChannelType.Name}.");

            return channel;
        }

        public INotificationChannel GetChannel(string name, bool suppressErrors = false)
        {
            INotificationChannel channel;
            var channelFound = Channels.TryGetValue(key: name, value: out channel);

            if (channelFound == false || channel == null)
            {
                if (suppressErrors == true)
                {
                    Logger?.Warn($"Failed to locate channel '{name}'.  Substituting null channel.");
                    channel = new NullChannel();
                    channel.InjectDependencies(logger:  LoggerProvider.GetLogger(targetType: typeof(NullChannel)));
                    return channel;
                }
                else
                {
                    Logger?.Fatal($"Failed to locate channel '{name}'.");
                    throw new Exception();
                }
            }

            return channel;
        }

        public INotificationChannel RegisterChannel(INotificationChannel channel)
        {
            #region Validate Requirements
            // Channel cannot be null
            if (channel == null)
            {
                Logger?.Error("Invalid channel.  Cannot register a null channel.");
                throw new InvalidChannelException("Cannot register a null channel.");
            }

            // Channel must have a name
            if (String.IsNullOrWhiteSpace(channel.Name))
            {
                Logger?.Error("Invalid channel.  Cannot register a channel with a null or empty name.");
                throw new InvalidChannelException(message: "Channel name cannot be blank or null.");
            }
            #endregion

            Channels.Add(key: channel.Name, value: channel);

            Logger?.Debug($"Registered channel '{channel.Name}'.");

            return channel;
        }

        public INotificationChannel RegisterChannel(INotificationChannelConfiguration configuration)
        {
            var channel = CreateChannel(configuration: configuration);
            RegisterChannel(channel: channel);

            return channel;
        }

    }
}
