using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using WashableSoftware.Crosscutting.Notifications.Email;
using Ninject.Modules;

namespace WashableSoftware.Crosscutting.Notifications.Bindings.Email
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
