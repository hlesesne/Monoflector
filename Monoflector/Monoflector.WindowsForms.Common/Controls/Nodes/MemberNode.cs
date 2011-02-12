using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;
using Mono.Collections.Generic;

namespace Monoflector.WindowsForms.Controls.Nodes {
	public class MemberNode : CecilNode<IMemberDefinition, AssemblyTreeNode> {

		public MemberNode(IMemberDefinition member) : base(member) {
			this.Text = member.Name;
			this.ToolTipText = member.FullName;
			this.ImageIndex = Resources.Bitmaps.Dummy;
		}

		public static String GenerateMethodSignature(Collection<ParameterDefinition> methodParams) {

			if (methodParams.Count == 0) {
				return "()";
			}

			List<String> parameters = new List<String>();

			foreach (var param in methodParams) {
				String name = param.ParameterType.Name;

				if (name.Contains("`")) {
					name = name.Substring(0, name.LastIndexOf("`"));
				}

				if (param.ParameterType.IsGenericInstance) {

					GenericInstanceType type = param.ParameterType as GenericInstanceType;
					String generic = String.Concat("<", String.Join(", ", type.GenericArguments.Select(o => o.Name).ToArray()), ">");
					name = String.Concat(name, generic);
				}

				parameters.Add(name);
			}
			
			return String.Concat("(", String.Join(", ", parameters.ToArray()), ")");
		}
	}
}
