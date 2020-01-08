using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Channels
{
    public class InvalidChannelException
        : Exception
    {
        public InvalidChannelException()
            : base() { }

        public InvalidChannelException(string message)
            : base(message) { }
    }
}
