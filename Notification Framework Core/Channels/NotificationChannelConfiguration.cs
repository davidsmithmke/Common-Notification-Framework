﻿using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using System;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public class NotificationChannelConfiguration
        : INotificationChannelConfiguration
    {
        public string Name { get; set; }
        public INotificationProvider Provider { get; set; }
        public string Template { get; set; }

        public Type ChannelType => throw new NotImplementedException();
    }
}
