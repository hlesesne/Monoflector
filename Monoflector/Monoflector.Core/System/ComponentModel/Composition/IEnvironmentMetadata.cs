using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
    /// <summary>
    /// Represents information about an environment.
    /// </summary>
    public interface IEnvironmentMetadata
    {
        /// <summary>
        /// Gets the environment.
        /// </summary>
        string Environment
        {
            get;
        }
    }
}
