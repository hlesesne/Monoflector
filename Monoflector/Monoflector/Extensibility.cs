using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.ComponentModel.Composition;
using System.IO;

namespace Monoflector.Runtime
{
    static class Extensibility
    {
        private static string[] _environments;
        /// <summary>
        /// Gets the environments.
        /// </summary>
        public static string[] Environments
        {
            get
            {
                if (_environments == null)
                {
                    _environments = WhitespaceSplit(ConfigurationManager.AppSettings["Environments"]).ToArray();
                }
                return _environments;
            }
        }

        internal static CompositionContainer InitializeBootstrapConfiguration()
        {
            var cat1 = new AssemblyCatalog(typeof(IMonoflectorHost).Assembly);
            var cat2 = new DirectoryCatalog(Paths.Bootstrap);
            var acat = new AggregateCatalog(cat1, cat2);
            var ecat = new EnvironmentCatalog(acat, Environments);
            var cont = new CompositionContainer(ecat);
            CompositionServices.Initialize(cont);
            return cont;
        }

        internal static CompositionContainer InitializeConfiguration(ExportContext context)
        {
            var cat1 = PluginCatalog.Create(context);
            if (cat1 == null)
                return null;
            var ecat = new EnvironmentCatalog(cat1, Environments);
            var cont = new CompositionContainer(ecat);
            CompositionServices.Initialize(cont);
            return cont;
        }

        static IEnumerable<string> WhitespaceSplit(string source) // In accordance with XML multi-values.
        {
            if (string.IsNullOrEmpty(source))
                yield break;
            var current = new StringBuilder(source.Length);
            foreach (var c in source)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (current.Length > 0)
                    {
                        yield return current.ToString();
                        current.Clear();
                    }
                }
                else
                {
                    current.Append(c);
                }
            }

            if (current.Length > 0)
            {
                yield return current.ToString();
            }
        }
    }
}
