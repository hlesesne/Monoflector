using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Monoflector.Runtime
{
    /// <summary>
    /// Represents the paths relevant that the Monoflector runtime
    /// uses.
    /// </summary>
    public static class Paths
    {
        private static bool _isPortableMode;
        /// <summary>
        /// Gets a value indicating whether the application is running portable mode directory.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if this the application is running in a portable mode directory; otherwise, <see langword="false"/>.
        /// </value>
        public static bool IsPortableMode
        {
            get
            {
                GC.KeepAlive(Root);
                return _isPortableMode;
            }
        }

        private static string _root;
        /// <summary>
        /// Gets the root path.
        /// </summary>
        public static string Root
        {
            get
            {
                if (_root == null)
                {
                    var pdir = Path.Combine(Entry, "Portable");
                    if (Directory.Exists(pdir))
                    {
                        _root = pdir;
                        _isPortableMode = true;
                    }
                    else
                    {
                        _root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        _root = Path.Combine(_root, "Monoflector");
                        Directory.CreateDirectory(_root);
                    }
                }
                return _root;
            }
        }

        private static string _entry;
        /// <summary>
        /// Gets the entry path.
        /// </summary>
        public static string Entry
        {
            get
            {
                if (_entry == null)
                {
                    _entry = Path.GetDirectoryName(typeof(CompositionServices).Assembly.Location);
                }
                return _entry;
            }
        }

        private static string _bootstrap;
        /// <summary>
        /// Gets the bootstrap path.
        /// </summary>
        public static string Bootstrap
        {
            get
            {
                if (_bootstrap == null)
                {
                    _bootstrap = Path.Combine(Entry, "Bootstrap");
                }
                return _bootstrap;
            }
        }

        /// <summary>
        /// Re-evaluates the paths.
        /// </summary>
        public static void ReEvaluate()
        {
            _bootstrap = null;
            _entry = null;
            _root = null;
        }
    }
}
