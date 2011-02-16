using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.Runtime;
using System.IO;

namespace Monoflector.Bootstrap
{
    public partial class BootstrapConfirmation : Form
    {
        public BootstrapConfirmation()
        {
            InitializeComponent();
            if (Paths.IsPortableMode)
            {
                _portableModeCheckbox.Checked = true;
                _portableModeCheckbox.Enabled = false;
                _toolTip.SetToolTip(_portableModeCheckbox, "You cannot change this because the directory 'Portable' already exists.");
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (_portableModeCheckbox.Checked && _portableModeCheckbox.Enabled)
            {
                Directory.CreateDirectory(Path.Combine(Paths.Root, "Portable"));
                Paths.ReEvaluate();
            }
        }
    }
}
