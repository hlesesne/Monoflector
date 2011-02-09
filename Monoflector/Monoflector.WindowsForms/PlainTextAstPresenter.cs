using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.Interface;
using System.ComponentModel.Composition;

namespace Monoflector
{
    [EnvironmentDependency("Windows")]
    [EnvironmentDependency("WindowsForms")]
    public partial class PlainTextAstPresenter : UserControl, IAstPresenter
    {
        public string DisplayName
        {
            get { return Properties.Resources.PlainTextAstPresenter; }
        }

        public PlainTextAstPresenter()
        {
            InitializeComponent();
        }

        public void Present(Languages.DecompilationTarget node)
        {
            textBox1.Text = node.ToString("text/plain");
        }
    }
}
