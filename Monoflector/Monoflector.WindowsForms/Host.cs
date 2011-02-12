using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Monoflector.PluginSystem.Deployment;
using System.IO;

namespace Monoflector
{
    /// <summary>
    /// Represents the Monoflector Windows Forms host.
    /// </summary>
    [EnvironmentDependency("Windows")]
    [EnvironmentDependency("WindowsForms")]
    public class Host : IMonoflectorHost
    {
        /// <summary>
        /// Runs the monoflector host.
        /// </summary>
        /// <param name="commandlineArguments">The command line arguments.</param>
        public void Run(string[] commandlineArguments)
        {
            WindowsInitialization.Initialize();

            if (Bootstrapping)
            {
                ApplicationContext.Instance.Initialize();
                using (var frm = new Bootstrap.BootstrapConfirmation())
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                        return;
                }
                var installer = PluginInstaller.CreateBootstrap();
                using (var frm = new Bootstrap.PluginSelection(installer))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                ApplicationContext.Instance.Initialize();
                var plugins = new HashSet<string>(commandlineArguments.Where(x => Path.GetExtension(x) == ".mfplug"));
                var assemblies = new HashSet<string>(commandlineArguments.Where(x => Path.GetExtension(x) != ".mfplug"));
                if (plugins.Count > 0 && InstallPlugins)
                {
                    var installer = new PluginInstaller(plugins);
                    using (var frm = new Bootstrap.PluginSelection(installer))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    using (var frm = new WindowsForms.Forms.Main())
                    {
                        // TODO: Open assemblies.
                        Application.Run(frm);
                    }
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether this <see cref="IMonoflectorHost"/> is bootstrapping.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if bootstrapping; otherwise, <see langword="false"/>.
        /// </value>
        public bool Bootstrapping
        {
            get;
            set;
        }
        /// <summary>
        /// Sets a value indicating whether to install plugins that were passed through in the arguments.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if plugins should be installed; otherwise, <see langword="false"/>.
        /// </value>
        public bool InstallPlugins
        {
            get;
            set;
        }
    }
}
