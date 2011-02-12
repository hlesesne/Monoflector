using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using System.IO;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents the text/plain formatter.
    /// </summary>
    public class TextPlainFormatterHook : FormatterBase, IFormatterHook
    {
        /// <summary>
        /// Gets the name of the hook.
        /// </summary>
        public string Name
        {
            get { return "text/plain"; }
        }

        TextWriter _writer;
        bool _writeIndent;
        int _indent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextPlainFormatterHook"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public TextPlainFormatterHook(TextWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextPlainFormatterHook"/> class.
        /// </summary>
        public TextPlainFormatterHook()
            : this(new StringWriter())
        {

        }

        /// <summary>
        /// Called when a decompilation operation has been completed.
        /// </summary>
        /// <param name="item">The item that was decompiled.</param>
        /// <param name="target">The decompilation target.</param>
        /// <param name="containingChain"></param>
        public void CompleteDecompile(object item, DecompilationTarget target, FormatterChain containingChain)
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _writer.ToString();
        }

        protected override void OnWriteIndent(int indent)
        {
            for (var i = 0; i < indent; i++)
            {
                WriteRaw("  ");
            }
        }

        protected override void OnWriteRaw(string value)
        {
            _writer.Write(value);
        }

        protected override void OnWriteLine()
        {
            _writer.WriteLine();
        }

        protected override void OnWriteSpace()
        {
            _writer.Write(" ");
        }
    }
}
