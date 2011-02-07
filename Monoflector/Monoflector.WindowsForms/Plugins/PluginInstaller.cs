using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Interface;
using Monoflector.PluginPackaging;
using System.Windows.Forms;

namespace Monoflector.Plugins
{
    /// <summary>
    /// Represents the plugin installer.
    /// </summary>
    class PluginInstaller : IPluginInstallation
    {
        private ProgressDialog _dialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginInstaller"/> class.
        /// </summary>
        public PluginInstaller()
        {
            WindowsInitialization.Initialize();
        }

        /// <summary>
        /// Shows the confirmation prompt.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns>
        /// Whether the user accepted the prompt.
        /// </returns>
        public bool ShowConfirmation(PluginPackage package)
        {
            using (var dialog = new ConfirmationDialog(package))
            {
                return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// Shows the bootstrap interface.
        /// </summary>
        /// <returns>
        /// The bootstrap interface.
        /// </returns>
        public bool ShowBootstrapInterface()
        {
            using (var dialog = new InstallationDialog())
            {
                return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// Shows the interface.
        /// </summary>
        public void ShowInterface()
        {
            _dialog = new ProgressDialog();
            _dialog.ComposeParts();
            _dialog.Show();
        }

        /// <summary>
        /// Waits for close.
        /// </summary>
        public void WaitForClose()
        {
            _dialog.WaitForExit();
        }

        /// <summary>
        /// Shows the close.
        /// </summary>
        public void ShowClose()
        {
            _dialog.ShowClose();
        }
    }
}
