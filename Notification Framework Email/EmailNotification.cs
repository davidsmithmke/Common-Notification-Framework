using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using System.Collections.Generic;

namespace MountMaryUniversity.Crosscutting.Notifications.Email
{
    public class EmailNotification
        : NotificationBase, INotification
    {
        public IEnumerable<string> To
        {
            get
            {
                return (IEnumerable<string>)AdditionalData["To"];
            }
            set
            {
                AdditionalData["To"] = value;
            }
        }

        public string From
        {
            get
            {
                return (string)AdditionalData["From"];
            }
            set
            {
                AdditionalData["From"] = value;
            }
        }
    }
}
