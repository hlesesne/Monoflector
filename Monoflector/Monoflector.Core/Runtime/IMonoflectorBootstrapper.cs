using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector.Runtime
{
    /// <summary>
    /// Represents the Monoflector bootstrapper.
    /// </summary>
    [InheritedExport(typeof(IMonoflectorBootstrapper))]
    public interface IMonoflectorBootstrapper
    {
        /// <summary>
        /// Installs the bootstrappable item.
        /// </summary>
        void Install();
    }
}
