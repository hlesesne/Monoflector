using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Monoflector.PluginSystem.Definition;

namespace System.ComponentModel.Composition.Configuration
{
    /// <summary>
    /// Represents plugin activatation configuration.
    /// </summary>
    public class PluginExportConfiguration
    {
        /// <summary>
        /// Gets or sets the plugin identity.
        /// </summary>
        /// <value>
        /// The plugin identity.
        /// </value>
        [XmlAttribute("Identity")]
        public string PluginIdentity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the plugin category.
        /// </summary>
        /// <value>
        /// The plugin category.
        /// </value>
        [XmlAttribute("Category")]
        public PluginCategory PluginCategory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if this instance is active; otherwise, <see langword="false"/>.
        /// </value>
        [XmlAttribute("Active")]
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the export providers.
        /// </summary>
        /// <value>
        /// The export providers.
        /// </value>
        [XmlElement("Export", Namespace = PluginConfiguration.Xmlns)]
        public List<string> ExportProviders
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginExportConfiguration"/> class.
        /// </summary>
        public PluginExportConfiguration()
        {
            ExportProviders = new List<string>();
        }
    }
}
