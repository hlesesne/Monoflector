using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.PluginPackaging;
using System.ComponentModel.Composition;

namespace Monoflector.Plugins
{
    public partial class ProgressDialog : Form, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Gets the plugin manager.
        /// </summary>
        [Import(typeof(IPluginManager))]
        public IPluginManager PluginManager
        {
            get;
            private set;
        }

        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            PluginManager.FileInstalling += PluginManager_FileInstalling;
        }

        void PluginManager_FileInstalling(object sender, ValueEventArgs<PluginProgress> e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler<ValueEventArgs<PluginProgress>>(PluginManager_FileInstalling), sender, e);
                return;
            }

            var newTitle = string.Format(Monoflector.Properties.Resources.InstallingTitle, e.Value.Component);
            if (Text != newTitle)
                Text = newTitle;

            if (_fileLabel.Text != e.Value.File)
                _fileLabel.Text = e.Value.File;

            if (e.Value.Progress == -1)
            {
                _progressBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                _progressBar.Style = ProgressBarStyle.Continuous;
                _progressBar.Value = e.Value.Progress;
            }
        }

        public void WaitForExit()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(WaitForExit));
                return;
            }
            Application.Run(this);
        }

        /// <summary>
        /// Shows the close.
        /// </summary>
        internal void ShowClose()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ShowClose));
                return;
            }
            Text = Monoflector.Properties.Resources.InstallationDone;
            _completePanel.Visible = _okButton.Enabled = true;
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
