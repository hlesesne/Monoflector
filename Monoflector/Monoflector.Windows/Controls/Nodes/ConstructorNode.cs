using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class ConstructorNode : MemberNode {

		public ConstructorNode(MethodDefinition method) : base(method) {

			if (!method.IsPublic) {
				this.ForeColor = SystemColors.GrayText;
			}

			this.ImageIndex = AssemblyTreeNode.GetIcon(method, typeof(Resources.Bitmaps.Constrcutor));

			String signature = MemberNode.GenerateMethodSignature(method.Parameters);
			this.Text = String.Concat(method.Name, signature);
		}
	}
}
