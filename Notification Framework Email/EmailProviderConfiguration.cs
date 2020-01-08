using System;

namespace WashableSoftware.Crosscutting.Notifications.Email
{
    public class EmailProviderConfiguration
        : IEmailProviderConfiguration
    {
        public EmailProviderConfiguration()
        {
            DefaultFrom = "noreply@example.com";
            SmtpServerAddress = "localhost";
            SmtpServerPort = 25;
            SmtpEnableSsl = false;
        }

        public string DefaultFrom { get; set; }

        public string Name { get; set; }

        public string SmtpServerAddress { get; set; }

        public int SmtpServerPort { get; set; }

        public bool SmtpEnableSsl { get; set; }

        public Type ProviderType => typeof(EmailProvider);
    }
}
