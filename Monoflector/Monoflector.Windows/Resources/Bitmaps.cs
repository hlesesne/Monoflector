using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.Windows.Resources {

	/// <summary>
	/// Class for storing friendly names for object positions in the main image list.
	/// </summary>
	public class Bitmaps {

		public enum CategoryMember {
			Default,
			Internal,
			Private,
			Protected,
			Sealed,
			Static,
			StaticInternal,
			StaticPrivate,
			StaticProtected,
			StaticSealed
		}

		public class Category { }

		public class Class : Category {
			public const int Default = 1;
			public const int Internal = 2;
			public const int Private = 3;
			public const int Protected = 4;
			public const int Sealed = 5;
		}

		public class Constant : Category {
			public const int Default = 6;
			public const int Internal = 7;
			public const int Private = 8;
			public const int Protected = 9;
			public const int Sealed = 10;
		}

		public class Constrcutor : Category {
			public const int Default = 11;
			public const int Internal = 12;
			public const int Private = 13;
			public const int Protected = 14;
			public const int Sealed = 15;
			public const int Static = 16;
			public const int StaticInternal = 17;
			public const int StaticPrivate = 18;
			public const int StaticProtected = 19;
			public const int StaticSealed = 20;
		}

		public class Delegate : Category {
			public const int Default = 21;
			public const int Internal = 22;
			public const int Private = 23;
			public const int Protected = 24;
			public const int Sealed = 25;
		}

		public class Enum : Category {
			public const int Default = 27;
			public const int Internal = 28;
			public const int Protected = 29;
			public const int Sealed = 30;
			public const int Private = 36;
		}

		public class EnumMember : Category {
			public const int Default = 31;
			public const int Internal = 32;
			public const int Private = 33;
			public const int Protected = 34;
			public const int Sealed = 35;
		}

		public class Event : Category {
			public const int Default = 37;
			public const int Internal = 38;
			public const int Private = 39;
			public const int Protected = 40;
			public const int Sealed = 41;
			public const int Static = 42;
			public const int StaticInternal = 43;
			public const int StaticPrivate = 44;
			public const int StaticProtected = 45;
			public const int StaticSealed = 46;
		}

		public class Exception : Category {
			public const int Default = 47;
			public const int Internal = 48;
			public const int Private = 49;
			public const int Protected = 50;
			public const int Sealed = 51;
		}

		public class Field : Category {
			public const int Default = 52;
			public const int Internal = 53;
			public const int Private = 54;
			public const int Protected = 55;
			public const int Sealed = 56;
			public const int Static = 57;
			public const int StaticInternal = 58;
			public const int StaticPrivate = 59;
			public const int StaticProtected = 60;
			public const int StaticSealed = 61;
		}

		public class Interface : Category {
			public const int Default = 64;
			public const int Internal = 65;
			public const int Private = 66;
			public const int Protected = 67;
			public const int Sealed = 68;
		}

		public class Method : Category {
			public const int Default = 69;
			public const int Internal = 70;
			public const int Private = 71;
			public const int Protected = 72;
			public const int Sealed = 73;
			public const int Static = 74;
			public const int StaticInternal = 75;
			public const int StaticPrivate = 76;
			public const int StaticProtected = 77;
			public const int StaticSealed = 78;
		}

		public class MethodOverload : Category {
			public const int Default = 79;
			public const int Internal = 80;
			public const int Private = 81;
			public const int Protected = 82;
			public const int Sealed = 83;
			public const int Static = 84;
			public const int StaticInternal = 85;
			public const int StaticPrivate = 86;
			public const int StaticProtected = 87;
			public const int StaticSealed = 88;
		}

		public class Property : Category {
			public const int Default = 101;
			public const int Internal = 102;
			public const int Private = 103;
			public const int Protected = 104;
			public const int Sealed = 105;
			public const int Static = 106;
			public const int StaticInternal = 107;
			public const int StaticPrivate = 108;
			public const int StaticProtected = 109;
			public const int StaticSealed = 110;
		}

		public class Structure : Category {
			public const int Default = 112;
			public const int Internal = 113;
			public const int Private = 114;
			public const int Protected = 115;
			public const int Sealed = 116;
		}

		// values without a home
		public const int Assembly = 0;
		public const int Dummy = 26;
		public const int ModuleFile = 62;
		public const int Internal = 63;
		public const int Namespace = 94;
		public const int References = 111;
		public const int Reference = 137;
		public const int BaseType = 138;
		public const int DerivedType = 139;
	}
}
