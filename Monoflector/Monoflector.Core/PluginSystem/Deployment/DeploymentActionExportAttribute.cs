using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Xml.Serialization;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Marks a type as a deployment action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    [MetadataAttribute]
    public class DeploymentActionExportAttribute : ExportAttribute, IDeploymentActionMetadata
    {
        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <value>
        /// The name of the element.
        /// </value>
        public string ElementName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        public string Namespace
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentActionExportAttribute"/> class.
        /// </summary>
        /// <param name="elementName">The name of the element.</param>
        /// <param name="namespaceUri">The namespace URI.</param>
        public DeploymentActionExportAttribute(string elementName, string namespaceUri)
            : base("Monoflector.PluginSystem.Deployment.DeploymentActionExportAttribute", typeof(XmlSerializer))
        {
            if (string.IsNullOrEmpty(elementName))
                throw new ArgumentNullException("elementName");

            // Get rid of empty string.
            namespaceUri = namespaceUri == "" ? null : namespaceUri;

            ElementName = elementName;
            Namespace = namespaceUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentActionExportAttribute"/> class.
        /// </summary>
        /// <param name="elementName">The name of the element.</param>
        public DeploymentActionExportAttribute(string elementName)
            : this(elementName, null)
        {

        }
    }
}
