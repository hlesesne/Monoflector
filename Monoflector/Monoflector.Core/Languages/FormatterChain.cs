using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using System.ComponentModel.Composition;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents a chain of <see cref="IFormatter">IFormatters</see>.
    /// </summary>
    [PartNotDiscoverable] // Prevent discovery of this specific part.
    public sealed class FormatterChain : IFormatterHook
    {
        /// <summary>
        /// Gets the name of the hook.
        /// </summary>
        public string Name
        {
            get { return "Chain"; }
        }

        private static readonly LinkedList<IFormatter> _empty = new LinkedList<IFormatter>();

        private LinkedList<IFormatter> _formatters;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatterChain"/> class.
        /// </summary>
        /// <param name="formatters">The formatters.</param>
        public FormatterChain(IEnumerable<IFormatterHook> formatters)
        {
            if (formatters == null)
                _formatters = _empty;
            else
                _formatters = new LinkedList<IFormatter>(formatters);
        }

        /// <summary>
        /// Prepends the specified formatter.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        public void Prepend(IFormatter formatter)
        {
            _formatters.AddFirst(formatter);
        }

        /// <summary>
        /// Appends the specified formatter.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        public void Append(IFormatter formatter)
        {
            _formatters.AddLast(formatter);
        }

        /// <summary>
        /// Called when a decompilation operation has been completed.
        /// </summary>
        /// <param name="item">The item that was decompiled.</param>
        /// <param name="target">The decompilation target.</param>
        public void CompleteDecompile(object item, DecompilationTarget target)
        {
            foreach (var hook in _formatters)
            {
                if (hook is IFormatterHook)
                {
                    ((IFormatterHook)hook).CompleteDecompile(item, target);
                }
            }
        }

        /// <summary>
        /// Indents this instance.
        /// </summary>
        public void Indent()
        {
            foreach (var hook in _formatters)
                hook.Indent();
        }

        /// <summary>
        /// Outdents this instance.
        /// </summary>
        public void Outdent()
        {
            foreach (var hook in _formatters)
                hook.Outdent();
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        public void Write(string str)
        {
            foreach (var hook in _formatters)
                hook.Write(str);
        }

        /// <summary>
        /// Writes the specified comment.
        /// </summary>
        /// <param name="comment">The specified comment.</param>
        public void WriteComment(string comment)
        {
            foreach (var hook in _formatters)
                hook.WriteComment(comment);
        }

        /// <summary>
        /// Writes the specified definition.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="definition">The definition.</param>
        public void WriteDefinition(string value, object definition)
        {
            foreach (var hook in _formatters)
                hook.WriteDefinition(value, definition);
        }

        /// <summary>
        /// Writes the specified identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="identifier">The identifier.</param>
        public void WriteIdentifier(string value, object identifier)
        {
            foreach (var hook in _formatters)
                hook.WriteDefinition(value, identifier);
        }

        /// <summary>
        /// Writes the specified keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        public void WriteKeyword(string keyword)
        {
            foreach (var hook in _formatters)
                hook.WriteKeyword(keyword);
        }

        /// <summary>
        /// Writes a new line.
        /// </summary>
        public void WriteLine()
        {
            foreach (var hook in _formatters)
                hook.WriteLine();
        }

        /// <summary>
        /// Writes the specified literal.
        /// </summary>
        /// <param name="literal">The literal.</param>
        public void WriteLiteral(string literal)
        {
            foreach (var hook in _formatters)
                hook.WriteLiteral(literal);
        }

        /// <summary>
        /// Writes the specified reference.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="reference">The reference.</param>
        public void WriteReference(string value, object reference)
        {
            foreach (var hook in _formatters)
                hook.WriteReference(value, reference);
        }

        /// <summary>
        /// Writes a space.
        /// </summary>
        public void WriteSpace()
        {
            foreach (var hook in _formatters)
                hook.WriteSpace();
        }

        /// <summary>
        /// Writes the specified token.
        /// </summary>
        /// <param name="token">The token.</param>
        public void WriteToken(string token)
        {
            foreach (var hook in _formatters)
                hook.WriteToken(token);
        }
    }
}
