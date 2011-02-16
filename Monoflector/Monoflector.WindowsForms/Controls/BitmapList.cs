using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector.WindowsForms.Controls {

	[Designer("System.Windows.Forms.Design.ImageListDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public class BitmapList : UserControl {
		private ImageList _List;
		private IContainer components;

		public BitmapList() {
			InitializeComponent();
			InitImages();
		}

		public ImageList ImageList {
			get { return this._List; }
		}

		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this._List = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// _List
			// 
			this._List.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this._List.ImageSize = new System.Drawing.Size(16, 16);
			this._List.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// BitmapList
			// 
			this.Name = "BitmapList";
			this.ResumeLayout(false);

		}

		private void InitImages() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monoflector.Resources.BitmapList));

			this._List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageStream")));
			this._List.Images.SetKeyName(0, "VSObject_Assembly.bmp");
			this._List.Images.SetKeyName(1, "VSObject_Class.bmp");
			this._List.Images.SetKeyName(2, "VSObject_Class_Friend.bmp");
			this._List.Images.SetKeyName(3, "VSObject_Class_Private.bmp");
			this._List.Images.SetKeyName(4, "VSObject_Class_Protected.bmp");
			this._List.Images.SetKeyName(5, "VSObject_Class_Sealed.bmp");
			this._List.Images.SetKeyName(6, "VSObject_Constant.bmp");
			this._List.Images.SetKeyName(7, "VSObject_Constant_Friend.bmp");
			this._List.Images.SetKeyName(8, "VSObject_Constant_Private.bmp");
			this._List.Images.SetKeyName(9, "VSObject_Constant_Protected.bmp");
			this._List.Images.SetKeyName(10, "VSObject_Constant_Sealed.bmp");
			this._List.Images.SetKeyName(11, "VSObject_Constructor.bmp");
			this._List.Images.SetKeyName(12, "VSObject_Constructor_Friend.bmp");
			this._List.Images.SetKeyName(13, "VSObject_Constructor_Private.bmp");
			this._List.Images.SetKeyName(14, "VSObject_Constructor_Protected.bmp");
			this._List.Images.SetKeyName(15, "VSObject_Constructor_Sealed.bmp");
			this._List.Images.SetKeyName(16, "VSObject_Constructor_Static.bmp");
			this._List.Images.SetKeyName(17, "VSObject_Constructor_Static_Friend.bmp");
			this._List.Images.SetKeyName(18, "VSObject_Constructor_Static_Private.bmp");
			this._List.Images.SetKeyName(19, "VSObject_Constructor_Static_Protected.bmp");
			this._List.Images.SetKeyName(20, "VSObject_Constructor_Static_Sealed.bmp");
			this._List.Images.SetKeyName(21, "VSObject_Delegate.bmp");
			this._List.Images.SetKeyName(22, "VSObject_Delegate_Friend.bmp");
			this._List.Images.SetKeyName(23, "VSObject_Delegate_Private.bmp");
			this._List.Images.SetKeyName(24, "VSObject_Delegate_Protected.bmp");
			this._List.Images.SetKeyName(25, "VSObject_Delegate_Sealed.bmp");
			this._List.Images.SetKeyName(26, "VSObject_Dummy.bmp");
			this._List.Images.SetKeyName(27, "VSObject_Enum.bmp");
			this._List.Images.SetKeyName(28, "VSObject_Enum_Friend.bmp");
			this._List.Images.SetKeyName(29, "VSObject_Enum_Protected.bmp");
			this._List.Images.SetKeyName(30, "VSObject_Enum_Sealed.bmp");
			this._List.Images.SetKeyName(31, "VSObject_EnumItem.bmp");
			this._List.Images.SetKeyName(32, "VSObject_EnumItem_Friend.bmp");
			this._List.Images.SetKeyName(33, "VSObject_EnumItem_Private.bmp");
			this._List.Images.SetKeyName(34, "VSObject_EnumItem_Protected.bmp");
			this._List.Images.SetKeyName(35, "VSObject_EnumItem_Sealed.bmp");
			this._List.Images.SetKeyName(36, "VSObject_EnumPrivate.bmp");
			this._List.Images.SetKeyName(37, "VSObject_Event.bmp");
			this._List.Images.SetKeyName(38, "VSObject_Event_Friend.bmp");
			this._List.Images.SetKeyName(39, "VSObject_Event_Private.bmp");
			this._List.Images.SetKeyName(40, "VSObject_Event_Protected.bmp");
			this._List.Images.SetKeyName(41, "VSObject_Event_Sealed.bmp");
			this._List.Images.SetKeyName(42, "VSObject_Event_Static.bmp");
			this._List.Images.SetKeyName(43, "VSObject_Event_Static_Friend.bmp");
			this._List.Images.SetKeyName(44, "VSObject_Event_Static_Private.bmp");
			this._List.Images.SetKeyName(45, "VSObject_Event_Static_Protected.bmp");
			this._List.Images.SetKeyName(46, "VSObject_Event_Static_Sealed.bmp");
			this._List.Images.SetKeyName(47, "VSObject_Exception.bmp");
			this._List.Images.SetKeyName(48, "VSObject_Exception_Friend.bmp");
			this._List.Images.SetKeyName(49, "VSObject_Exception_Protected.bmp");
			this._List.Images.SetKeyName(50, "VSObject_Exception_Sealed.bmp");
			this._List.Images.SetKeyName(51, "VSObject_ExceptionPrivate.bmp");
			this._List.Images.SetKeyName(52, "VSObject_Field.bmp");
			this._List.Images.SetKeyName(53, "VSObject_Field_Friend.bmp");
			this._List.Images.SetKeyName(54, "VSObject_Field_Private.bmp");
			this._List.Images.SetKeyName(55, "VSObject_Field_Protected.bmp");
			this._List.Images.SetKeyName(56, "VSObject_Field_Sealed.bmp");
			this._List.Images.SetKeyName(57, "VSObject_Field_Static.bmp");
			this._List.Images.SetKeyName(58, "VSObject_Field_Static_Friend.bmp");
			this._List.Images.SetKeyName(59, "VSObject_Field_Static_Private.bmp");
			this._List.Images.SetKeyName(60, "VSObject_Field_Static_Protected.bmp");
			this._List.Images.SetKeyName(61, "VSObject_Field_Static_Sealed.bmp");
			this._List.Images.SetKeyName(62, "VSObject_File.bmp");
			this._List.Images.SetKeyName(63, "VSObject_Friend.bmp");
			this._List.Images.SetKeyName(64, "VSObject_Interface.bmp");
			this._List.Images.SetKeyName(65, "VSObject_Interface_Friend.bmp");
			this._List.Images.SetKeyName(66, "VSObject_Interface_Private.bmp");
			this._List.Images.SetKeyName(67, "VSObject_Interface_Protected.bmp");
			this._List.Images.SetKeyName(68, "VSObject_Interface_Sealed.bmp");
			this._List.Images.SetKeyName(69, "VSObject_Method.bmp");
			this._List.Images.SetKeyName(70, "VSObject_Method_Friend.bmp");
			this._List.Images.SetKeyName(71, "VSObject_Method_Private.bmp");
			this._List.Images.SetKeyName(72, "VSObject_Method_Protected.bmp");
			this._List.Images.SetKeyName(73, "VSObject_Method_Sealed.bmp");
			this._List.Images.SetKeyName(74, "VSObject_Method_Static.bmp");
			this._List.Images.SetKeyName(75, "VSObject_Method_Static_Friend.bmp");
			this._List.Images.SetKeyName(76, "VSObject_Method_Static_Private.bmp");
			this._List.Images.SetKeyName(77, "VSObject_Method_Static_Protected.bmp");
			this._List.Images.SetKeyName(78, "VSObject_Method_Static_Sealed.bmp");
			this._List.Images.SetKeyName(79, "VSObject_MethodOverload.bmp");
			this._List.Images.SetKeyName(80, "VSObject_MethodOverload_Friend.bmp");
			this._List.Images.SetKeyName(81, "VSObject_MethodOverload_Private.bmp");
			this._List.Images.SetKeyName(82, "VSObject_MethodOverload_Protected.bmp");
			this._List.Images.SetKeyName(83, "VSObject_MethodOverload_Sealed.bmp");
			this._List.Images.SetKeyName(84, "VSObject_MethodOverload_Static.bmp");
			this._List.Images.SetKeyName(85, "VSObject_MethodOverload_Static_Friend.bmp");
			this._List.Images.SetKeyName(86, "VSObject_MethodOverload_Static_Private.bmp");
			this._List.Images.SetKeyName(87, "VSObject_MethodOverload_Static_Protected.bmp");
			this._List.Images.SetKeyName(88, "VSObject_MethodOverload_Static_Sealed.bmp");
			this._List.Images.SetKeyName(89, "VSObject_Module.bmp");
			this._List.Images.SetKeyName(90, "VSObject_Module_Friend.bmp");
			this._List.Images.SetKeyName(91, "VSObject_Module_Private.bmp");
			this._List.Images.SetKeyName(92, "VSObject_Module_Protected.bmp");
			this._List.Images.SetKeyName(93, "VSObject_Module_Sealed.bmp");
			this._List.Images.SetKeyName(94, "VSObject_Namespace.bmp");
			this._List.Images.SetKeyName(95, "VSObject_Operator.bmp");
			this._List.Images.SetKeyName(96, "VSObject_Operator_Friend.bmp");
			this._List.Images.SetKeyName(97, "VSObject_Operator_Private.bmp");
			this._List.Images.SetKeyName(98, "VSObject_Operator_Protected.bmp");
			this._List.Images.SetKeyName(99, "VSObject_Operator_Sealed.bmp");
			this._List.Images.SetKeyName(100, "VSObject_Private.bmp");
			this._List.Images.SetKeyName(101, "VSObject_Properties.bmp");
			this._List.Images.SetKeyName(102, "VSObject_Properties_Friend.bmp");
			this._List.Images.SetKeyName(103, "VSObject_Properties_Private.bmp");
			this._List.Images.SetKeyName(104, "VSObject_Properties_Protected.bmp");
			this._List.Images.SetKeyName(105, "VSObject_Properties_Sealed.bmp");
			this._List.Images.SetKeyName(106, "VSObject_Properties_Static.bmp");
			this._List.Images.SetKeyName(107, "VSObject_Properties_Static_Friend.bmp");
			this._List.Images.SetKeyName(108, "VSObject_Properties_Static_Private.bmp");
			this._List.Images.SetKeyName(109, "VSObject_Properties_Static_Protected.bmp");
			this._List.Images.SetKeyName(110, "VSObject_Properties_Static_Sealed.bmp");
			this._List.Images.SetKeyName(111, "VSObject_References.bmp");
			this._List.Images.SetKeyName(112, "VSObject_Structure.bmp");
			this._List.Images.SetKeyName(113, "VSObject_Structure_Friend.bmp");
			this._List.Images.SetKeyName(114, "VSObject_Structure_Private.bmp");
			this._List.Images.SetKeyName(115, "VSObject_Structure_Protected.bmp");
			this._List.Images.SetKeyName(116, "VSObject_Structure_Sealed.bmp");
			this._List.Images.SetKeyName(117, "VSObject_Type.bmp");
			this._List.Images.SetKeyName(118, "VSObject_Type_Friend.bmp");
			this._List.Images.SetKeyName(119, "VSObject_Type_Private.bmp");
			this._List.Images.SetKeyName(120, "VSObject_Type_Protected.bmp");
			this._List.Images.SetKeyName(121, "VSObject_Type_Sealed.bmp");
			this._List.Images.SetKeyName(122, "VSObject_TypeDef.bmp");
			this._List.Images.SetKeyName(123, "VSObject_TypeDef_Friend.bmp");
			this._List.Images.SetKeyName(124, "VSObject_TypeDef_Private.bmp");
			this._List.Images.SetKeyName(125, "VSObject_TypeDef_Protected.bmp");
			this._List.Images.SetKeyName(126, "VSObject_TypeDef_Sealed.bmp");
			this._List.Images.SetKeyName(127, "VSObject_Union.bmp");
			this._List.Images.SetKeyName(128, "VSObject_Union_Friend.bmp");
			this._List.Images.SetKeyName(129, "VSObject_Union_Protected.bmp");
			this._List.Images.SetKeyName(130, "VSObject_Union_Sealed.bmp");
			this._List.Images.SetKeyName(131, "VSObject_UnionPrivate.bmp");
			this._List.Images.SetKeyName(132, "VSObject_ValueType.bmp");
			this._List.Images.SetKeyName(133, "VSObject_ValueType_Friend.bmp");
			this._List.Images.SetKeyName(134, "VSObject_ValueType_Protected.bmp");
			this._List.Images.SetKeyName(135, "VSObject_ValueType_Sealed.bmp");
			this._List.Images.SetKeyName(136, "VSObject_ValueTypePrivate.bmp");
			this._List.Images.SetKeyName(137, "VSObject_Reference.bmp");
			this._List.Images.SetKeyName(138, "VSObject_Type_Base.bmp");
			this._List.Images.SetKeyName(139, "VSObject_Type_Derived.bmp");
		}

	}
}
