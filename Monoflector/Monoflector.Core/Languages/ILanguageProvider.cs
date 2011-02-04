using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Cecil.Decompiler.Languages;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents a language provider.
    /// </summary>
    [InheritedExport(typeof(ILanguageProvider))]
    public interface ILanguageProvider
    {
        /// <summary>
        /// Gets the name of the language.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        ILanguage Language
        {
            get;
        }

        /// <summary>
        /// Creates a new decompilation target
        /// for the language.
        /// </summary>
        /// <returns>The decompilation target.</returns>
        DecompilationTarget CreateDecompilationTarget();
    }
}
