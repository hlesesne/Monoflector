using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;

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

        public static CompositionContainer InitializeRuntimeComposition()
        {
            var cat1 = new DirectoryCatalog(Paths.Plugins);
            var cat2 = new AssemblyCatalog(typeof(Program).Assembly);
            var cat3 = new AssemblyCatalog(typeof(CompositionServices).Assembly);
            var cat = new AggregateCatalog(cat1, cat2, cat3);
            var ecat = new EnvironmentCatalog(cat, Environments);
            var cont = new CompositionContainer(ecat);
            CompositionServices.Initialize(cont);
            return cont;
        }

        internal static CompositionContainer InitializeBootstrapComposition()
        {
            var cat1 = new DirectoryCatalog(Paths.Bootstrap);
            var cat2 = new AssemblyCatalog(typeof(Program).Assembly);
            var cat3 = new AssemblyCatalog(typeof(CompositionServices).Assembly);
            var cat = new AggregateCatalog(cat1, cat2, cat3);
            var ecat = new EnvironmentCatalog(cat, Environments);
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
