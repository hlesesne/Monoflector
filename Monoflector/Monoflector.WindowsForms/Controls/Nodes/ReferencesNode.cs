using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Controls.Nodes {
	public class ReferencesNode : CecilNode<ModuleDefinition, ReferenceNode> {

		public ReferencesNode(ModuleDefinition module) : base(module) {
			this.Text = "References";
			this.ImageIndex = this.SelectedImageIndex = Resources.Bitmaps.References;

			foreach (AssemblyNameReference reference in module.AssemblyReferences.OrderBy(o => o.Name)) {
				ReferenceNode node = new ReferenceNode(reference);
				this.AddNode(node);
			}

			foreach (ModuleReference reference in module.ModuleReferences.OrderBy(o => o.Name)) {
				ReferenceNode node = new ReferenceNode(reference);
				this.AddNode(node);
			}

		}

	}
}
