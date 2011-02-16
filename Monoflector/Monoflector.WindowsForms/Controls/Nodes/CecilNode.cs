using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

using Monoflector.WindowsForms.Resources;

namespace Monoflector.WindowsForms.Controls.Nodes {
	public class CecilNode<TReference, TNode> : AssemblyTreeNode where TNode : AssemblyTreeNode {

		public CecilNode(TReference reference) : base(reference) {

		}

		public new TReference Reference {
			get { return (TReference)Convert.ChangeType(base.Reference, typeof(TReference)); }
			private set {
				base.Reference = value;
			}
		}

		protected new TreeNodeCollection Nodes {
			get { return base.Nodes; }
		}

		public void AddNode(TNode node) {
			this.Nodes.Add(node);
		}

		protected new int ImageIndex {
			get {
				return base.ImageIndex;
			}
			set {
				base.ImageIndex = this.SelectedImageIndex = value;
			}
		}

	}
}
