using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mono.Cecil;
using Cecil.Decompiler.Languages;

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

        private void newSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var name = new AssemblySetNameForm())
            {
                if (name.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var set = new AssemblySet();
                    set.Name = name.SelectedName;
                    _assemblySets.Add(set);
                    RefreshSets(); 
                }
            }
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
                _previousBrowser = ctrl;
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
                node.Tag = asm.Load();
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                _nodesTreeView.Nodes.Add(node);
            }
        }

        private void Populate(TreeNode treeNode, object tag)
        {
            if (tag is AssemblyDefinition)
            {
                Populate(treeNode, (AssemblyDefinition)tag);
            }
            else if (tag is ModuleDefinition)
            {
                Populate(treeNode, (ModuleDefinition)tag);
            }
            else if (tag is TypeDefinition)
            {
                Populate(treeNode, (TypeDefinition)tag);
            }
        }

        private void Populate(TreeNode treeNode, AssemblyDefinition tag)
        {
            foreach (var module in tag.Modules)
            {
                var node = new TreeNode(module.Name);
                node.Tag = module;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
        }

        private void Populate(TreeNode treeNode, ModuleDefinition tag)
        {
            if (treeNode.Parent.Tag is AssemblyDefinition) // Namespace
            {
                var namespaces = new HashSet<string>();
                foreach (var type in tag.Types)
                {
                    if (!string.IsNullOrEmpty(type.Namespace) &&
                        namespaces.Add(type.Namespace))
                    {
                        var node = new TreeNode(type.Namespace);
                        node.Tag = tag;
                        node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                        node.Collapse();
                        treeNode.Nodes.Add(node);
                    }
                    else
                    {
                        var node = new TreeNode(type.Name);
                        node.Tag = type;
                        node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                        node.Collapse();
                        treeNode.Nodes.Add(node);
                    }
                }
            }
            else // Type within namespace.
            {
                foreach (var type in tag.Types.Where(x => x.Namespace == treeNode.Text))
                {
                    var node = new TreeNode(type.Name);
                    node.Tag = type;
                    node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                    node.Collapse();
                    treeNode.Nodes.Add(node);
                }
            }
        }
        
        private void Populate(TreeNode treeNode, TypeDefinition tag)
        {
            foreach (var evt in tag.Events.Where(x => !x.IsSpecialName))
            {
                var node = new TreeNode(evt.Name);
                node.Tag = evt;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
            foreach (var property in tag.Properties.Where(x => !x.IsSpecialName))
            {
                var node = new TreeNode(property.Name);
                node.Tag = property;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
            foreach (var field in tag.Fields.Where(x => !x.IsSpecialName))
            {
                var node = new TreeNode(field.Name);
                node.Tag = field;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
            foreach (var field in tag.Methods.Where(x => !x.IsSpecialName))
            {
                var node = new TreeNode(field.Name);
                node.Tag = field;
                node.Nodes.Add(new TreeNode()); // Placeholder node for async expanding.
                node.Collapse();
                treeNode.Nodes.Add(node);
            }
        }

        private void _nodesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && _previousBrowser != null)
            {
                if (e.Node.Tag is MethodDefinition)
                {
                    var def = (MethodDefinition)e.Node.Tag;
                    var target = ApplicationContext.Instance.SelectedLanguage.CreateDecompilationTarget();
                    try
                    {
                        ((ILanguageWriter)target).Write(def);
                    }
                    catch
                    {
                    }
                    _previousBrowser.Present(target);
                }
            }
        }
    }
}
