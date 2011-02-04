using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.Composition.Hosting;

namespace Monoflector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // CompositionContainer will automatically dispose children.
            using (CreateContainer())
            using (var frm = new MainForm())
            {
                ApplicationContext.Instance.Initialize();
                Application.Run(frm);
            }
        }

        /// <summary>
        /// Creates the composition container.
        /// </summary>
        /// <returns>The composition container.</returns>
        private static CompositionContainer CreateContainer()
        {
            var cat1 = new DirectoryCatalog(".\\plugins");
            var cat2 = new AssemblyCatalog(typeof(Program).Assembly);
            var cat = new AggregateCatalog(cat1, cat2);
            var cont = new CompositionContainer(cat);
            CompositionServices.Initialize(cont);
            return cont;
        }
    }
}
