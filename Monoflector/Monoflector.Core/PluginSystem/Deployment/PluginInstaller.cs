using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using System.IO;

namespace Monoflector.PluginSystem.Deployment
{
    /// <summary>
    /// Represents a plugin installer.
    /// </summary>
    public class PluginInstaller : IEnumerable<DeploymentContext>
    {
        private Dictionary<DeploymentContext, bool> _plugins = new Dictionary<DeploymentContext, bool>();

        /// <summary>
        /// Gets or sets whether to install the specified plugin.
        /// </summary>
        public bool this[DeploymentContext context]
        {
            get
            {
                return _plugins[context];
            }
            set
            {
                _plugins[context] = value;
            }
        }

        private bool _installStarted;

        /// <summary>
        /// Occurs when the installation progress changes.
        /// </summary>
        public event EventHandler<InstallationProgressEventArgs> InstallationProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginInstaller"/> class.
        /// </summary>
        public PluginInstaller(IEnumerable<string> pluginFiles)
        {
            foreach (var item in pluginFiles.Select(x => DeploymentContext.Create(x)).Where(y => y != null))
                _plugins.Add(item, true);
        }

        /// <summary>
        /// Installs the plugins.
        /// </summary>
        public void Install()
        {
            if (_installStarted)
                return;
            _installStarted = true;
            var worker = new Action(InstallWorker);
            worker.BeginInvoke(EndInstall, worker);
        }

        /// <summary>
        /// The install worker.
        /// </summary>
        private void InstallWorker()
        {
            var items = new List<DeploymentContext>();
            foreach (var item in _plugins)
            {
                if (item.Value)
                    items.Add(item.Key);
            }

            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                try
                {
                    var tmp = InstallationProgress;
                    if (tmp != null)
                        tmp(this, new InstallationProgressEventArgs(
                            (string)item.PluginDefinition.Title.Localize(),
                            (i * 100) / items.Count
                            ));
                    item.Deploy();
                }
                finally
                {
                    item.Dispose();
                }
            }
            var tmp1 = InstallationProgress;
            if (tmp1 != null)
                tmp1(this, new InstallationProgressEventArgs());
        }

        private void EndInstall(IAsyncResult result)
        {
            ((Action)result.AsyncState).EndInvoke(result);
        }

        /// <summary>
        /// Creates the bootstrap plugin installer.
        /// </summary>
        /// <returns>The bootstrap plugin installer.</returns>
        public static PluginInstaller CreateBootstrap()
        {
            return new PluginInstaller(Directory.GetFiles(Paths.Bootstrap, "*.mfplug"));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<DeploymentContext> GetEnumerator()
        {
            return _plugins.Keys.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _plugins.Keys.GetEnumerator();
        }
    }
}
