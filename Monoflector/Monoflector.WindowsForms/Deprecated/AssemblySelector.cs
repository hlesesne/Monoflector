using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace Monoflector
{
    public partial class AssemblySelector : Form, IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(IAssemblyProvider))]
        private IEnumerable<IAssemblyProvider> _providers;
        private AssemblySet _assemblySet;

        public AssemblySelector()
        {
            InitializeComponent();
        }

        public AssemblySelector(AssemblySet assemblySet)
            : this()
        {
            _assemblySet = assemblySet;
            this.ComposeParts();
        }

        public void OnImportsSatisfied()
        {
            _providersTab.TabPages.Clear();
            foreach (var provider in _providers)
            {
                provider.Stop();
                var tab = new TabPage(provider.Name);
                var ctrl = new AssemblyProviderSelection(provider, _assemblySet);
                ctrl.Dock = DockStyle.Fill;
                ctrl.CloseRequested += new EventHandler(ctrl_CloseRequested);
                tab.Controls.Add(ctrl);
                
                _providersTab.TabPages.Add(tab);
            }
        }

        void ctrl_CloseRequested(object sender, EventArgs e)
        {
            Close();
        }
    }
}
