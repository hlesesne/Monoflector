using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
    /// <summary>
    /// Event arguments about a selection change.
    /// </summary>
    public class SelectionChangedEventArgs<TImport> : EventArgs
    {
        /// <summary>
        /// Gets the new selection.
        /// </summary>
        public TImport NewSelection
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionChangedEventArgs&lt;TImport&gt;"/> class.
        /// </summary>
        public SelectionChangedEventArgs(TImport newSelection)
        {
            NewSelection = newSelection;
        }
    }
}
