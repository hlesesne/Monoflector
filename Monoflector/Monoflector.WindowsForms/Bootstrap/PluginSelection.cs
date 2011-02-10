using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.PluginSystem.Deployment;
using System.IO;
using System.Threading;

namespace Monoflector.Bootstrap
{
    public partial class PluginSelection : Form
    {
        private PluginInstaller _installer;

        public PluginSelection()
        {
            InitializeComponent();
        }

        public PluginSelection(PluginInstaller installer)
            : this()
        {
            _installer = installer;
            CreateItems();
        }

        private void CreateItems()
        {
            foreach (var plugin in _installer)
            {
                var item = new ListViewItem((string)plugin.PluginDefinition.Title.Localize());
                item.Tag = plugin;
                item.Checked = _installer[plugin];
                _pluginsListView.Items.Add(item);
            }
            _installButton.Enabled = _pluginsListView.CheckedItems.Count > 0;
            if (_pluginsListView.Items.Count > 0)
                _pluginsListView.Items[0].Selected = true;
        }

        private void _pluginsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _installButton.Enabled = _pluginsListView.CheckedItems.Count > 0;
            _installer[(DeploymentContext)e.Item.Tag] = e.Item.Checked;
        }

        private void _installButton_Click(object sender, EventArgs e)
        {
            Height = 127;
            _installer.InstallationProgress += _installer_InstallationProgress;
            _installationPanel.Visible = true;
            _installer.Install();
        }

        void _installer_InstallationProgress(object sender, InstallationProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                if (e.IsComplete)
                    Thread.Sleep(500);
                this.Invoke(new EventHandler<InstallationProgressEventArgs>(_installer_InstallationProgress), sender, e);
                return;
            }
            _progressBar.Value = e.Percentage;
            _pluginLabel.Text = e.PluginName;
            if (e.IsComplete)
                this.Close();
        }

        private void _pluginsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _webBrowser.Navigate("about:blank");
            if(_pluginsListView.SelectedItems.Count == 0)
            {
                return;
            }
            var item = _pluginsListView.SelectedItems[0];
            var plug = item.Tag as DeploymentContext;
            var path = (string)plug.PluginDefinition.InstallationDocumentation.Localize();
            if (!string.IsNullOrEmpty(path))
            {
                path = plug.ExtractDirectory(path);
                _webBrowser.Navigate(Path.Combine(path, "index.htm"));
            }
        }
    }
}
