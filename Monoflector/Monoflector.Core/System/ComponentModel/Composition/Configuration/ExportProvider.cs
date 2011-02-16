using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace System.ComponentModel.Composition.Configuration
{
    /// <summary>
    /// Represents information about an export provider.
    /// </summary>
    public class ExportProvider
    {
        /// <summary>
        /// Gets or sets the path to the provider.
        /// </summary>
        /// <value>
        /// The path to the provider.
        /// </value>
        [XmlText]
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the export.
        /// </summary>
        /// <value>
        /// The type of the export.
        /// </value>
        [XmlAttribute("ExportType")]
        public ExportType ExportType
        {
            get;
            set;
        }
    }
}
