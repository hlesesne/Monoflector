using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector
{
    /// <summary>
    /// Represents <see cref="EventArgs"/> that contain
    /// a read-only value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ValueEventArgs<TValue> : EventArgs
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        public TValue Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueEventArgs&lt;TValue&gt;"/> class.
        /// </summary>
        public ValueEventArgs(TValue value)
        {
            Value = value;
        }
    }
}
