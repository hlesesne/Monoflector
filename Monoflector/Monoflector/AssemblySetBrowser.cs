using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector
{
    public partial class AssemblySetBrowser : UserControl
    {
        /// <summary>
        /// Occurs when the assemblies need to be updated.
        /// </summary>
        public event EventHandler UpdateAssemblies;

        private AssemblySet _assemblySet;
        public AssemblySet AssemblySet
        {
            get
            {
                return _assemblySet;
            }
        }

        public AssemblySetBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySetBrowser"/> class.
        /// </summary>
        public AssemblySetBrowser(AssemblySet set)
            : this()
        {
            _assemblySet = set;
        }

        private void _assembliesToolStripButton_Click(object sender, EventArgs e)
        {
            using(var selector = new AssemblySelector(_assemblySet))
            {
                selector.ShowDialog();
            }
            var tmp = UpdateAssemblies;
            if (tmp != null)
                tmp(this, EventArgs.Empty);
        }
    }
}
