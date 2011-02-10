using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Monoflector.PluginSystem.Definition
{
    /// <summary>
    /// Represents the deployment element.
    /// </summary>
    public class Deployment
    {
        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>
        /// The actions.
        /// </value>
        [XmlAnyElement]
        public XmlElement[] Actions
        {
            get;
            set;
        }
    }
}
