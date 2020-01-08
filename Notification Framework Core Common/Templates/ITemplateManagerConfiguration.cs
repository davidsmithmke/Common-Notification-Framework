using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Core.Templates
{
    public interface ITemplateManagerConfiguration
    {
        string FileExtension { get; set; }
        List<string> TemplateFolders { get; set; }
    }
}