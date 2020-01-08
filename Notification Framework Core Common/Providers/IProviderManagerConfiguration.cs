using System.Collections.Generic;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public interface IProviderManagerConfiguration
    {
        void AddConfiguration(INotificationProviderConfiguration configuration);
        IEnumerable<INotificationProviderConfiguration> ProviderConfigurations { get; }
    }
}
