using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using Ninject.Modules;

namespace WashableSoftware.Crosscutting.Notifications.Bindings.Core
{
    public class ChannelBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IChannelManager>().To<ChannelManager>().InSingletonScope();
        }
    }
}
