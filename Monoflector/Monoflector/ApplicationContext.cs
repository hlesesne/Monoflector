using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Languages;
using System.ComponentModel.Composition;

namespace Monoflector
{
    /// <summary>
    /// Represents the application context.
    /// </summary>
    public class ApplicationContext
    {
        /// <summary>
        /// The context instance.
        /// </summary>
        public static readonly ApplicationContext Instance = new ApplicationContext();

        /// <summary>
        /// Gets the languages.
        /// </summary>
        [ImportMany(typeof(ILanguageProvider))]
        public IEnumerable<ILanguageProvider> Languages
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        public ApplicationContext()
        {

        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        public void Initialize()
        {
            this.ComposeParts();
        }
    }
}
