using System.Collections.Generic;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;

namespace MountMaryUniversity.Crosscutting.Notifications.Email
{
    public class EmailChannelConfiguration
        : IEmailChannelConfiguration
    {
        public string From { get; set; }
        
        public string Name { get; set; }

        public INotificationProvider Provider { get; set; }

        public string Template { get; set; }

        public string Subject { get; set; }

        public IEnumerable<string> To { get; set; }
    }
}
