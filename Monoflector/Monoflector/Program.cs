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
using Monoflector.PluginPackaging;
using Monoflector.PluginPackaging;

namespace Monoflector.Runtime
{
    static class Program
    {
        private static IEnumerable<IMonoflectorBootstrapper> _bootstrapper;
        private static IPluginInstallation _installer;
        private static PluginPackage _package;

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
            PluginPackage pluginInstall = null;

            if (args.Length == 1)
            {
                var fn = args[0];
                if (Path.GetExtension(fn) == ".mfplug")
                {
                    pluginInstall = PluginPackage.Load(fn);
                }
            }
            
            // First try and create a runtime.
            if (pluginInstall == null)
            {
                using (Extensibility.InitializeRuntimeComposition())
                {
                    var runtime = CompositionServices.CompositionContainer.GetExportedValues<IMonoflectorHost>().FirstOrDefault();
                    if (runtime != null)
                    {
                        runtime.Run((string[])argsObject);
                        return;
                    }
                }
            }

            // If that fails it means nothing has been set up.
            // Attempt to bootstrap.
            using (Extensibility.InitializeBootstrapComposition())
            {
                _installer = CompositionServices.CompositionContainer.GetExportedValues<IPluginInstallation>().FirstOrDefault();
                if (_installer == null)
                    throw new Exception(string.Format(Properties.Resources.NoEnvironment, string.Join(", ", Extensibility.Environments)));

                if (pluginInstall == null) // Boostrap mode.
                {
                    if (_installer.ShowBootstrapInterface())
                    {
                        _installer.ShowInterface();
                        _bootstrapper = CompositionServices.CompositionContainer.GetExportedValues<IMonoflectorBootstrapper>();

                        var worker = new Thread(BootstrapWorker);
                        worker.Start();
                        _installer.WaitForClose();
                    }
                }
                else // Plugin mode.
                {
                    if (_installer.ShowConfirmation(_package = pluginInstall))
                    {
                        _installer.ShowInterface();

                        var worker = new Thread(InstallerWorker);
                        worker.Start();
                        _installer.WaitForClose();
                    }
                }
            }

            // Try again.
            using (Extensibility.InitializeRuntimeComposition())
            {
                var runtime = CompositionServices.CompositionContainer.GetExportedValues<IMonoflectorHost>().FirstOrDefault();
                if (runtime != null)
                {
                    runtime.Run((string[])argsObject);
                }
                else
                {
                    throw new Exception(string.Format(Properties.Resources.NoEnvironment, string.Join(", ", Extensibility.Environments))); 
                }
            }
        }

        private static void BootstrapWorker()
        {
            foreach (var bs in _bootstrapper)
            {
                bs.Install();
            }

            _installer.ShowClose();
        }

        private static void InstallerWorker()
        {
            using (_package)
            {
                var manager = CompositionServices.CompositionContainer.GetExportedValues<IPluginManager>().FirstOrDefault();
                for (var i = 0; i < _package.Installables.Length; i++)
                {
                    var progress = (i * 100) / _package.Installables.Length;
                    var installable = _package.Installables[i];

                    manager.Update(_package.Title, installable, progress);
                    _package.Extract(installable, Paths.Plugins);
                    Thread.Sleep(1000);
                }
            }

            _installer.ShowClose();
        }
    }
}
