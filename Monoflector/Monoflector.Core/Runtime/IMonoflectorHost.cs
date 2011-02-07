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
        /// Runs the monoflector host.
        /// </summary>
        void Run(string[] commandlineArguments);
    }
}
