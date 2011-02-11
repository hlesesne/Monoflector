using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Monoflector
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> that supports
    /// a watermark.
    /// </summary>
    public class WatermarkBox : TextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        private string _watermark;
        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>
        /// The watermark.
        /// </value>
        public string Watermark
        {
            get
            {
                return _watermark;
            }
            set
            {
                _watermark = value;
                SendMessage(this.Handle, EM_SETCUEBANNER, 0, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkBox"/> class.
        /// </summary>
        public WatermarkBox()
        {
            
        }
    }
}
