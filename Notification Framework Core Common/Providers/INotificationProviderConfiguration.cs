using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Providers
{
    public interface INotificationProviderConfiguration
    {
        string Name { get; set; }
        Type ProviderType { get; }
    }
}
