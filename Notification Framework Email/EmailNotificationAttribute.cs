using System;

namespace MountMaryUniversity.Crosscutting.Notifications.Email
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailNotificationAttribute
        : Attribute
    { }
}
