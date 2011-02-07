using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using System.ComponentModel.Composition;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents the default implementation of <see cref="LanguageProvider"/>.
    /// </summary>
    [PartNotDiscoverable] // Prevent discovery of this specific part.
    public class LanguageProviderBase : ILanguageProvider
    {
        /// <summary>
        /// Gets the name of the language.
        /// </summary>
        public string Name
        {
            get
            {
                return Language.Name;
            }
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Cecil.Decompiler.Languages.ILanguage Language
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageProviderBase"/> class.
        /// </summary>
        public LanguageProviderBase(ILanguage language)
        {
            if (language == null)
                throw new ArgumentNullException("language");
            Language = language;
        }

        /// <summary>
        /// Creates a new decompilation target
        /// for the language.
        /// </summary>
        /// <returns>
        /// The decompilation target.
        /// </returns>
        public DecompilationTarget CreateDecompilationTarget()
        {
            return new DecompilationTarget(x => Language.GetWriter(x));
        }
    }
}
