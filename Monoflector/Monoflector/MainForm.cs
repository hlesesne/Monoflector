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
    public partial class MainForm : Form
    {
        private List<AssemblySet> _assemblySets
            = new List<AssemblySet>();
        private AssemblySetBrowser _previousBrowser;

        public MainForm()
        {
            InitializeComponent();

            var set = new AssemblySet();
            set.Name = ".Net v4.0";
            _assemblySets.Add(set);
            RefreshSets();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void RefreshSets()
        {
            _setsTabControl.TabPages.Clear();
            foreach (var set in _assemblySets)
            {
                var page = new TabPage(set.Name);
                page.Tag = set;

                var ctrl = new AssemblySetBrowser(set);
                ctrl.Dock = DockStyle.Fill;
                page.Controls.Add(ctrl);
                _setsTabControl.TabPages.Add(page);
            }

            if (_setsTabControl.TabCount != 0)
            {
                _setsTabControl_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        private void _setsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nodesTreeView.Nodes.Clear();
            if (_previousBrowser != null)
            {
                _previousBrowser.UpdateAssemblies -= Browser_UpdateAssemblies;
                _previousBrowser = null;
            }

            var selectedItem = _setsTabControl.SelectedTab;
            if (selectedItem != null)
            {
                var ctrl = (AssemblySetBrowser)selectedItem.Controls[0];
                ctrl.UpdateAssemblies += Browser_UpdateAssemblies;
                Browser_UpdateAssemblies(ctrl, EventArgs.Empty);
            }
            
        }

        void Browser_UpdateAssemblies(object sender, EventArgs e)
        {
            var browser = (AssemblySetBrowser)sender;
            Populate(browser.AssemblySet);
        }

        private void _nodesTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                var tag = e.Node.Tag;
                Populate(e.Node, tag);
                e.Node.Nodes.RemoveAt(0);
                if (e.Node.Nodes.Count == 0)
                    e.Cancel = true;
            }
        }

        private void Populate(AssemblySet set)
        {
            _nodesTreeView.Nodes.Clear();
            foreach (var asm in set)
            {
                var node = new TreeNode(asm.Name);
                node.Tag = asm;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                _nodesTreeView.Nodes.Add(node);
            }
        }

        private void Populate(TreeNode treeNode, object tag)
        {
            if (tag is ILightAssembly)
            {
                Populate(treeNode, (ILightAssembly)tag);
            }
        }


        private void Populate(TreeNode treeNode, ILightAssembly tag)
        {
            var assembly = tag.Load();
            treeNode.Tag = assembly;
            foreach (var module in assembly.Modules)
            {
                var node = new TreeNode(module.Name);
                node.Tag = module;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
        }
    }
}
