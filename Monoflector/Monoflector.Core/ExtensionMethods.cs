using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Cecil;

namespace Monoflector {
	
	/// <summary>
	/// Represents extension methods used by Monoflector.
	/// </summary>
	public static partial class ExtensionMethods {

		private static Dictionary<String, List<TypeDefinition>> _derivedTypes = new Dictionary<String,List<TypeDefinition>>();
		
		public static List<TypeDefinition> FindDerivedTypes(this TypeDefinition typeDef, List<AssemblyDefinition> assemblies) {

			String key = typeDef.MetadataToken.RID.ToString(String.Format("x0{0}", 6)).ToLower();

			if (_derivedTypes.ContainsKey(key)) {
				return _derivedTypes[key];
			}

			List<TypeDefinition> list = new List<TypeDefinition>();

			foreach (var assembly in assemblies) {
				foreach (var module in assembly.Modules) {
					foreach (var type in module.Types) {
						Boolean typeAdded = false;

						if (type.BaseType != null) {
							if (type.BaseType.FullName == typeDef.FullName) {
								list.Add(type);
								typeAdded = true;
							}
						}

						if (!typeAdded && type.HasInterfaces) {
							foreach (var iface in type.Interfaces) {
								if (iface.FullName == typeDef.FullName) {
									list.Add(type);
									break;
								}
							}
						}
					}
				}
			}

			_derivedTypes.Add(key, list);

			return list;
		}

	}
}
