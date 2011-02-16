using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

namespace Monoflector.WindowsForms.Controls.Nodes {
	public class ConstantNode : MemberNode {

		public ConstantNode(FieldDefinition field) : base(field) {

			if (!field.IsPublic) {
				this.ForeColor = SystemColors.GrayText;
			}
			
			this.ImageIndex = AssemblyTreeNode.GetIcon(field, typeof(Resources.Bitmaps.Constant));
			this.Text = String.Concat(field.Name, " : ", field.FieldType.Name);

		}
	}
}
