using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using Monoflector.PluginPackaging;
using System.ComponentModel.Composition;

namespace Monoflector
{
    /// <summary>
    /// Represents the Windows Forms bootstrapper.
    /// </summary>
    [EnvironmentDependency("Windows")]
    [EnvironmentDependency("WindowsForms")]
    public class WindowsFormsBootstrapper : IMonoflectorBootstrapper
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
