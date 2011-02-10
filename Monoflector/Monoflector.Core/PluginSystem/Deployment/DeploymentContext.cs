using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;
using Monoflector.PluginSystem.Definition;
using System.ComponentModel.Composition;
using Monoflector.Runtime;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel.Composition.Configuration;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Represents a deployment context.
    /// </summary>
    public class DeploymentContext : IPartImportsSatisfiedNotification, IDisposable
    {
        [ImportMany("Monoflector.PluginSystem.Deployment.DeploymentActionExportAttribute", typeof(XmlSerializer))]
        private IEnumerable<Lazy<XmlSerializer, IDeploymentActionMetadata>> _deploymentActions;
        private Dictionary<XName, XmlSerializer> _actionInstances;

        private static HashSet<string> _defaultExtractions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes the <see cref="DeploymentContext"/> class.
        /// </summary>
        static DeploymentContext()
        {
            _defaultExtractions.Add("manifest.xml");
        }

        /// <summary>
        /// Gets the plugin definition.
        /// </summary>
        public PluginDefinition PluginDefinition
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the destination path.
        /// </summary>
        public string DestinationPath
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the plugins root.
        /// </summary>
        public string PluginsRoot
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the plugin configuration.
        /// </summary>
        public PluginConfiguration PluginConfiguration
        {
            get;
            private set;
        }

        private ZipFile _zipFile;
        private string _tempDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentContext"/> class.
        /// </summary>
        private DeploymentContext(ZipFile zipFile, PluginDefinition pluginDefinition)
        {
            PluginDefinition = pluginDefinition;

            _zipFile = zipFile;

            PluginsRoot = Paths.Plugins;
            DestinationPath = Path.Combine(PluginsRoot, PluginDefinition.PluginIdentity.Replace('/', Path.DirectorySeparatorChar));
        }

        /// <summary>
        /// Deploys this instance.
        /// </summary>
        public void Deploy()
        {
            this.ComposeParts();
            PluginConfiguration = PluginConfiguration.Load() ?? new PluginConfiguration();
            if (PluginDefinition != null && 
                PluginDefinition.Deployment != null && 
                PluginDefinition.Deployment.Actions != null)
            {
                foreach (var action in PluginDefinition.Deployment.Actions)
                {
                    var n = XName.Get(action.LocalName, action.NamespaceURI);
                    XmlSerializer ser;
                    if (_actionInstances.TryGetValue(n, out ser))
                    {
                        using (var sr = new StringReader(action.OuterXml))
                        {
                            var def = (IDeploymentAction)ser.Deserialize(sr);
                            def.Deploy(this);
                        }
                    }
                    else
                    {
                        return; // TODO: Log
                    }
                }

                PluginConfiguration.Save();
            }
        }

        /// <summary>
        /// Extracts a single file.
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        /// <param name="targetFile">The target file.</param>
        public void ExtractFile(string sourceFile, string targetFile)
        {
            using(var fs = new FileStream(targetFile, FileMode.Create))
            {
                _zipFile[sourceFile].Extract(fs);
            }
        }

        /// <summary>
        /// Extracts a single file to the temp directory.
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        /// <returns>The file.</returns>
        public string ExtractFile(string sourceFile)
        {
            var targetFile = sourceFile
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);
            targetFile = Path.Combine(_tempDirectory, targetFile);
            ExtractFile(sourceFile, targetFile);
            return targetFile;
        }

        /// <summary>
        /// Extracts a directory to the temp directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns>The path to the directory.</returns>
        public string ExtractDirectory(string directory)
        {
            var targetFile = directory
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);
            targetFile = Path.Combine(_tempDirectory, targetFile);

            if (!directory.EndsWith("/"))
                directory += "/";

            Directory.CreateDirectory(targetFile);
            foreach (var file in _zipFile.EntryFileNames)
            {
                if (file.StartsWith(directory, StringComparison.OrdinalIgnoreCase))
                {
                    ExtractFile(file);
                }
            }
            return targetFile;
        }

        /// <summary>
        /// Creates the deployment context instance.
        /// </summary>
        /// <returns>The deployment context.</returns>
        public static DeploymentContext Create(string filename)
        {
            var tempDir = Path.GetTempFileName();
            File.Delete(tempDir);
            Directory.CreateDirectory(tempDir);

            try
            {
                var file = ZipFile.Read(filename);
                var copy = new HashSet<string>(_defaultExtractions, StringComparer.OrdinalIgnoreCase);
                foreach (var fn in file.EntryFileNames.Where(x => copy.Remove(x)))
                {
                    file[fn].Extract(tempDir);
                }

                if (copy.Count > 0)
                {
                    return null; // TODO: Logging
                }

                var def = PluginDefinition.Load(Path.Combine(tempDir, "manifest.xml"));

                return new DeploymentContext(file, def)
                {
                    _tempDirectory = tempDir
                };
            }
            finally
            {

            }
        }

        /// <summary>
        /// Called when all parts imports have been satisfied.
        /// </summary>
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            _actionInstances = new Dictionary<XName, XmlSerializer>();
            foreach (var act in _deploymentActions)
            {
                _actionInstances.Add(XName.Get(act.Metadata.ElementName, act.Metadata.Namespace), act.Value);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            var tmp = _zipFile;
            _zipFile = null;
            if (tmp != null)
                tmp.Dispose();
            try
            {
                Directory.Delete(_tempDirectory, true);
            }
            finally
            {

            }
        }
    }
}
