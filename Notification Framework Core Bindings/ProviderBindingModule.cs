using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Core
{
    public class ProviderBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IProviderManager>().To<ProviderManager>().InSingletonScope();
        }
    }
}
