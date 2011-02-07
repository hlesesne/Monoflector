using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Monoflector.Runtime
{
    static class Paths
    {
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
                    _root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    _root = Path.Combine(_root, "Monoflector");
                    Directory.CreateDirectory(_root);
                }
                return _root;
            }
        }

        private static string _plugins;
        /// <summary>
        /// Gets the plugins path.
        /// </summary>
        public static string Plugins
        {
            get
            {
                if (_plugins == null)
                {
                    _plugins = Path.Combine(Root, "Plugins");
                    Directory.CreateDirectory(_plugins);
                }
                return _plugins;
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
    }
}
