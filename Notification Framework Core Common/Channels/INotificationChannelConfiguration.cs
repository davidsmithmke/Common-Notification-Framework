﻿using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using System;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Channels
{
    public interface INotificationChannelConfiguration
    {
        string Name { get; set; }
        INotificationProvider Provider { get; set; }
        string Template { get; set; }
    }
}