using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using System.IO;
using System.ComponentModel.Composition;
using Mono.Cecil;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents a decompilation target.
    /// </summary>
    public class DecompilationTarget : ILanguageWriter, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// The language writer hooks.
        /// </summary>
        [ImportMany(typeof(IFormatterHook), AllowRecomposition = true)]
        private IEnumerable<IFormatterHook> _hooks;
        private FormatterChain _chain;

        /// <summary>
        /// Gets the language writer.
        /// </summary>
        public ILanguageWriter LanguageWriter
        {
            get;
            private set;
        }

        private StringWriter _stringWriter;
        private Func<IFormatter, ILanguageWriter> _languageWriterCreator;
        private IFormatterHook _formatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecompilationTarget"/> class.
        /// </summary>
        public DecompilationTarget(Func<IFormatter, ILanguageWriter> languageWriterCreator)
        {
            if (languageWriterCreator == null)
                throw new ArgumentNullException("languageWriterCreator");
            _languageWriterCreator = languageWriterCreator;
            this.ComposeParts();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _stringWriter.ToString();
        }

        #region ILanguageWriter
        /// <summary>
        /// Writes the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void ILanguageWriter.Write(Cecil.Decompiler.Ast.Expression expression)
        {
            LanguageWriter.Write(expression);

            if (_formatter != null)
            {
                _formatter.CompleteDecompile(expression, this);
            }
        }

        /// <summary>
        /// Writes the specified statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        void ILanguageWriter.Write(Cecil.Decompiler.Ast.Statement statement)
        {
            LanguageWriter.Write(statement);

            if (_formatter != null)
            {
                _formatter.CompleteDecompile(statement, this);
            }
        }

        /// <summary>
        /// Writes the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        void ILanguageWriter.Write(Mono.Cecil.MethodDefinition method)
        {
            try
            {
                LanguageWriter.Write(method);
            }
            catch
            {
                return;
            }
            if (_formatter != null)
            {
                _formatter.CompleteDecompile(method, this);
            }
        } 
        #endregion

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            _formatter = null;
            _stringWriter = new StringWriter();
            IFormatter formatter = new PlainTextFormatter(_stringWriter);
            
            // Get the hooks.
            if (_hooks != null)
            {
                var chain = new FormatterChain(_hooks);
                chain.Prepend(formatter);
                formatter = _formatter = chain;
            }

            LanguageWriter = _languageWriterCreator(formatter);
            if (LanguageWriter == null)
                throw new ArgumentOutOfRangeException("languageWriterCreator", "languageWriterCreator returned a null value.");
        }
    }
}
