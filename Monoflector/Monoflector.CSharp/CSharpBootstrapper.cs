using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using Monoflector.PluginPackaging;
using System.ComponentModel.Composition;

namespace Monoflector.CSharp
{
    /// <summary>
    /// Represents the C# bootstrapper.
    /// </summary>
    public class CSharpBootstrapper : IMonoflectorBootstrapper
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
