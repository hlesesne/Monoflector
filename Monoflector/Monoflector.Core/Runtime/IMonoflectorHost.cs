using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector.Runtime
{
    /// <summary>
    /// Represents a Monoflector host.
    /// </summary>
    [InheritedExport(typeof(IMonoflectorHost))]
    public interface IMonoflectorHost
    {
        /// <summary>
        /// Sets a value indicating whether this <see cref="IMonoflectorHost"/> is bootstrapping.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if bootstrapping; otherwise, <see langword="false"/>.
        /// </value>
        bool Bootstrapping
        {
            set;
        }

        /// <summary>
        /// Sets a value indicating whether to install plugins that were passed through in the arguments.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if plugins should be installed; otherwise, <see langword="false"/>.
        /// </value>
        bool InstallPlugins
        {
            set;
        }

        /// <summary>
        /// Runs the monoflector host.
        /// </summary>
        void Run(string[] commandlineArguments);
    }
}
