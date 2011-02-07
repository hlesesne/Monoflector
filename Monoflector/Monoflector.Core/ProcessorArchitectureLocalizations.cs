using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Monoflector
{
    class ProcessorArchitectureLocalizations
    {
        [EnumLocalExport(typeof(ProcessorArchitecture), "None")]
        public string None
        {
            get
            {
                return Properties.Resources.ProcessorArchitecture_None;
            }
        }

        [EnumLocalExport(typeof(ProcessorArchitecture), "MSIL")]
        public string MSIL
        {
            get
            {
                return Properties.Resources.ProcessorArchitecture_MSIL;
            }
        }

        [EnumLocalExport(typeof(ProcessorArchitecture), "X86")]
        public string X86
        {
            get
            {
                return Properties.Resources.ProcessorArchitecture_X86;
            }
        }

        [EnumLocalExport(typeof(ProcessorArchitecture), "Amd64")]
        public string Amd64
        {
            get
            {
                return Properties.Resources.ProcessorArchitecture_Amd64;
            }
        }

        [EnumLocalExport(typeof(ProcessorArchitecture), "IA64")]
        public string IA64
        {
            get
            {
                return Properties.Resources.ProcessorArchitecture_IA64;
            }
        }
    }
}
