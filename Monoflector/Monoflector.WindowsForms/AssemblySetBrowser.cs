using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.Interface;
using System.ComponentModel.Composition;
using Cecil.Decompiler.Ast;
using Monoflector.Languages;

namespace Monoflector
{
    public partial class AssemblySetBrowser : UserControl, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Occurs when the assemblies need to be updated.
        /// </summary>
        public event EventHandler UpdateAssemblies;

        private AssemblySet _assemblySet;
        /// <summary>
        /// Gets the assembly set.
        /// </summary>
        public AssemblySet AssemblySet
        {
            get
            {
                return _assemblySet;
            }
        }

        [ImportMany(typeof(IAstPresenter))]
        private IEnumerable<ExportFactory<IAstPresenter>> _presenterFactories;
        private IAstPresenter[] _presenters;

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
            this.ComposeParts();
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

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            _presenters = _presenterFactories.Select(x => x.CreateExport().Value).ToArray();

            _presentersTabControl.TabPages.Clear();
            foreach (var presenter in _presenters)
            {
                var control = presenter as Control;
                if (control != null)
                {
                    if (control.Parent != null)
                        control.Parent.Controls.Remove(control);

                    var page = new TabPage(presenter.DisplayName);
                    control.Dock = DockStyle.Fill;
                    page.Controls.Add(control);

                    _presentersTabControl.TabPages.Add(page);
                }
            }
        }

        public void Present(DecompilationTarget codeNode)
        {
            foreach (var presenter in _presenters)
                presenter.Present(codeNode);
        }
    }
}
