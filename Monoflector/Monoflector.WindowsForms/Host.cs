using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monoflector.Runtime;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace Monoflector
{
    /// <summary>
    /// Represents the Monoflector Windows Forms host.
    /// </summary>
    [EnvironmentDependency("Windows")]
    [EnvironmentDependency("WindowsForms")]
    public class Host : IMonoflectorHost
    {
        /// <summary>
        /// Runs the monoflector host.
        /// </summary>
        /// <param name="commandlineArguments">The command line arguments.</param>
        public void Run(string[] commandlineArguments)
        {
            WindowsInitialization.Initialize();

            using (var frm = new MainForm())
            {
                ApplicationContext.Instance.Initialize();
                Application.Run(frm);
            }
        }
    }
}
