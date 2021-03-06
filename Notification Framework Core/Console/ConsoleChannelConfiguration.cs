﻿using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Console
{
    public class ConsoleChannelConfiguration
        : IConsoleChannelConfiguration
    {
        public string Name { get; set; }
        public INotificationProvider Provider { get; set; }
        public bool UseTimestamp { get; set; }
        public string Template { get; set; }

        public Type ChannelType => typeof(ConsoleChannel);
    }
}
