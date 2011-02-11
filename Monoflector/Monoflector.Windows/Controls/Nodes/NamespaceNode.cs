using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class NamespaceNode : CecilNode<IEnumerable<TypeReference>, TypeNode> {

		public NamespaceNode(String name, IEnumerable<TypeReference> types) : base(types) {
			this.Text = name;
			this.ImageIndex = this.SelectedImageIndex = Resources.Bitmaps.Namespace;

			foreach (TypeDefinition type in types.OrderBy(o => o.Name)) {
				TypeNode node = new TypeNode(type);
				this.Nodes.Add(node);
			}

		}

	}
}
