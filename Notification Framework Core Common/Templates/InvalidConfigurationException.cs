using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Templates
{
    public class InvalidConfigurationException
        : Exception
    {
        public InvalidConfigurationException()
            : base() { }

        public InvalidConfigurationException(string message)
            : base(message) { }
    }
}
