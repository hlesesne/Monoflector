using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Monoflector.Runtime;

namespace Monoflector.PluginPackaging
{
    /// <summary>
    /// Represents the plugin manager.
    /// </summary>
    public class PluginManager : IPluginManager
    {
        /// <summary>
        /// Occurs when a file is installing.
        /// </summary>
        public event EventHandler<ValueEventArgs<PluginProgress>> FileInstalling;

        /// <summary>
        /// Installs the specified file.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="file">The file.</param>
        /// <param name="progress">The progress.</param>
        public void Install(string component, string file, int progress)
        {
            var localFile = Path.GetFileName(file);

            var tmp = FileInstalling;
            if (tmp != null)
                tmp(this, new ValueEventArgs<PluginProgress>(new PluginProgress(component, localFile, progress)));

            var newPath = Path.Combine(Paths.Plugins, localFile);
            if (!File.Exists(newPath))
                File.Copy(file, newPath);
        }

        /// <summary>
        /// Installs the calling assembly.
        /// </summary>
        public void InstallCaller()
        {
            var asm = Assembly.GetCallingAssembly();
            var file = asm.Location;

            var titleAttr = (AssemblyDescriptionAttribute[])asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            var title = new AssemblyName(asm.FullName).Name;
            if (titleAttr != null && titleAttr.Length > 0)
            {
                title = titleAttr[0].Description;
            }

            var localDir = Path.GetDirectoryName(file);
            var localFile = Path.GetFileName(file);
            var localFileFilter = localFile + ".*";
            var files = Directory.GetFiles(localDir, localFileFilter);

            for (int i = 0; i < files.Length; i++)
            {
                Install(title, files[i], (i * 100) / files.Length);
            }
        }


        /// <summary>
        /// Updates indicating that a file installation is in progress.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="file">The file.</param>
        /// <param name="progress">The progress.</param>
        public void Update(string component, string file, int progress)
        {
            var localFile = Path.GetFileName(file);

            var tmp = FileInstalling;
            if (tmp != null)
                tmp(this, new ValueEventArgs<PluginProgress>(new PluginProgress(component, localFile, progress)));
        }
    }
}
