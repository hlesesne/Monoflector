using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using System.ComponentModel.Composition;
using Monoflector.PluginPackaging;

namespace Monoflector.Windows
{
    /// <summary>
    /// Represents the Windows bootstrapper.
    /// </summary>
    [EnvironmentDependency("Windows")]
    public class WindowsBootstrapper : IMonoflectorBootstrapper
    {
        /// <summary>
        /// Gets the plugin manager.
        /// </summary>
        [Import(typeof(IPluginManager))]
        public IPluginManager PluginManager
        {
            get;
            private set;
        }

        /// <summary>
        /// Installs the bootstrappable item.
        /// </summary>
        public void Install()
        {
            PluginManager.InstallCaller();
        }
    }
}
