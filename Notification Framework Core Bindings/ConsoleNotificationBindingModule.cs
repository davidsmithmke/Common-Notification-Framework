using WashableSoftware.Crosscutting.Notifications.Core.Console;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using Ninject.Modules;

namespace WashableSoftware.Crosscutting.Notifications.Bindings.Core
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
