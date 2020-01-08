using WashableSoftware.Crosscutting.Notifications.Core.Manager;
using Ninject.Modules;

namespace WashableSoftware.Crosscutting.Notifications.Bindings.Core
{
    public class ManagerBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<INotificationManager>().To<NotificationManager>().InSingletonScope();
        }
    }
}
