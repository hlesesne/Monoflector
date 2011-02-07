using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector
{
    static class WindowsInitialization
    {
        private static bool _hasInitialized;

        public static void Initialize()
        {
            if (!_hasInitialized)
            {
                _hasInitialized = true;
                Application.SetCompatibleTextRenderingDefault(true);
                Application.EnableVisualStyles();
            }
        }
    }
}
