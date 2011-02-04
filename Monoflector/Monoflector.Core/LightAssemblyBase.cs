using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector
{
    /// <summary>
    /// Represents a default implementation of <see cref="ILightAssembly"/>.
    /// </summary>
    public abstract class LightAssemblyBase : ILightAssembly
    {
        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        public abstract Version Version
        {
            get;
        }

        /// <summary>
        /// Gets the origin.
        /// </summary>
        public IAssemblyProvider Origin
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LightAssemblyBase"/> class.
        /// </summary>
        public LightAssemblyBase(IAssemblyProvider origin)
        {
            if (origin == null)
                throw new ArgumentNullException("origin");
            Origin = origin;
        }

        /// <summary>
        /// Loads the assembly.
        /// </summary>
        /// <returns>
        /// The assembly.
        /// </returns>
        public Mono.Cecil.AssemblyDefinition Load()
        {
            return Origin.LoadAssembly(this);
        }
    }
}
