using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.PluginPackaging;
using System.IO;

namespace Monoflector.Plugins
{
    public partial class ConfirmationDialog : Form
    {
        private PluginPackage _package;
        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        public ConfirmationDialog(PluginPackage package)
        {
            InitializeComponent();
            _package = package;
            InitializePackage();
        }

        private void InitializePackage()
        {
            this.Text = string.Format("Install {0} ({1})", _package.Title, _package.Author);
            _contentBrowser.Navigate(Path.Combine(_package.InstallDocPath, "index.htm"));
        }
    }
}
