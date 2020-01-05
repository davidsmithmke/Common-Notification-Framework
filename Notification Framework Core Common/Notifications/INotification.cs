using System.Collections.Generic;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Notifications
{
    public interface INotification
    {
        Dictionary<string, object> AdditionalData { get; }
        string Message { get; set; }
        string Subject { get; set; }
    }
}
