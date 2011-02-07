using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.PluginPackaging
{
    /// <summary>
    /// Represents the progress of installing a plugin.
    /// </summary>
    public class PluginProgress
    {
        /// <summary>
        /// Gets the component.
        /// </summary>
        public string Component
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        public string File
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the progress.
        /// </summary>
        public int Progress
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginProgress"/> class.
        /// </summary>
        public PluginProgress(string component, string file, int progress)
        {
            Component = component;
            File = file;
            Progress = progress;
        }
    }
}
