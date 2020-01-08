using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Console
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ConsoleNotificationAttribute
        : Attribute
    { }
}
