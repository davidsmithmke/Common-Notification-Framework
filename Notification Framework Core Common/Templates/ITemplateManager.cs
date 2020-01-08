using System.Collections.Generic;

namespace WashableSoftware.Crosscutting.Notifications.Core.Templates
{
    public interface ITemplateManager
    {
        ITemplateManager AddTemplateFolder(string path);
        IEnumerable<string> GetTemplateNames();
        bool IsTemplateRegistered(string name);
        string ProcessTemplate(string name, object data);
    }
}
