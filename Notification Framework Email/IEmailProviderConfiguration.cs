using WashableSoftware.Crosscutting.Notifications.Core.Providers;

namespace WashableSoftware.Crosscutting.Notifications.Email
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
