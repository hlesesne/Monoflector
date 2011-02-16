using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Configuration;
using System.IO;
using Monoflector.Runtime;
using System.Xml.Linq;

namespace System.ComponentModel.Composition.Hosting
{
    /// <summary>
    /// Represents a plugin-type catalog.
    /// </summary>
    public class PluginCatalog : AggregateCatalog
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="PluginCatalog"/> class from being created.
        /// </summary>
        private PluginCatalog()
        {

        }

        /// <summary>
        /// Creates the plugin catalog.
        /// </summary>
        /// <returns>The <see cref="PluginCatalog"/>.</returns>
        public static PluginCatalog Create(ExportContext context)
        {
            var config = PluginConfiguration.Load();
            if (config == null)
                return null;

            var catalog = new PluginCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PluginCatalog).Assembly));
            foreach (var pluginExport in config.GetContext(context).PluginExports)
            {
                if(pluginExport.IsActive)
                {
                    var path = Path.Combine(Paths.Root, pluginExport.PluginCategory.ToString(), pluginExport.PluginIdentity.Replace('/', Path.DirectorySeparatorChar));
                    var manifestPath = Path.Combine(path, "manifest.xml");
                    var doc = Monoflector.PluginSystem.Definition.PluginDefinition.Load(manifestPath);

                    foreach (var assemExport in pluginExport.ExportProviders)
                    {
                        var path2 = Path.Combine(path, assemExport.Path);
                        switch (assemExport.ExportType)
                        {
                            case ExportType.Assembly:
                                catalog.Catalogs.Add(new AssemblyCatalog(path2));
                                break;
                        }
                    }
                }
            }

            return catalog;
        }
    }
}
