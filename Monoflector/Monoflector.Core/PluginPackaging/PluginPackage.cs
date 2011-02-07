using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using System.Xml.Linq;
using Monoflector.PluginPackaging;

namespace Monoflector.PluginPackaging
{
    /// <summary>
    /// Represents a plugin package.
    /// </summary>
    public class PluginPackage : IDisposable
    {
        public static readonly XNamespace PluginNamespace = "http://schemas.monoflector.com/extensibility/plugin";

        /// <summary>
        /// Gets the temporary directory.
        /// </summary>
        public string TemporaryDirectory
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the installables.
        /// </summary>
        public string[] Installables
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the install doc path.
        /// </summary>
        public string InstallDocPath
        {
            get;
            private set;
        }

        private ZipFile _zipFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginPackage"/> class.
        /// </summary>
        private PluginPackage()
        {

        }

        /// <summary>
        /// Loads the specified package.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The package.</returns>
        public static PluginPackage Load(string filename)
        {
            var tempDir = Path.GetTempFileName();
            File.Delete(tempDir);
            Directory.CreateDirectory(tempDir);

            var file = ZipFile.Read(filename);
            foreach (var fn in file.EntryFileNames.Where(x => 
                    string.Compare(x, "manifest.xml", true) == 0 || 
                    string.Compare(Path.GetDirectoryName(x), "installDoc", true) == 0))
            {
                file[fn].Extract(tempDir);
            }

            var package = new PluginPackage();
            package._zipFile = file;
            package.TemporaryDirectory = tempDir;
            package.Load();
            return package;
        }

        /// <summary>
        /// Extracts the specified installable.
        /// </summary>
        /// <param name="installable">The installable.</param>
        /// <param name="target">The target.</param>
        public string Extract(string installable, string path)
        {
            var final = Path.Combine(path, installable);
            if (File.Exists(final))
                File.Delete(final);
            _zipFile[installable].Extract(path);
            return final;
        }

        private void Load()
        {
            var doc = XDocument.Load(Path.Combine(TemporaryDirectory, "manifest.xml"));
            var root = doc.Element(PluginNamespace + "Definition");
            Title = (string)root.Elements(PluginNamespace + "Title").LocalElement();
            Author = (string)root.Elements(PluginNamespace + "Author").LocalElement();

            var installables = new List<string>();
            foreach (var file in root.Elements(PluginNamespace + "File"))
            {
                installables.Add((string)file);
            }

            Installables = installables.ToArray();
            InstallDocPath = Path.Combine(TemporaryDirectory, "installDoc");
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PluginPackage"/> is reclaimed by garbage collection.
        /// </summary>
        ~PluginPackage()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Directory.Delete(TemporaryDirectory, true);
            }
            catch
            {

            }

            if (_zipFile != null)
            {
                _zipFile.Dispose();
                _zipFile = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
