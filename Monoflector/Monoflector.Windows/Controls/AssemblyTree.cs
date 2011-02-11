using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

using Monoflector.Windows.Controls;
using Monoflector.Windows.Controls.Nodes;

namespace Monoflector.Windows.Controls {
	public class AssemblyTree : TreeView {

		public delegate void DefinitionDoubleClickedHandler(object definition);
		public delegate void DefinitionSelectedHandler(object definition);

		public event DefinitionDoubleClickedHandler DefinitionDoubleClicked;
		public event DefinitionSelectedHandler DefinitionSelected;

		public AssemblyTree() : base() {
			// Enable default double buffering processing (DoubleBuffered returns true)
			SetStyle(ControlStyles.OptimizedDoubleBuffer |
			ControlStyles.AllPaintingInWmPaint, true);
			// Disable default CommCtrl painting on non-Vista systems
			if (Environment.OSVersion.Version.Major < 6) {
				SetStyle(ControlStyles.UserPaint, true);
			}

			this.BeforeExpand += delegate(object sender, TreeViewCancelEventArgs e) {
				if (e.Node is Nodes.DerivedNode) {
					(e.Node as Nodes.DerivedNode).OnBeforeExpand(this);
				}
			};
		}

		protected new TreeNodeCollection Nodes {
			get { return base.Nodes; }
		}

		public void AddAssembly(AssemblyDefinition assembly) {
			Nodes.AssemblyNode node = new Nodes.AssemblyNode(assembly);
			AddAssembly(node);
		}

		public void AddAssembly(Nodes.AssemblyNode node) {
			node.Collapse();
			this.Nodes.Add(node);
		}

		// silliness to reduce flicker
		public const int WM_PRINTCLIENT = 0x0318;
		public const int PRF_CLIENT = 0x00000004;
		protected override void OnPaint(PaintEventArgs e) {
			if (GetStyle(ControlStyles.UserPaint)) {
				Message m = new Message();
				m.HWnd = Handle;
				m.Msg = WM_PRINTCLIENT;
				m.WParam = e.Graphics.GetHdc();
				m.LParam = (IntPtr)PRF_CLIENT;
				DefWndProc(ref m);
				e.Graphics.ReleaseHdc(m.WParam);
			}
			base.OnPaint(e);
		}

		protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e) {

			// don't execute this while we're expanding/contracting;

			if (e.Node.Nodes.Count == 0 && DefinitionDoubleClicked != null) {
				var node = e.Node as AssemblyTreeNode;
				DefinitionDoubleClicked(node.Reference);
			}
			
			base.OnNodeMouseDoubleClick(e);
		}

		protected override void OnAfterSelect(TreeViewEventArgs e) {
			if (DefinitionSelected != null) {
				var node = e.Node as AssemblyTreeNode;
				DefinitionSelected(node.Reference);
			}

			base.OnAfterSelect(e);
		}
	}
}
