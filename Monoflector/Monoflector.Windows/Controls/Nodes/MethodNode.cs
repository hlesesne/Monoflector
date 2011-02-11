using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.Windows.Controls.Nodes {
	public class MethodNode : MemberNode {

		public MethodNode(MethodDefinition method) : base(method) {

			if (!method.IsPublic) {
				this.ForeColor = SystemColors.GrayText;
			}

			Type bitmapsType = method.HasOverrides || method.IsVirtual ? typeof(Resources.Bitmaps.MethodOverload) : typeof(Resources.Bitmaps.Method);

			this.ImageIndex = AssemblyTreeNode.GetIcon(method, bitmapsType);

			String signature = MemberNode.GenerateMethodSignature(method.Parameters);
			this.Text = String.Concat(method.Name, signature);

			if (method.ReturnType != null) {
				this.Text += String.Concat(" : ", method.ReturnType.Name);
			}

		}
	}
}
