using MountMaryUniversity.Crosscutting.Notifications.Core.Manager;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Core
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
