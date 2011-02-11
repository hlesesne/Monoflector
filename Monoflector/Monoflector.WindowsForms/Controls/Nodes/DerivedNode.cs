using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Monoflector;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace Monoflector.Controls.Nodes {
	public class DerivedNode : CecilNode<TypeDefinition, TreeNode> {

		public DerivedNode(TypeDefinition type) : base(type) {
			this.Text = "Derived Types";
			this.ImageIndex = Resources.Bitmaps.DerivedType;
			this.Nodes.Add(String.Empty); // dummy node to allow for expanding.
		}

		public void OnBeforeExpand(AssemblyTree tree) {
			this.Nodes.Clear();

			List<AssemblyDefinition> assemblies = new List<AssemblyDefinition>();

			foreach (AssemblyNode node in tree.Nodes) {
				assemblies.Add(node.Reference);
			}

			List<TypeDefinition> list = this.Reference.FindDerivedTypes(assemblies);

			if (list.Count >= 0) {
				list = list.OrderBy(o => !o.IsInterface).ThenBy(o => o.Name).ToList();

				foreach (var type in list) {
					TypeNode node = new TypeNode(type, false, false, true);
					this.Nodes.Add(node);
				}
			}
		}
	}
}
