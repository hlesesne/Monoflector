using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Gac;
using System.Runtime.InteropServices;
using System.ComponentModel.Composition;
using System.Reflection;
using Mono.Cecil;

namespace Monoflector.Windows
{
    /// <summary>
    /// Represents the GAC assembly provider.
    /// </summary>
    [EnvironmentDependency("Windows")]
    public class GacAssemblyProvider : IAssemblyProvider
    {
        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        public string Name
        {
            get
            {
                return Monoflector.Windows.Properties.Resources.GAC;
            }
        }

        /// <summary>
        /// Occurs when an exception is thrown.
        /// </summary>
        public event EventHandler<ValueEventArgs<Exception>> ExceptionThrown;

        /// <summary>
        /// Occurs when an assembly has been discovered.
        /// </summary>
        public event EventHandler<ValueEventArgs<ILightAssembly>> AssemblyDiscovered;
        private int _cookie;

        /// <summary>
        /// Resets the provider and starts enumerating
        /// assemblies on a separate thread.
        /// </summary>
        public void Start()
        {
            var cookie = ++_cookie;
            var worker = new Action<int>(Worker);
            worker.BeginInvoke(cookie, EndWorker, worker);
        }

        /// <summary>
        /// Halts enumerating assemblies.
        /// </summary>
        public void Stop()
        {
            _cookie++;
        }

        /// <summary>
        /// Loads an assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>
        /// The assembly.
        /// </returns>
        public AssemblyDefinition LoadAssembly(ILightAssembly assembly)
        {
            var gac = assembly as GacAssembly;
            if (gac == null)
                throw new ArgumentOutOfRangeException("assembly", Properties.Resources.IncorrectAssemblyType);
            return GlobalAssemblyResolver.Instance.Resolve(gac.AssemblyName.FullName);
        }

        private void Worker(int cookie)
        {
            var enm = AssemblyCache.CreateGACEnum();
            enm.Reset();
            IAssemblyName name;
            while (AssemblyCache.GetNextAssembly(enm, out name) == 0 && _cookie == cookie)
            {
                AssemblyName an;
                try
                {
                    an = GetAssemblyName(name);
                }
                catch(Exception ex)
                {
                    var exEvt = ExceptionThrown;
                    if (exEvt != null && _cookie == cookie)
                        exEvt(this, new ValueEventArgs<Exception>(ex));
                    continue;
                }
                var tmp = AssemblyDiscovered;
                if (tmp != null && _cookie == cookie)
                    tmp(this, new ValueEventArgs<ILightAssembly>(new GacAssembly(this, an)));
            }
        }

        private AssemblyName GetAssemblyName(IAssemblyName nameRef)
        {
            //AssemblyName name = new AssemblyName();
            //name.Name = AssemblyCache.GetName(nameRef);
            //name.Version = AssemblyCache.GetVersion(nameRef);
            //name.CultureInfo = AssemblyCache.GetCulture(nameRef);
            //name.SetPublicKeyToken(AssemblyCache.GetPublicKeyToken(nameRef));
            var name = new AssemblyName(AssemblyCache.GetDisplayName(nameRef,
                ASM_DISPLAY_FLAGS.CULTURE | ASM_DISPLAY_FLAGS.CUSTOM | ASM_DISPLAY_FLAGS.LANGUAGEID | ASM_DISPLAY_FLAGS.PROCESSORARCHITECTURE
                | ASM_DISPLAY_FLAGS.PUBLIC_KEY | ASM_DISPLAY_FLAGS.PUBLIC_KEY_TOKEN | ASM_DISPLAY_FLAGS.VERSION));
            return name;
        }

        private void EndWorker(IAsyncResult result)
        {
            try
            {
                ((Action<int>)result.AsyncState).EndInvoke(result);
            }
            catch(Exception ex)
            {
                var exEvt = ExceptionThrown;
                if (exEvt != null)
                    exEvt(this, new ValueEventArgs<Exception>(ex));
            }
        }
    }
}
