using System;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Console
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ConsoleNotificationAttribute
        : Attribute
    { }
}
