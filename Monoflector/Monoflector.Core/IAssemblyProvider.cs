using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Monoflector
{
    /// <summary>
    /// Represents an assembly provider.
    /// </summary>
    [InheritedExport(typeof(IAssemblyProvider))]
    public interface IAssemblyProvider
    {
        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Occurs when an assembly has been discovered.
        /// </summary>
        event EventHandler<ValueEventArgs<ILightAssembly>> AssemblyDiscovered;

        /// <summary>
        /// Occurs when an exception is thrown.
        /// </summary>
        event EventHandler<ValueEventArgs<Exception>> ExceptionThrown;

        /// <summary>
        /// Resets the provider and starts enumerating
        /// assemblies on a separate thread.
        /// </summary>
        void Start();

        /// <summary>
        /// Halts enumerating assemblies.
        /// </summary>
        void Stop();

        /// <summary>
        /// Loads an assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The assembly.</returns>
        AssemblyDefinition LoadAssembly(ILightAssembly assembly);
    }
}
