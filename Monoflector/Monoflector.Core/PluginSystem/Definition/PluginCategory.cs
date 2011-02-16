using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector.PluginSystem.Definition
{
    /// <summary>
    /// Represents the different types of plugins.
    /// </summary>
    public enum PluginCategory
    {
        /// <summary>
        /// Generic plugins.
        /// </summary>
        Plugins = 0,
        /// <summary>
        /// Language renderers.
        /// </summary>
        Languages = 1,
        /// <summary>
        /// Code styles.
        /// </summary>
        CodeStyles = 2,
        /// <summary>
        /// Views for the AST.
        /// </summary>
        Views = 3,
        /// <summary>
        /// System functionality.
        /// </summary>
        System = 4,
    }
}
