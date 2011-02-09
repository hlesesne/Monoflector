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
    public sealed class FormatterChain : IFormatter
    {
        /// <summary>
        /// Gets the name of the hook.
        /// </summary>
        public string Name
        {
            get { return "Chain"; }
        }

        private static readonly Dictionary<string, IFormatter> _empty = new Dictionary<string, IFormatter>();

        private Dictionary<string, IFormatter> _formatters;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatterChain"/> class.
        /// </summary>
        /// <param name="formatters">The formatters.</param>
        public FormatterChain(IEnumerable<IFormatterHook> formatters)
        {
            if (formatters == null)
                _formatters = _empty;
            else
            {
                _formatters = new Dictionary<string, IFormatter>(StringComparer.OrdinalIgnoreCase);
                foreach (var formatter in formatters)
                    _formatters.Add(formatter.Name, formatter);
            }
        }

        /// <summary>
        /// Called when a decompilation operation has been completed.
        /// </summary>
        /// <param name="item">The item that was decompiled.</param>
        /// <param name="target">The decompilation target.</param>
        public void CompleteDecompile(object item, DecompilationTarget target)
        {
            foreach (var hook in _formatters.Values)
            {
                if (hook is IFormatterHook)
                {
                    ((IFormatterHook)hook).CompleteDecompile(item, target, this);
                }
            }
        }

        /// <summary>
        /// Indents this instance.
        /// </summary>
        public void Indent()
        {
            foreach (var hook in _formatters.Values)
                hook.Indent();
        }

        /// <summary>
        /// Outdents this instance.
        /// </summary>
        public void Outdent()
        {
            foreach (var hook in _formatters.Values)
                hook.Outdent();
        }

        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        public void Write(string str)
        {
            foreach (var hook in _formatters.Values)
                hook.Write(str);
        }

        /// <summary>
        /// Writes the specified comment.
        /// </summary>
        /// <param name="comment">The specified comment.</param>
        public void WriteComment(string comment)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteComment(comment);
        }

        /// <summary>
        /// Writes the specified definition.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="definition">The definition.</param>
        public void WriteDefinition(string value, object definition)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteDefinition(value, definition);
        }

        /// <summary>
        /// Writes the specified identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="identifier">The identifier.</param>
        public void WriteIdentifier(string value, object identifier)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteDefinition(value, identifier);
        }

        /// <summary>
        /// Writes the specified keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        public void WriteKeyword(string keyword)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteKeyword(keyword);
        }

        /// <summary>
        /// Writes a new line.
        /// </summary>
        public void WriteLine()
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLine();
        }

        /// <summary>
        /// Writes the specified literal.
        /// </summary>
        /// <param name="literal">The literal.</param>
        public void WriteLiteral(string literal)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLiteral(literal);
        }

        /// <summary>
        /// Writes the specified reference.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="reference">The reference.</param>
        public void WriteReference(string value, object reference)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteReference(value, reference);
        }

        /// <summary>
        /// Writes a space.
        /// </summary>
        public void WriteSpace()
        {
            foreach (var hook in _formatters.Values)
                hook.WriteSpace();
        }

        /// <summary>
        /// Writes the specified token.
        /// </summary>
        /// <param name="token">The token.</param>
        public void WriteToken(string token)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteToken(token);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="contentType">The desired MIME content-type.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(string contentType)
        {
            IFormatter tmp;
            if (_formatters.TryGetValue(contentType, out tmp))
                return tmp.ToString();
            return null;
        }
    }
}
