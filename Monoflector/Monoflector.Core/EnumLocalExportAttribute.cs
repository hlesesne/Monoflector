using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector
{
    /// <summary>
    /// Marks a value as a localized enum string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class EnumLocalExportAttribute : ExportAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumLocalExportAttribute"/> class.
        /// </summary>
        public EnumLocalExportAttribute(Type enumType, string enumValue)
            : base(enumType.AssemblyQualifiedName + "::" + enumValue, typeof(string))
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");
            if (string.IsNullOrEmpty(enumValue))
                throw new ArgumentNullException("enumValue");
        }
    }
}
