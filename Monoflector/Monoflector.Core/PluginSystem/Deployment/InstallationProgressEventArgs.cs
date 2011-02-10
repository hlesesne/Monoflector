using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Represents event arguments indicating installation progress.
    /// </summary>
    public class InstallationProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether this installation is complete.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if this installation is complete; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsComplete
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// The name of the plugin.
        /// </value>
        public string PluginName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the percentage.
        /// </summary>
        public int Percentage
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallationProgressEventArgs"/> class.
        /// </summary>
        public InstallationProgressEventArgs()
        {
            IsComplete = true;
            Percentage = 100;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallationProgressEventArgs"/> class.
        /// </summary>
        public InstallationProgressEventArgs(string plugin, int percentage)
        {
            PluginName = plugin;
            Percentage = percentage;
        }
    }
}
