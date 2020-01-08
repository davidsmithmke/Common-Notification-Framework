using MountMaryUniversity.Crosscutting.Notifications.Core.Notifications;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using System.Threading.Tasks;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Console
{
    public class ConsoleProvider
        : ProviderBase, INotificationProvider
    {
        public ConsoleProvider()
            : base()
        { }

        public ConsoleProvider(ILogger logger)
            : base(logger: logger) { }

        override async public Task SendAsync(INotification notification)
        {
            try
            {
                await System.Console.Out.WriteLineAsync(notification.Message);

                Logger.Debug("Console notification sent.");
            }
            catch (System.Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }
    }
}
