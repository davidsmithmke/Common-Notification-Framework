using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using MountMaryUniversity.Crosscutting.Notifications.Email;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Email
{
    public class EmailProviderBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<INotificationProvider>().To<EmailProvider>().WhenTargetHas<EmailNotificationAttribute>().InSingletonScope();
        }
    }
}
