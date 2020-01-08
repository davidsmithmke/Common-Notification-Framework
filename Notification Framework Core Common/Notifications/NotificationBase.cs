using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Core.Notifications
{
    abstract public class NotificationBase
        : INotification
    {
        public NotificationBase()
        {
            AdditionalData = new Dictionary<string, object>();
        }

        public Dictionary<string, object> AdditionalData { get; }

        public string Message { get; set; }

        public string Subject { get; set; }
    }
}
