using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Controls.Nodes {
	public class ReferenceNode : CecilNode<IMetadataScope, TreeNode> {

		public ReferenceNode(IMetadataScope reference) : base(reference) {
			this.Text = reference.Name;
			this.ImageIndex = Resources.Bitmaps.ModuleFile;

			if (reference is AssemblyNameReference) {
				this.ToolTipText = (reference as AssemblyNameReference).FullName;
				this.ImageIndex = Resources.Bitmaps.Reference;
			}
		}

	}
}
