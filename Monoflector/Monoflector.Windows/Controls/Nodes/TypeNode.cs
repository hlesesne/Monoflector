using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

using Monoflector.Windows.Resources;

namespace Monoflector.Windows.Controls.Nodes {
	public class TypeNode : CecilNode<TypeDefinition, MemberNode> {

		public TypeNode(TypeDefinition type) : this(type, true, true, false) {
			
		}

		public TypeNode(TypeDefinition type, Boolean traverseMembers) : this(type, traverseMembers, true, false) {

		}

		public TypeNode(TypeDefinition type, Boolean traverseMembers, Boolean resolveBaseType) : this(type, traverseMembers, resolveBaseType, false) {

		}

		public TypeNode(TypeDefinition type, Boolean traverseMembers, Boolean resolveBaseType, Boolean qualifyName) : base(type) {

			ParseName(qualifyName);
			this.ToolTipText = type.FullName;

			if (resolveBaseType) {
				AddBaseTypes(!traverseMembers);
			}

			if (traverseMembers) {
				AddDerivedTypes();
				AddMembers();
			}

			Type categoryType = null;

			if (!type.IsPublic) {
				this.ForeColor = SystemColors.GrayText;
			}

			if (type.IsInterface) {
				categoryType = typeof(Bitmaps.Interface);
			}
			else if (type.IsEnum) {
				categoryType = typeof(Bitmaps.Enum);
			}
			else if (type.IsClass && type.IsValueType) {
				categoryType = typeof(Bitmaps.Structure);
			}
			else if (type.IsClass) {
				categoryType = typeof(Bitmaps.Class);
			}

			if (categoryType == null) {
				this.ImageIndex = Resources.Bitmaps.Dummy;
				return;
			}

			this.ImageIndex = AssemblyTreeNode.GetIcon(type, categoryType);

		}

		private void ParseName(Boolean qualifyName) {
			TypeReference type = this.Reference;
			String name = qualifyName ? type.FullName : type.Name;

			if (name.Contains("`")) {
				name = name.Substring(0, name.LastIndexOf("`"));
			}

			if (type.HasGenericParameters) {
				String genericParams = GenerateGenericBlock(type.GenericParameters.Select(o => o.Name).ToList());
				name = String.Concat(name, genericParams);
			}

			this.Text = name;
		}

		private void AddMembers() {
			TypeDefinition type = this.Reference;

			foreach (var nestedType in type.NestedTypes.OrderBy(o => o.Name)) {
				TypeNode node = new TypeNode(nestedType);
				this.Nodes.Add(node);
			}

			foreach (var ctor in type.Methods.Where(o => o.IsConstructor).OrderBy(o => o.Name)) {
				ConstructorNode node = new ConstructorNode(ctor);
				this.Nodes.Add(node);
			}

			// weed out constructors, event add/removes, property getters/setters
			IEnumerable<MethodDefinition> methods = type.Methods.Where(o => !o.IsGetter && !o.IsSetter && !o.IsConstructor && !o.IsAddOn && !o.IsRemoveOn && !o.IsOther);

			foreach (var method in methods.OrderBy(o => o.Name)) {
				MethodNode node = new MethodNode(method);
				this.Nodes.Add(node);
			}

			foreach (var property in type.Properties.OrderBy(o => o.Name)) {
				PropertyNode node = new PropertyNode(property);
				this.Nodes.Add(node);
			}

			foreach (var evnt in type.Events.OrderBy(o => o.Name)) {
				EventNode node = new EventNode(evnt);
				this.Nodes.Add(node);
			}

			foreach (var field in type.Fields.OrderBy(o => o.Name)) {
				FieldNode node = new FieldNode(field);
				this.Nodes.Add(node);
			}

		}

		private void AddBaseTypes(Boolean baseTypesAsMembers) {
			TypeDefinition type = this.Reference;

			if (type.BaseType == null) {
				return;
			}

			TreeNode parentNode = this;

			if (!baseTypesAsMembers) {
				parentNode = new TreeNode("Base Types", Bitmaps.BaseType, Bitmaps.BaseType);
				this.Nodes.Add(parentNode);
			}

			parentNode.Nodes.Add(new TypeNode(type.BaseType.Resolve(), false, true, true));

			if (type.HasInterfaces) {
				foreach (var iface in type.Interfaces) {
					parentNode.Nodes.Add(new TypeNode(iface.Resolve(), false, true, true));
				}
			}

		}

		private void AddDerivedTypes() {
			this.Nodes.Add(new DerivedNode(this.Reference));
		}

		public static String GenerateGenericBlock(List<String> list) {
			return String.Concat("<", String.Join(", ", list.ToArray()), ">");
		}

	}
}
