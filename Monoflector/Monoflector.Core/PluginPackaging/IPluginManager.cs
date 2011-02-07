using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector.PluginPackaging
{
    /// <summary>
    /// Represents the plugin manager.
    /// </summary>
    [InheritedExport(typeof(IPluginManager))]
    public interface IPluginManager
    {
        /// <summary>
        /// Occurs when a file is installing.
        /// </summary>
        event EventHandler<ValueEventArgs<PluginProgress>> FileInstalling;

        /// <summary>
        /// Installs the specified file.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="file">The file.</param>
        /// <param name="progress">The progress.</param>
        void Install(string component, string file, int progress);

        /// <summary>
        /// Updates indicating that a file installation is in progress.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="file">The file.</param>
        /// <param name="progress">The progress.</param>
        void Update(string component, string file, int progress);

        /// <summary>
        /// Installs the calling assembly.
        /// </summary>
        void InstallCaller();
    }
}
