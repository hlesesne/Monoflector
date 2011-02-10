using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace System.ComponentModel.Composition.Configuration
{
    /// <summary>
    /// Represents export configuration for a certain context.
    /// </summary>
    public class ExportContextConfiguration
    {
        /// <summary>
        /// Gets or sets the exports.
        /// </summary>
        /// <value>
        /// The exports.
        /// </value>
        [XmlElement("Plugin", Namespace = PluginConfiguration.Xmlns)]
        public List<PluginExportConfiguration> PluginExports
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportContextConfiguration"/> class.
        /// </summary>
        public ExportContextConfiguration()
        {
            PluginExports = new List<PluginExportConfiguration>();
        }
    }
}
