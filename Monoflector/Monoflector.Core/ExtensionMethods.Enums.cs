using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector
{
    partial class ExtensionMethods
    {
        /// <summary>
        /// Converts a enum to a localized string value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The localized string value.</returns>
        public static string ToLocalString<T>(this T value)
            where T : struct
        {
            var strValue = value.ToString();
            var localized = CompositionServices.CompositionContainer.GetExportedValues<string>(typeof(T).AssemblyQualifiedName + "::" + strValue).FirstOrDefault();
            if (!string.IsNullOrEmpty(localized))
                return localized;
            else
                return strValue;
        }
    }
}
