using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Email
{
    public interface IEmailChannelConfiguration
        : INotificationChannelConfiguration
    {
        string Subject { get; set; }
        IEnumerable<string> To { get; set; }
        string From { get; set; }
    }
}
