using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;

namespace MountMaryUniversity.Crosscutting.Notifications.Email
{
    public interface IEmailProviderConfiguration
        : INotificationProviderConfiguration
    {
        string DefaultFrom { get; set; }
        string SmtpServerAddress { get; set; }
        int SmtpServerPort { get; set; }
        bool SmtpEnableSsl { get; set; }
    }
}
