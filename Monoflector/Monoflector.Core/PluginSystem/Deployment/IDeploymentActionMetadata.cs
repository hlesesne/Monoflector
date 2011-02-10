using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Represents metadata about a <see cref="IDeploymentAction"/>.
    /// </summary>
    public interface IDeploymentActionMetadata
    {
        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <value>
        /// The name of the element.
        /// </value>
        string ElementName
        {
            get;
        }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        string Namespace
        {
            get;
        }
    }
}
