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
using System.ComponentModel.Composition;

namespace Monoflector.Windows
{
    [EnvironmentDependency("WindowsForms")]
    public partial class CodeAstPresenter : UserControl, IAstPresenter
    {
        public string DisplayName
        {
            get { return Properties.Resources.CodeAstPresenterDisplayName; }
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
