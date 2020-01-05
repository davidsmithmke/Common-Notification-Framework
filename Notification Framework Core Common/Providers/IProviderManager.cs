namespace MountMaryUniversity.Crosscutting.Notifications.Core.Providers
{
    public interface IProviderManager
    {
        INotificationProvider CreateProvider(INotificationProviderConfiguration configuration);
        INotificationProvider GetProvider(string name);
        INotificationProvider RegisterProvider(INotificationProvider provider);
        INotificationProvider RegisterProvider(INotificationProviderConfiguration configuration);
    }
}
