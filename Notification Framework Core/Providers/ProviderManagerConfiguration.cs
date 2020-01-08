using System.Collections.Generic;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public class ProviderManagerConfiguration
        : IProviderManagerConfiguration
    {
        public ProviderManagerConfiguration(ILogger logger)
        {
            Logger = logger;

            providerConfigurations = new List<INotificationProviderConfiguration>();
        }

        private List<INotificationProviderConfiguration> providerConfigurations;

        protected ILogger Logger { get; }

        public IEnumerable<INotificationProviderConfiguration> ProviderConfigurations { get => providerConfigurations; }

        public void AddConfiguration(INotificationProviderConfiguration configuration)
        {
            providerConfigurations.Add(item: configuration);
        }
    }
}
