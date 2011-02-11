using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class AssemblyNode : CecilNode<AssemblyDefinition, ModuleNode> {

		public AssemblyNode(AssemblyDefinition assembly) : base(assembly) {
			this.Text = assembly.Name.Name;
			this.ToolTipText = assembly.FullName;
			this.ImageIndex = this.SelectedImageIndex = Resources.Bitmaps.Assembly;

			foreach (ModuleDefinition module in assembly.Modules) {
				ModuleNode moduleNode = new ModuleNode(module);
				this.Nodes.Add(moduleNode);
			}
		}

	}
}
