using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public interface INotificationChannelConfiguration
    {
        string Name { get; set; }
        INotificationProvider Provider { get; set; }
        string Template { get; set; }
        Type ChannelType { get; }
    }
}