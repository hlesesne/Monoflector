using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using mshtml;
using System.IO;
using Monoflector.Runtime;

namespace Monoflector.WindowsForms.Controls {
	public class CodeBrowser : WebBrowser {

		//protected override CreateParams CreateParams {
		//  get {
		//    var parms = base.CreateParams;
		//    parms.Style |= 0x800000;  // Turn on WS_BORDER
		//    return parms;
		//  }
		//}

        

		public void SetContent(String content) {
			HTMLDocument document = this.Document.DomDocument as HTMLDocument;
			HTMLBody body = document.body as HTMLBody;
			IHTMLElementCollection children = body.children as IHTMLElementCollection;
			//IHTMLElement table = document.createElement("pre");
            //table.className = "syntax";
            //table.setAttribute("cellspacing", "0");
            //table.setAttribute("cellpadding", "0");

            // TODO: Remove this hardcoding.
            document.createStyleSheet(Path.Combine(Paths.Root, "CodeStyles", "Default", "default.css"));

			foreach (var child in children) {
				body.removeChild(child as IHTMLDOMNode);
			}

            var sb = new StringBuilder(content.Length);
            sb.Append("<table class=\"syntax\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.Append("<tr>");
            sb.Append(content);
            sb.Append("</tr>");
            sb.Append("</table>");

            body.innerHTML = sb.ToString();
		}
	}
}
