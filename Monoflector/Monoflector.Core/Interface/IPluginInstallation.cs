using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.PluginPackaging;
using System.ComponentModel.Composition;

namespace Monoflector.Interface
{
    /// <summary>
    /// Represents the plugin interface.
    /// </summary>
    [InheritedExport(typeof(IPluginInstallation))]
    public interface IPluginInstallation
    {
        /// <summary>
        /// Shows the confirmation prompt.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns>
        /// Whether the user accepted the prompt.
        /// </returns>
        bool ShowConfirmation(PluginPackage package);

        /// <summary>
        /// Shows the bootstrap interface.
        /// </summary>
        /// <returns>The bootstrap interface.</returns>
        bool ShowBootstrapInterface();

        /// <summary>
        /// Shows the interface.
        /// </summary>
        void ShowInterface();

        /// <summary>
        /// Waits for close.
        /// </summary>
        void WaitForClose();

        /// <summary>
        /// Shows the close.
        /// </summary>
        void ShowClose();
    }
}
