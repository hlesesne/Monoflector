using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using mshtml;

namespace Monoflector.Windows.Controls {
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
			IHTMLElement pre = document.createElement("pre");

			foreach (var child in children) {
				body.removeChild(child as IHTMLDOMNode);
			}

			pre.innerHTML = content;
			body.appendChild(pre as IHTMLDOMNode);
		}

	}
}
