using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Monoflector
{
    /// <summary>
    /// Represents a light-weight assembly.
    /// </summary>
    public interface ILightAssembly
    {
        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        Version Version
        {
            get;
        }

        /// <summary>
        /// Gets the origin.
        /// </summary>
        IAssemblyProvider Origin
        {
            get;
        }

        /// <summary>
        /// Loads the assembly.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns>The assembly.</returns>
        AssemblyDefinition Load();
    }
}
