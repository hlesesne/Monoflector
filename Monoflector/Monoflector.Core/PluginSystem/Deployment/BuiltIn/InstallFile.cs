using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Monoflector.PluginSystem.Deployment.BuiltIn
{
    /// <summary>
    /// Represents an action that installs a file.
    /// </summary>
    [XmlRoot("copy", Namespace = "http://schemas.monoflector.org/plugins/2011/deployment/files")]
    public class InstallFile : IDeploymentAction
    {
        /// <summary>
        /// Gets the XML Serializer that can be used to serialize this type.
        /// </summary>
        [DeploymentActionExport("copy", "http://schemas.monoflector.org/plugins/2011/deployment/files")]
        public static readonly XmlSerializer Serializer = new XmlSerializer(typeof(InstallFile));

        /// <summary>
        /// Gets or sets the filename of the file that should be copied.
        /// </summary>
        /// <value>
        /// The filename that should be copied.
        /// </value>
        [XmlAttribute("Filename")]
        public string Filename
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallFile"/> class.
        /// </summary>
        public InstallFile()
        {

        }

        /// <summary>
        /// Performs a deployment.
        /// </summary>
        /// <param name="context">The deployment context.</param>
        public void Deploy(DeploymentContext context)
        {
            if (string.IsNullOrEmpty(Filename))
                return;
            var normalPath = Filename.Replace('/', Path.DirectorySeparatorChar);
            var destination = Path.Combine(context.DestinationPath, normalPath);

            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            if (File.Exists(destination))
            {
                try
                {
                    File.Delete(destination);
                }
                catch
                {
                    return;
                }
            }

            try
            {
                context.ExtractFile(Filename, destination);
            }
            catch
            {
                return;
            }
        }
    }
}
