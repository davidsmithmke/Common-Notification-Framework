using System;

namespace WashableSoftware.Crosscutting.Notifications.Email
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailNotificationAttribute
        : Attribute
    { }
}
