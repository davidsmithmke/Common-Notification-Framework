using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using Washable.Logging.Common;

namespace MountMaryUniversity.Crosscutting.Notifications.Core.Templates
{
    public class TemplateManager
        : ITemplateManager
    {
        public const string DefaultTemplateExtension = "template";
        public const string DefaultTemplateFolder = "NotificationTemplates";

        private string TemplateExtension { get; set; }
        private Dictionary<string, Func<object, string>> Templates { get; set; }
        public ILogger Logger { get; }

        public TemplateManager(ILogger logger, ITemplateManagerConfiguration configuration)
        {
            Templates = new Dictionary<string, Func<object, string>>();
            Logger = logger;

            Configure(configuration: configuration);
        }

        public ITemplateManager AddTemplateFolder(string path)
        {
            Logger.Debug("Adding template folder tree with root {0} to configuration.", path);

            if (String.IsNullOrWhiteSpace(TemplateExtension))
            {
                Logger.Error("Template file extension has not been configured.");
                throw new InvalidConfigurationException("Template file extension has not been configured.");
            }

            if (Directory.Exists(path) == false)
                throw new ArgumentException($"Specified path '{path}' does not exist.", "path");

            // Get all subdirectories in template folder tree
            Logger.Trace("Adding root template folder {0} to configuration.", path);
            var templateFolders = new List<string>
            {
                path
            };

            var templateFolderSubfolders = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var templateSubFolder in templateFolderSubfolders)
            {
                Logger.Trace("Adding template subfolder {0} to configuration.", templateSubFolder);
                templateFolders.Add(templateSubFolder);
            }

            // Enumerate all templates in the template folder tree
            foreach (var folder in templateFolders)
            {
                // Enumerate all templates in the specified folder
                var templateFiles = Directory.EnumerateFiles(folder, String.Format("*.{0}", TemplateExtension));
                foreach (var file in templateFiles)
                {
                    string templateName = Path.GetFileNameWithoutExtension(file);
                    string templatePath = file;

                    var templateText = LoadTemplateFromDisk(path: templatePath);
                    var template = Handlebars.Compile(template: templateText);

                    Templates.Add(key: templateName, value: template);

                    Logger.Debug("Template {0} registered.", templateName);
                }
            }

            return this;
        }

        private ITemplateManager Configure(ITemplateManagerConfiguration configuration)
        {
            Logger.Trace("Beginning template manager configuration.");

            if (String.IsNullOrWhiteSpace(configuration.FileExtension))
                configuration.FileExtension = DefaultTemplateExtension;

            TemplateExtension = configuration.FileExtension;

            if (configuration.TemplateFolders == null || configuration.TemplateFolders.Count == 0)
                configuration.TemplateFolders = new List<string>() { DefaultTemplateFolder };

            if (configuration.TemplateFolders.Count == 1 && Directory.Exists(configuration.TemplateFolders[0]) == false)
                throw new InvalidConfigurationException($"Specified template folder '{configuration.TemplateFolders[0]}' does not exist.");

            if (configuration.TemplateFolders.Count > 0)
            {
                foreach (var templateFolder in configuration.TemplateFolders)
                {
                    if (Directory.Exists(path: templateFolder))
                    {
                        AddTemplateFolder(path: templateFolder);
                    }
                    else
                    {
                        Logger.Warn($"Specified template folder '{templateFolder}' does not exist.  Not adding to template manager configuration.");
                    }
                }
            }

            Logger.Debug("Template manager configured.");

            return this;
        }

        public IEnumerable<string> GetTemplateNames()
        {
            return Templates.Keys;
        }

        public bool IsTemplateRegistered(string name)
        {
            return Templates.ContainsKey(name);
        }

        private string LoadTemplateFromDisk(string path)
        {
            if (File.Exists(path: path) == false)
            {
                Logger.Error("Specified template file ({0}) does not exist.", path);
                throw new ArgumentException("Invalid template path.");
            }

            try
            {
                var templateText = File.ReadAllText(path: path);

                Logger.Trace("Template loaded from file {0}.", path);

                return templateText;
            }
            catch (Exception e)
            {
                Logger.Error("Unexpected error when attempting to load template from disk.");
                Logger.Error(e);

                throw;
            }
        }

        public string ProcessTemplate(string name, object data)
        {
            if (IsTemplateRegistered(name: name) == false)
            {
                Logger.Error("Template {0} is not registered with the template manager.", name);
                throw new InvalidTemplateException(templateName: name, message: "Specified template is not registered with the template manager.");
            }

            return Templates[key: name](data);
        }
    }
}
