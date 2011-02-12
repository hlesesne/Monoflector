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

        #region Interface delegation
        public void Indent()
        {
            foreach (var hook in _formatters.Values)
                hook.Indent();
        }

        public void Outdent()
        {
            foreach (var hook in _formatters.Values)
                hook.Outdent();
        }

        public void WriteAliasTypeKeyword(string keyword, Mono.Cecil.TypeReference type)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteAliasTypeKeyword(keyword, type);
        }

        public void WriteBlockEnd(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteBlockEnd(value);
        }

        public void WriteBlockStart(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteBlockStart(value);
        }

        public void WriteComment(string comment)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteComment(comment);
        }

        public void WriteDocComment(string comment)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteDocComment(comment);
        }

        public void WriteGenericToken(string name)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteGenericToken(name);
        }

        public void WriteKeyword(string keyword)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteKeyword(keyword);
        }

        public void WriteLabelReference(string name)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLabelReference(name);
        }

        public void WriteLine()
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLine();
        }

        public void WriteLiteralChar(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLiteralChar(value);
        }

        public void WriteLiteralNumber(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLiteralNumber(value);
        }

        public void WriteLiteralString(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteLiteralString(value);
        }

        public void WriteMultilineComment(string comment)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteMultilineComment(comment);
        }

        public void WriteNameReference(string name, Mono.Cecil.MemberReference member)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteNameReference(name, member);
        }

        public void WriteNamedLiteral(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteNamedLiteral(value);
        }

        public void WriteOperator(string name)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteOperator(name);
        }

        public void WriteOperatorWord(string name)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteOperatorWord(name);
        }

        public void WriteParameterName(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteParameterName(value);
        }

        public void WriteParenthesisClose(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteParenthesisClose(value);
        }

        public void WriteParenthesisOpen(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteParenthesisOpen(value);
        }

        public void WritePrepocComment(string comment)
        {
            foreach (var hook in _formatters.Values)
                hook.WritePrepocComment(comment);
        }

        public void WriteRaw(string value)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteRaw(value);
        }

        public void WriteSpace()
        {
            foreach (var hook in _formatters.Values)
                hook.WriteSpace();
        }

        public void WriteVariableReference(string name)
        {
            foreach (var hook in _formatters.Values)
                hook.WriteVariableReference(name);
        } 
        #endregion
    }
}
