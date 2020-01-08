using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Core.Templates
{
    public class TemplateManagerConfiguration
        : ITemplateManagerConfiguration
    {
        public TemplateManagerConfiguration()
        {
            FileExtension = TemplateManager.DefaultTemplateExtension;
            TemplateFolders = new List<string>() { TemplateManager.DefaultTemplateFolder };
        }

        public string FileExtension { get; set; }
        public List<string> TemplateFolders { get; set; }
    }
}
