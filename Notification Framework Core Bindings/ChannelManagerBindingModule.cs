using MountMaryUniversity.Crosscutting.Notifications.Core.Channels;
using Ninject.Modules;

namespace MountMaryUniversity.Crosscutting.Notifications.Bindings.Core
{
    public class ChannelManagerBindingModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IChannelManager>().To<ChannelManager>().InSingletonScope();
        }
    }
}
