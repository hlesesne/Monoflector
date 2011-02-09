using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monoflector.Interface;
using System.IO;

namespace Monoflector
{
    // TEST: This is test code, kill it.

    public partial class HtmlAstPresenter : UserControl, IAstPresenter
    {
        private static readonly Tuple<string, string, string>[] _coreFiles = new Tuple<string,string, string>[]
        {
            Tuple.Create("shCore", "shCore.css", "stylesheet"),
            Tuple.Create("shCoreDefault", "shCoreDefault.css", "stylesheet")
        };

        public string DisplayName
        {
            get { return "Html"; }
        }

        public HtmlAstPresenter()
        {
            InitializeComponent();
        }

        public void Present(Languages.DecompilationTarget node)
        {
            var dir = PrepFolder();
            var fileName = Path.Combine(dir, "index.htm");
            using (var wr = new StreamWriter(fileName))
            {
                wr.WriteLine("<html>");
                wr.WriteLine("<head>");
                foreach (var file in _coreFiles)
                    wr.WriteLine("<link href=\"{0}\" rel=\"{1}\" type=\"text/css\" />", file.Item2, file.Item3);
                wr.WriteLine("</head>");
                wr.WriteLine("<body>");
                wr.WriteLine("<div class=\"syntaxhighlighter csharp ie\">");
                wr.WriteLine("<table border=\"0\" cellSpacing=\"0\" cellPadding=\"0\"><tr>");
                wr.WriteLine(node.ToString("text/html"));
                wr.WriteLine("</tr></table>");
                wr.WriteLine("</body>");
            }
            webBrowser1.Navigate(fileName);
        }

        private static string PrepFolder()
        {
            var dir = Path.GetTempFileName();
            File.Delete(dir);
            Directory.CreateDirectory(dir);

            foreach (var item in _coreFiles)
            {
                using (var strm = new FileStream(Path.Combine(dir, item.Item2), FileMode.Create))
                {
                    var bytes = (byte[])Properties.Resources.ResourceManager.GetObject(item.Item1);
                    strm.Write(bytes, 0, bytes.Length);
                }

            }
            return dir;
        }
    }
}
