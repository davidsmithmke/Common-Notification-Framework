using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Console
{
    public class ConsoleProviderConfiguration
        : INotificationProviderConfiguration
    {
        public string Name { get; set; }
        public Type ProviderType => typeof(ConsoleProvider);
    }
}
