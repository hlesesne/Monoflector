using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Threading;
using System.Text;
using System.IO;
using Monoflector.Interface;
using Monoflector.PluginSystem.Deployment;

namespace Monoflector.Runtime
{
    static class Program
    {
        private static bool _installingPlugin;

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
            var args = (string[])argsObject;
            if (args.Where(x => Path.GetExtension(x) == ".mfplug").FirstOrDefault() != null)
            {
                _installingPlugin = true;
            }

            if (!Run(args))
            {
                if (!Bootstrap(args))
                {

                }
                if (!Run(args))
                {

                }
            }
        }

        private static bool Run(string[] args)
        {
            if (_installingPlugin)
            {
                return Run(ExportContext.Installation, args) &&
                    Run(ExportContext.Normal, args);
            }
            else
            {
                return Run(ExportContext.Normal, args);
            }
        }

        private static bool Run(ExportContext exportContext, string[] args)
        {
            using (var ctx = Extensibility.InitializeConfiguration(exportContext))
            {
                if (ctx == null)
                    return false;

                var runtime = ctx.GetExportedValues<IMonoflectorHost>().FirstOrDefault();
                if (runtime == null)
                    return false;

                runtime.InstallPlugins = exportContext == ExportContext.Installation;
                runtime.Run(args);
                return true;
            }
        }

        private static bool Bootstrap(string[] args)
        {
            using (var ctx = Extensibility.InitializeBootstrapConfiguration())
            {
                var runtime = ctx.GetExportedValues<IMonoflectorHost>().FirstOrDefault();
                if (runtime == null)
                    return false;

                runtime.Bootstrapping = true;
                runtime.Run(args);

                return true;
            }
        }
    }
}
