using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Monoflector.Runtime;
using System.Xml;

namespace System.ComponentModel.Composition.Configuration
{
    /// <summary>
    /// Represents plugin configuration.
    /// </summary>
    [XmlRoot("PluginConfiguration", Namespace = Xmlns)]
    public class PluginConfiguration
    {
        /// <summary>
        /// Gets the namespace for <see cref="PluginConfiguration"/>.
        /// </summary>
        public const string Xmlns = "http://schemas.monoflector.org/plugins/2011/configuration";

        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(PluginConfiguration));

        /// <summary>
        /// Gets or sets the normal context.
        /// </summary>
        /// <value>
        /// The normal context.
        /// </value>
        [XmlElement("Normal", Namespace = Xmlns)]
        public ExportContextConfiguration Normal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the installation.
        /// </summary>
        /// <value>
        /// The installation.
        /// </value>
        [XmlElement("Installation", Namespace = Xmlns)]
        public ExportContextConfiguration Installation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the context of the given type.
        /// </summary>
        /// <param name="context">The context type.</param>
        /// <returns>The context configuration.</returns>
        public ExportContextConfiguration GetContext(ExportContext context)
        {
            switch (context)
            {
                case ExportContext.Normal:
                    return Normal ?? (Normal = new ExportContextConfiguration());
                case ExportContext.Installation:
                    return Installation ?? (Installation = new ExportContextConfiguration());
                default:
                    throw new NotSupportedException(Monoflector.Properties.Resources.ContextNotSupported);
            }
        }

        /// <summary>
        /// Loads the plugin configuration from disk.
        /// </summary>
        /// <returns>The plugin configuration.</returns>
        public static PluginConfiguration Load()
        {
            var path = Path.Combine(Paths.Root, "plugins.xml");
            if (!File.Exists(path))
                return null;
            using (var reader = XmlReader.Create(path))
            {
                return (PluginConfiguration)_serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void Save()
        {
            var path = Path.Combine(Paths.Root, "plugins.xml");
            if (File.Exists(path))
                File.Delete(path);
            using (var writer = XmlWriter.Create(path))
            {
                _serializer.Serialize(writer, this);
            }
        }
    }
}
