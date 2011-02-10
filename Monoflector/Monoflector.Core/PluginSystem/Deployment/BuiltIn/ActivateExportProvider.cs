using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Configuration;

namespace Monoflector.PluginSystem.Deployment.BuiltIn
{
    /// <summary>
    /// Activates a export provider.
    /// </summary>
    [XmlRoot("activate", Namespace = "http://schemas.monoflector.org/plugins/2011/deployment/mef")]
    public class ActivateExportProvider : IDeploymentAction
    {
        /// <summary>
        /// Gets the XML Serializer that can be used to serialize this type.
        /// </summary>
        [DeploymentActionExport("activate", "http://schemas.monoflector.org/plugins/2011/deployment/mef")]
        public static readonly XmlSerializer Serializer = new XmlSerializer(typeof(ActivateExportProvider));

        /// <summary>
        /// Gets or sets the export context.
        /// </summary>
        /// <value>
        /// The export context.
        /// </value>
        [XmlAttribute("Context")]
        public ExportContext ExportContext
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        [XmlAttribute("Filename")]
        public string Filename
        {
            get;
            set;
        }

        /// <summary>
        /// Performs a deployment.
        /// </summary>
        /// <param name="context">The deployment context.</param>
        public void Deploy(DeploymentContext context)
        {
            var id = context.PluginDefinition.PluginIdentity;
            var ctx = context.PluginConfiguration.GetContext(ExportContext);
            var item = ctx.PluginExports.Where(x => string.Compare(id, x.PluginIdentity) == 0).FirstOrDefault();
            if (item == null)
                ctx.PluginExports.Add(item = new PluginExportConfiguration() { PluginIdentity = id });
            item.IsActive = true;
            if (!item.ExportProviders.Contains(Filename))
                item.ExportProviders.Add(Filename);
        }
    }
}
