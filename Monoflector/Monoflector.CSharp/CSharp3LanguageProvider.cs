using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Languages;
using Cecil.Decompiler.Languages;

namespace Monoflector.CSharp
{
    /// <summary>
    /// Represents the C# 3.0 (or 3.5) language provider.
    /// </summary>
    public class CSharp3LanguageProvider : LanguageProviderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharp3LanguageProvider"/> class.
        /// </summary>
        public CSharp3LanguageProvider()
            : base(Cecil.Decompiler.Languages.CSharp.GetLanguage(CSharpVersion.V1))
        {

        }
    }
}
