using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector
{
    public partial class AssemblySetNameForm : Form
    {
        public string SelectedName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public AssemblySetNameForm()
        {
            InitializeComponent();
        }

        private void _nameTextBox_TextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = !string.IsNullOrEmpty(_nameTextBox.Text);
        }
    }
}
