using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Languages;
using Cecil.Decompiler.Languages;

namespace Monoflector.CSharp
{
    /// <summary>
    /// Represents the C# 1.0 language provider.
    /// </summary>
    public class CSharp1LanguageProvider : LanguageProviderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharp1LanguageProvider"/> class.
        /// </summary>
        public CSharp1LanguageProvider()
            : base(Cecil.Decompiler.Languages.CSharp.GetLanguage(CSharpVersion.V1))
        {

        }
    }
}
