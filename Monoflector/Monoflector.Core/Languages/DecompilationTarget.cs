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

            if (_chain != null)
            {
                _chain.CompleteDecompile(expression, this);
            }
        }

        /// <summary>
        /// Writes the specified statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        void ILanguageWriter.Write(Cecil.Decompiler.Ast.Statement statement)
        {
            LanguageWriter.Write(statement);

            if (_chain != null)
            {
                _chain.CompleteDecompile(statement, this);
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
            if (_chain != null)
            {
                _chain.CompleteDecompile(method, this);
            }
        } 
        #endregion

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            _stringWriter = new StringWriter();

            _chain = new FormatterChain(_hooks);

            LanguageWriter = _languageWriterCreator(_chain);
            if (LanguageWriter == null)
                throw new ArgumentOutOfRangeException("languageWriterCreator", Monoflector.Properties.Resources.LanguageWriterCreator_NullValue);
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
            return _chain.ToString(contentType);
        }
    }
}
