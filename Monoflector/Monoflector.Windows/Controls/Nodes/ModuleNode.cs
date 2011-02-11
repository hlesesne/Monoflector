using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class ModuleNode : CecilNode<ModuleDefinition, NamespaceNode> {

		private NamespaceNode _root;
		private ReferencesNode _references;

		public ModuleNode(ModuleDefinition module) : base(module) {
			_root = new NamespaceNode(String.Empty, module.Types.Where(o => o.Namespace == String.Empty));
			_root.Text = "-";
			_references = new ReferencesNode(module);

			this.Collapse();
			this.Text = module.Name;
			this.ImageIndex = this.SelectedImageIndex = Resources.Bitmaps.ModuleFile;
			this.Nodes.Add(_references);
			this.Nodes.Add(_root);

			IEnumerable<String> namespaces = module.Types.Where(o => !String.IsNullOrEmpty(o.Namespace)).Select(o => o.Namespace).Distinct();

			foreach (String namespce in namespaces.OrderBy(o => o)) {
				IEnumerable<TypeDefinition> types = module.Types.Where(o => o.Namespace == namespce);
				NamespaceNode node = new NamespaceNode(namespce, types);
				this.Nodes.Add(node);
			}
		}
	}
}
