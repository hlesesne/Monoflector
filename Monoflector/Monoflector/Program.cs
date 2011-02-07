using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Threading;
using System.Text;

namespace Monoflector.Runtime
{
    static class Program
    {
        static string[] Environments;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var threadType = ApartmentState.MTA;
            var cfgThread = ConfigurationManager.AppSettings["ThreadRequirement"];
            if (!string.IsNullOrEmpty(cfgThread))
            {
                Enum.TryParse<ApartmentState>(cfgThread, out threadType);
            }

            var thread = new Thread(MainWorker);
            thread.SetApartmentState(threadType);
            thread.Start(args);
            thread.CurrentCulture = thread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            thread.Join();
        }

        static void MainWorker(object argsObject)
        {
            using (CreateContainer())
            {
                var runtime = CompositionServices.CompositionContainer.GetExportedValues<IMonoflectorHost>().FirstOrDefault();
                if (runtime == null)
                    throw new Exception(string.Format(Monoflector.Runtime.Properties.Resources.NoEnvironment, string.Join(", ", Environments)));
                runtime.Run((string[])argsObject);
            }
        }

        static CompositionContainer CreateContainer()
        {
            Environments = WhitespaceSplit(ConfigurationManager.AppSettings["Environments"]).ToArray();

            var cat1 = new DirectoryCatalog(".\\plugins");
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
