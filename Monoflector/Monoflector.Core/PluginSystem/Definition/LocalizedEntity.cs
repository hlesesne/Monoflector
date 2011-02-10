using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Globalization;

namespace Monoflector.PluginSystem.Definition
{
    /// <summary>
    /// Represents a localized entity.
    /// </summary>
    public abstract class LocalizedEntity
    {
        /// <summary>
        /// Gets or sets the culture name.
        /// </summary>
        /// <value>
        /// The culture name.
        /// </value>
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        [XmlIgnore]
        public CultureInfo Culture
        {
            get
            {
                if (string.IsNullOrEmpty(Language))
                    return CultureInfo.InvariantCulture;
                else
                    return CultureInfo.GetCultureInfo(Language);
            }
            set
            {
                if (value == null || value == CultureInfo.InvariantCulture)
                    Language = null;
                else
                    Language = value.ThreeLetterISOLanguageName;
            }
        }
    }
}
