using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Core
{
    public class TemplateBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ITemplateManager>().To<TemplateManager>().InSingletonScope();
        }
    }
}
