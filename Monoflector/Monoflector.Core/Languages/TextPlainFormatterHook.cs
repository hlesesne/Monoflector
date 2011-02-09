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
    public class TextPlainFormatterHook : IFormatterHook
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

        /// <summary>
        /// Writes the indent.
        /// </summary>
        void WriteIndent()
        {
            if (!_writeIndent)
                return;

            for (int i = 0; i < _indent; i++)
                _writer.Write("  ");
        }

        /// <summary>
        /// Writes a raw string to the code output.
        /// </summary>
        /// <param name="str">The raw string.</param>
        public void Write(string str)
        {
            WriteIndent();
            _writer.Write(str);
            _writeIndent = false;
        }

        /// <summary>
        /// Writes a line to the code output.
        /// </summary>
        public void WriteLine()
        {
            _writer.WriteLine();
            _writeIndent = true;
        }

        /// <summary>
        /// Writes the space.
        /// </summary>
        public void WriteSpace()
        {
            Write(" ");
        }

        /// <summary>
        /// Writes a token to the code output.
        /// </summary>
        /// <param name="token">The token.</param>
        public void WriteToken(string token)
        {
            Write(token);
        }

        /// <summary>
        /// Writes a comment to the code output.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public void WriteComment(string comment)
        {
            Write(comment);
            WriteLine();
        }

        /// <summary>
        /// Writes a keyword to the code output.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        public void WriteKeyword(string keyword)
        {
            Write(keyword);
        }

        /// <summary>
        /// Writes a literal to the code output.
        /// </summary>
        /// <param name="literal">The literal.</param>
        public void WriteLiteral(string literal)
        {
            Write(literal);
        }

        /// <summary>
        /// Writes a definition to the code output.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="definition">The definition.</param>
        public void WriteDefinition(string value, object definition)
        {
            Write(value);
        }

        /// <summary>
        /// Writes a reference to the code output.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="reference">The reference.</param>
        public void WriteReference(string value, object reference)
        {
            Write(value);
        }

        /// <summary>
        /// Writes an identifier to the code output.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="identifier">The identifier.</param>
        public void WriteIdentifier(string value, object identifier)
        {
            Write(value);
        }

        /// <summary>
        /// Indents the code output.
        /// </summary>
        public void Indent()
        {
            _indent++;
        }

        /// <summary>
        /// Outdents the code output.
        /// </summary>
        public void Outdent()
        {
            _indent--;
        }

        /// <summary>
        /// Completes the decompilation operation.
        /// </summary>
        public void Complete()
        {
            _writer.Flush();
        }
    }
}
