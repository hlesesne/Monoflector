using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace System.ComponentModel.Composition
{
    /// <summary>
    /// Indicates that a code item is dependant on an environment.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    [MetadataAttribute]
    public class EnvironmentDependencyAttribute : PartMetadataAttribute, IEnvironmentMetadata
    {
        /// <summary>
        /// Gets the environment.
        /// </summary>
        public string Environment
        {
            get
            {
                return (string)base.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentDependencyAttribute"/> class.
        /// </summary>
        public EnvironmentDependencyAttribute(string environment)
            : base(MetadataKeys.Environment, environment)
        {
            if (string.IsNullOrEmpty(environment))
                throw new ArgumentNullException("environment");
        }
    }
}
