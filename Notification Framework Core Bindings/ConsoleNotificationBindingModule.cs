using MountMaryUniversity.Crosscutting.Notifications.Core.Console;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Core
{
    public class ConsoleNotificationBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<INotificationProvider>().To<ConsoleProvider>().WhenTargetHas<ConsoleNotificationAttribute>().InSingletonScope();
        }
    }
}
