using System.Collections.Generic;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Templates
{
    public class TemplateManagerConfiguration
        : ITemplateManagerConfiguration
    {
        public string FileExtension { get; set; }
        public List<string> TemplateFolders { get; set; }
    }
}
