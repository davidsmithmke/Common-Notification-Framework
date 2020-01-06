using System;
using System.Collections.Generic;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public class ProviderManager
        : IProviderManager
    {
        public ProviderManager(IProviderManagerConfiguration configuration, ILoggerProvider loggerProvider)
        {
            LoggerProvider = loggerProvider;
            Logger = loggerProvider.GetLogger(targetType: typeof(ProviderManager));

            Providers = new Dictionary<string, INotificationProvider>();

            Configure(configuration: configuration);
        }

        protected ILoggerProvider LoggerProvider { get; }
        protected ILogger Logger { get; }
        protected Dictionary<string, INotificationProvider> Providers { get; }

        private void Configure(IProviderManagerConfiguration configuration)
        {
            Logger?.Trace("Beginning provider manager configuration.");

            foreach (var providerConfiguration in configuration.ProviderConfigurations)
            {
                Logger?.Debug($"Registering provider '{providerConfiguration.Name}' of type {providerConfiguration.ProviderType.Name}.");
                RegisterProvider(configuration: providerConfiguration);
            }

            Logger?.Trace("Provider manager configuration complete.");
        }

        public INotificationProvider CreateProvider(INotificationProviderConfiguration configuration)
        {
            Logger?.Trace($"Creating new provider '{configuration.Name}' of type {configuration.ProviderType.Name}.");

            var provider = (INotificationProvider)Activator.CreateInstance(configuration.ProviderType);

            if (provider == null)
            {
                Logger?.Warn($"Failed to create provider '{configuration.Name}' of type {configuration.ProviderType.Name}.");
                return null;
            }

            ((ProviderBase)provider).Logger = LoggerProvider.GetLogger(targetType: configuration.ProviderType);
            provider.Configure(configuration: configuration);

            Logger?.Debug($"Created provider '{configuration.Name}' of type {configuration.ProviderType.Name}.");

            return provider;
        }

        public INotificationProvider GetProvider(string name, bool suppressErrors = false)
        {
            INotificationProvider provider;
            var providerFound = Providers.TryGetValue(key: name, value: out provider);

            if (providerFound == false || provider == null)
            {
                if (suppressErrors == true)
                {
                    Logger?.Warn($"Failed to locate provider '{name}'.  Substituting null provider.");
                    provider = new NullProvider();
                    ((NullProvider)provider).Logger = LoggerProvider.GetLogger(targetType: typeof(NullProvider));
                    return provider;
                }
                else
                {
                    Logger?.Fatal($"Failed to locate provider '{name}'.");
                    throw new Exception();
                }
            }

            return provider;
        }

        public INotificationProvider RegisterProvider(INotificationProvider provider)
        {
            if (provider == null)
            {
                Logger?.Fatal("Cannot register a null provider.");
                throw new ArgumentNullException("provider");
            }

            Providers[provider.Name] = provider;

            Logger?.Debug($"Registered provider '{provider.Name}'.");

            return provider;
        }

        public INotificationProvider RegisterProvider(INotificationProviderConfiguration configuration)
        {
            var provider = CreateProvider(configuration: configuration);
            RegisterProvider(provider: provider);

            return provider;
        }
    }
}
