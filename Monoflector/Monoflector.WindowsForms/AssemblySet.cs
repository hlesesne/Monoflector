using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Monoflector
{
    /// <summary>
    /// Represents an assembly set.
    /// </summary>
    public class AssemblySet : HashSet<ILightAssembly>
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySet"/> class.
        /// </summary>
        public AssemblySet()
            : base(LightAssemblyComparer.Instance)
        {
            
        }

        /// <summary>
        /// Gets the assembly definitions in the set.
        /// </summary>
        /// <returns>The assembly definitions.</returns>
        public IEnumerable<AssemblyDefinition> GetAssemblies()
        {
            return this.Select(x => x.Load());
        }
    }
}
