using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Monoflector.PluginSystem.Definition
{
    /// <summary>
    /// Represents a localized element.
    /// </summary>
    public class LocalizedElement : LocalizedEntity
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlText]
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Monoflector.PluginPackaging.Definition.LocalizedElement"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator string(LocalizedElement element)
        {
            if (element == null)
                return null;
            else
                return element.Value;
        }
    }
}
