using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace Monoflector
{
    partial class ExtensionMethods
    {
        /// <summary>
        /// Gets a localized element for the specified element.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>
        /// The localized element.
        /// </returns>
        public static XElement LocalElement(this IEnumerable<XElement> elements, CultureInfo cultureInfo)
        {
            XElement result = null;
            while (result == null && cultureInfo != null)
            {
                if (cultureInfo == CultureInfo.InvariantCulture)
                {
                    return elements.Where(x => x.Attribute(XNamespace.Xml + "lang") == null).FirstOrDefault();
                }
                result = elements.Where(x => (string)x.Attribute(XNamespace.Xml + "lang") == cultureInfo.ThreeLetterISOLanguageName).FirstOrDefault();
                cultureInfo = cultureInfo.Parent;
            }
            return result;
        }

        /// <summary>
        /// Gets a localized element for the specified element.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns>
        /// The localized element.
        /// </returns>
        public static XElement LocalElement(this IEnumerable<XElement> elements)
        {
            return LocalElement(elements, Thread.CurrentThread.CurrentCulture);
        }
    }
}
