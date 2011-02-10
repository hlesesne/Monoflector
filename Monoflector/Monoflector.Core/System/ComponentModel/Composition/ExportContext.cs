using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
    /// <summary>
    /// Represents the different export contexts.
    /// </summary>
    public enum ExportContext
    {
        /// <summary>
        /// The normal export context.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// The installation export context.
        /// </summary>
        Installation = 1,
    }
}
