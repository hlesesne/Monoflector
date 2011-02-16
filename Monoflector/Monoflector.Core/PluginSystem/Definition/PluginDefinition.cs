using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Monoflector.PluginSystem.Definition
{
    /// <summary>
    /// Represents a plugin definition.
    /// </summary>
    [XmlRoot(ElementName = "Plugin", Namespace = Xmlns)]
    public class PluginDefinition
    {
        /// <summary>
        /// Gets the namespace for the plugin definition type.
        /// </summary>
        public const string Xmlns = "http://schemas.monoflector.org/plugins/2011/definition";

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
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [XmlAttribute("Version")]
        public string Version
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
        public PluginCategory Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title of the plugin.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [XmlElement("Title", Namespace = Xmlns)]
        public LocalizedElement[] Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author of the plugin.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [XmlElement("Author", Namespace = Xmlns)]
        public LocalizedElement[] Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of the plugin.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [XmlElement("Description", Namespace = Xmlns)]
        public LocalizedElement[] Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the relative location of the readme.
        /// </summary>
        /// <value>
        /// The readme locations.
        /// </value>
        [XmlElement("Readme", Namespace = Xmlns)]
        public LocalizedElement[] Readme
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the plugins that this plugin requries.
        /// </summary>
        /// <value>
        /// The plugins that this plugin requires.
        /// </value>
        [XmlElement("Requires", Namespace = Xmlns)]
        public Guid[] Requires
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the deployment element.
        /// </summary>
        /// <value>
        /// The deployment element.
        /// </value>
        [XmlElement("Deployment", Namespace = Xmlns)]
        public Deployment Deployment
        {
            get;
            set;
        }

        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(PluginDefinition));
        /// <summary>
        /// Loads a <see cref="PluginDefinition"/> from the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The <see cref="PluginDefinition"/>.</returns>
        public static PluginDefinition Load(string filename)
        {
            using (var reader = XmlReader.Create(filename))
            {
                return (PluginDefinition)_serializer.Deserialize(reader);
            }
        }
    }
}
