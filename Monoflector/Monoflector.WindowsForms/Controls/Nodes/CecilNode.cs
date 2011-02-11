using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Mono.Cecil;

using Monoflector.Resources;

namespace Monoflector.Controls.Nodes {
	public class CecilNode<TReference, TNode> : TreeNode where TNode : TreeNode {

		public CecilNode(TReference reference) {
			this.Reference = reference;
		}

		public TReference Reference { get; private set; }

		protected new TreeNodeCollection Nodes {
			get { return base.Nodes; }
		}

		public void AddNode(TNode node) {
			this.Nodes.Add(node);
		}

		protected new int ImageIndex {
			get {
				return base.ImageIndex;
			}
			set {
				base.ImageIndex = this.SelectedImageIndex = value;
			}
		}

		public static int GetIcon(TypeDefinition type, Type categoryType) {

			Bitmaps.CategoryMember which = Bitmaps.CategoryMember.Default;

			if (type.IsSealed) {
				which = Bitmaps.CategoryMember.Sealed;
			}
			else if (type.IsNotPublic || type.IsNestedPrivate) {
				which = Bitmaps.CategoryMember.Private;
			}
			else if (type.IsNestedAssembly) {
				which = Bitmaps.CategoryMember.Internal;
			}
			else if (type.IsNestedFamily || type.IsNestedFamilyAndAssembly || (type.IsNestedFamilyOrAssembly && type.IsNestedFamily)) {
				which = Bitmaps.CategoryMember.Protected;
			}

			FieldInfo field = categoryType.GetField(which.ToString(), BindingFlags.Public | BindingFlags.Static);

			return Convert.ToInt32(field.GetValue(null));

		}

		public static int GetIcon(MethodDefinition method, Type categoryType) {

			Bitmaps.CategoryMember which = method.IsStatic ? 
				Bitmaps.CategoryMember.Static : 
				Bitmaps.CategoryMember.Default;

			if (method.IsPrivate) {
				which = method.IsStatic ? Bitmaps.CategoryMember.StaticPrivate : Bitmaps.CategoryMember.Private;
			}
			else if (method.IsAssembly) {
				which = method.IsStatic ? Bitmaps.CategoryMember.StaticInternal : Bitmaps.CategoryMember.Internal;
			}
			else if (method.IsFamily || method.IsFamilyAndAssembly || (method.IsFamilyOrAssembly && method.IsFamily)) {
				which = method.IsStatic ? Bitmaps.CategoryMember.StaticProtected : Bitmaps.CategoryMember.Protected;
			}
			
			FieldInfo field = categoryType.GetField(which.ToString(), BindingFlags.Public | BindingFlags.Static);

			return Convert.ToInt32(field.GetValue(null));

		}

		public static int GetIcon(PropertyDefinition property, Type categoryType) {

			MethodDefinition checkMethod = property.GetMethod != null ? property.GetMethod : property.SetMethod;

			Bitmaps.CategoryMember which = checkMethod.IsStatic ?
				Bitmaps.CategoryMember.Static :
				Bitmaps.CategoryMember.Default;

			if (checkMethod.IsPrivate) {
				which = checkMethod.IsStatic ? Bitmaps.CategoryMember.StaticPrivate : Bitmaps.CategoryMember.Private;
			}
			else if (checkMethod.IsAssembly) {
				which = checkMethod.IsStatic ? Bitmaps.CategoryMember.StaticInternal : Bitmaps.CategoryMember.Internal;
			}
			else if (checkMethod.IsFamily || checkMethod.IsFamilyAndAssembly || (checkMethod.IsFamilyOrAssembly && checkMethod.IsFamily)) {
				which = checkMethod.IsStatic ? Bitmaps.CategoryMember.StaticProtected : Bitmaps.CategoryMember.Protected;
			}

			FieldInfo field = categoryType.GetField(which.ToString(), BindingFlags.Public | BindingFlags.Static);

			return Convert.ToInt32(field.GetValue(null));

		}

		public static int GetIcon(FieldDefinition field, Type categoryType) {

			Bitmaps.CategoryMember which = field.IsStatic ?
				Bitmaps.CategoryMember.Static :
				Bitmaps.CategoryMember.Default;

			if (field.IsPrivate) {
				which = field.IsStatic ? Bitmaps.CategoryMember.StaticPrivate : Bitmaps.CategoryMember.Private;
			}
			else if (field.IsAssembly) {
				which = field.IsStatic ? Bitmaps.CategoryMember.StaticInternal : Bitmaps.CategoryMember.Internal;
			}
			else if (field.IsFamily || field.IsFamilyAndAssembly || (field.IsFamilyOrAssembly && field.IsFamily)) {
				which = field.IsStatic ? Bitmaps.CategoryMember.StaticProtected : Bitmaps.CategoryMember.Protected;
			}

			FieldInfo fieldInfo = categoryType.GetField(which.ToString(), BindingFlags.Public | BindingFlags.Static);

			return Convert.ToInt32(fieldInfo.GetValue(null));

		}

	}
}
