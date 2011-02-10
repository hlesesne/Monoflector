using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel.Composition;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Represents a deployment action.
    /// </summary>
    [InheritedExport(typeof(IDeploymentAction))]
    public interface IDeploymentAction
    {
        /// <summary>
        /// Performs a deployment.
        /// </summary>
        /// <param name="context">The deployment context.</param>
        void Deploy(DeploymentContext context);
    }
}
