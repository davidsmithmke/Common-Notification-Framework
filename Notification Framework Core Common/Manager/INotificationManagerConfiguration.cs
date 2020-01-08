using WashableSoftware.Crosscutting.Notifications.Core.Channels;
using WashableSoftware.Crosscutting.Notifications.Core.Providers;
using WashableSoftware.Crosscutting.Notifications.Core.Templates;

namespace WashableSoftware.Crosscutting.Notifications.Core.Manager
{
    public interface INotificationManagerConfiguration
    {
        ITemplateManagerConfiguration TemplateManagerConfiguration { get; set; }
        IProviderManagerConfiguration ProviderManagerConfiguration { get; set; }
        IChannelManagerConfiguration ChannelManagerConfiguration { get; set; }
    }
}
