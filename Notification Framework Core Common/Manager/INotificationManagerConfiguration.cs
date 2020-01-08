using MountMaryUniversity.Crosscutting.Notifications.Core.Channels;
using MountMaryUniversity.Crosscutting.Notifications.Core.Providers;
using MountMaryUniversity.Crosscutting.Notifications.Core.Templates;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Manager
{
    public interface INotificationManagerConfiguration
    {
        ITemplateManagerConfiguration TemplateManagerConfiguration { get; set; }
        IProviderManagerConfiguration ProviderManagerConfiguration { get; set; }
        IChannelManagerConfiguration ChannelManagerConfiguration { get; set; }
    }
}
