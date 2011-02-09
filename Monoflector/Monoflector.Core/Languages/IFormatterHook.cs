using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using System.ComponentModel.Composition;
using Mono.Cecil;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents a formatter hook.
    /// </summary>
    [InheritedExport(typeof(IFormatterHook))]
    public interface IFormatterHook : IFormatter
    {
        /// <summary>
        /// Gets the name of the hook.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Called when a decompilation operation has been completed.
        /// </summary>
        /// <param name="item">The item that was decompiled.</param>
        /// <param name="target">The decompilation target.</param>
        void CompleteDecompile(object item, DecompilationTarget target, FormatterChain containingChain);
    }
}
