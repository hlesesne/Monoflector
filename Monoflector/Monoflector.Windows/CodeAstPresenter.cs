using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.Interface;
using Monoflector.Languages;

namespace Monoflector.Windows
{
    public partial class CodeAstPresenter : UserControl, IAstPresenter
    {
        public string DisplayName
        {
            get { return "Code"; }
        }

        public CodeAstPresenter()
        {
            InitializeComponent();
        }

        public void Present(DecompilationTarget node)
        {
            textBox1.Text = node.ToString();
        }
    }
}
