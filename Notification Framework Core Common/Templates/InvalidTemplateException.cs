using System;

namespace WashableSoftware.Crosscutting.Notifications.Core.Templates
{
    public class InvalidTemplateException
        : Exception
    {
        public string TemplateName { get; }

        public InvalidTemplateException(string templateName)
            : base()
        {
            TemplateName = templateName;
        }

        public InvalidTemplateException(string templateName, string message)
            : base(message)
        {
            TemplateName = templateName;
        }
    }
}
