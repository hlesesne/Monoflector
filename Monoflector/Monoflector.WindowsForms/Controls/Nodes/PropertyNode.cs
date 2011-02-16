using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.WindowsForms.Controls.Nodes {
	public class PropertyNode : MemberNode {

		public PropertyNode(PropertyDefinition property) : base(property) {

			MethodDefinition checkMethod = property.GetMethod != null ? property.GetMethod : property.SetMethod;

			if (!checkMethod.IsPublic) {
				this.ForeColor = SystemColors.GrayText;
			}

			this.ImageIndex = AssemblyTreeNode.GetIcon(property, typeof(Resources.Bitmaps.Property));

			this.Text = String.Concat(property.Name, " : ", property.PropertyType.Name);

			if (property.GetMethod != null) {
				MethodNode node = new MethodNode(property.GetMethod);
				this.Nodes.Add(node);
			}

			if (property.SetMethod != null) {
				MethodNode node = new MethodNode(property.SetMethod);
				this.Nodes.Add(node);
			}

			if (property.HasOtherMethods) {
				foreach (var method in property.OtherMethods.OrderBy(o => o.Name)) {
					MethodNode node = new MethodNode(method);
					this.Nodes.Add(node);
				}
			}

		}
	}
}
