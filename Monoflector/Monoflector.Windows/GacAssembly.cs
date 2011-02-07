using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Monoflector.Windows
{
    /// <summary>
    /// Represents a GAC assembly.
    /// </summary>
    public class GacAssembly : LightAssemblyBase
    {
        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>
        /// The name of the assembly.
        /// </value>
        public AssemblyName AssemblyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public override string Name
        {
            get
            {
                return AssemblyName.Name;
            }
        }

        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        public override Version Version
        {
            get
            {
                return AssemblyName.Version;
            }
        }

        /// <summary>
        /// Gets the cpu architecture.
        /// </summary>
        public override ProcessorArchitecture ProcessorArchitecture
        {
            get
            {
                return AssemblyName.ProcessorArchitecture;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GacAssembly"/> class.
        /// </summary>
        public GacAssembly(GacAssemblyProvider origin, AssemblyName assemblyName)
            : base(origin)
        {
            if (assemblyName == null)
                throw new ArgumentNullException("assemblyName");
            AssemblyName = assemblyName;
        }
    }
}
