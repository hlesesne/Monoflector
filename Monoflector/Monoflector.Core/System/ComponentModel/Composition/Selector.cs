using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
    /// <summary>
    /// Represens a selector.
    /// </summary>
    /// <typeparam name="TImport">The type of the import.</typeparam>
    public abstract class Selector<TImport> : IDisposable
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        public IEnumerable<TImport> Options
        {
            get;
            private set;
        }

        private TImport _selectedValue;
        /// <summary>
        /// Gets the selected value.
        /// </summary>
        public TImport SelectedValue
        {
            get
            {
                return SelectedValue;
            }
            private set
            {
                _selectedValue = value;
                var temp = SelectionChanged;
                if (temp != null)
                {
                    temp(this, new SelectionChangedEventArgs<TImport>(value));
                }
            }
        }

        /// <summary>
        /// Occurs when the selection is changed.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs<TImport>> SelectionChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector&lt;TImport&gt;"/> class.
        /// </summary>
        public Selector()
        {
            Monoflector.CompositionServices.ComposeParts(this);
            SelectedValue = Options.FirstOrDefault();
        }

        void IDisposable.Dispose()
        {
            // No finalizer because this doesn't have unmanaged resources.
            SelectionChanged = null;
        }
        protected abstract string IdentityFor(TImport import); // We need this for saving settings later.
        protected abstract TImport ImportFor(string identity);
    }
}
