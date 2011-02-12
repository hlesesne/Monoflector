using Cecil.Decompiler.Languages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Cecil;

using Monoflector.WindowsForms.Controls;
using Monoflector.WindowsForms.Controls.Panels;

namespace Monoflector.WindowsForms.Controls.Panels {
	public class Decompiler : DockPanel {
		private XPTabControl _Tabs;
		private System.Windows.Forms.TabPage _TabHtml;
		private CodeBrowser _Browser;
		private System.Windows.Forms.TabPage _TabIL;

		public Decompiler() : base() {
			this.Text = "Decompiler";

			InitializeComponent();

			_Browser.Navigate("about:blank");
		}

		private void InitializeComponent() {
			this._Tabs = new Monoflector.WindowsForms.Controls.XPTabControl();
			this._TabHtml = new System.Windows.Forms.TabPage();
			this._Browser = new Monoflector.WindowsForms.Controls.CodeBrowser();
			this._TabIL = new System.Windows.Forms.TabPage();
			this._Content.SuspendLayout();
			this._Tabs.SuspendLayout();
			this._TabHtml.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Content
			// 
			this._Content.Controls.Add(this._Tabs);
			this._Content.Padding = new System.Windows.Forms.Padding(2);
			this._Content.Size = new System.Drawing.Size(455, 157);
			// 
			// _Tabs
			// 
			this._Tabs.Controls.Add(this._TabHtml);
			this._Tabs.Controls.Add(this._TabIL);
			this._Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this._Tabs.Location = new System.Drawing.Point(2, 2);
			this._Tabs.Name = "_Tabs";
			this._Tabs.SelectedIndex = 0;
			this._Tabs.Size = new System.Drawing.Size(449, 151);
			this._Tabs.TabIndex = 1;
			// 
			// _TabHtml
			// 
			this._TabHtml.Controls.Add(this._Browser);
			this._TabHtml.Location = new System.Drawing.Point(4, 4);
			this._TabHtml.Name = "_TabHtml";
			this._TabHtml.Padding = new System.Windows.Forms.Padding(3);
			this._TabHtml.Size = new System.Drawing.Size(441, 125);
			this._TabHtml.TabIndex = 0;
			this._TabHtml.Text = "Code";
			this._TabHtml.UseVisualStyleBackColor = true;
			// 
			// _Browser
			// 
			this._Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this._Browser.Location = new System.Drawing.Point(3, 3);
			this._Browser.MinimumSize = new System.Drawing.Size(20, 20);
			this._Browser.Name = "_Browser";
			this._Browser.Size = new System.Drawing.Size(435, 119);
			this._Browser.TabIndex = 0;
			// 
			// _TabIL
			// 
			this._TabIL.Location = new System.Drawing.Point(4, 4);
			this._TabIL.Name = "_TabIL";
			this._TabIL.Size = new System.Drawing.Size(441, 321);
			this._TabIL.TabIndex = 2;
			this._TabIL.Text = "IL";
			this._TabIL.UseVisualStyleBackColor = true;
			// 
			// Decompiler
			// 
			this.Name = "Decompiler";
			this.Size = new System.Drawing.Size(455, 182);
			this._Content.ResumeLayout(false);
			this._Tabs.ResumeLayout(false);
			this._TabHtml.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		public override void OnDefinitionSelected(object definition) {

			//var def = definition as MethodDefinition;
			var target = ApplicationContext.Instance.SelectedLanguage.CreateDecompilationTarget();
				
			try {
				((ILanguageWriter)target).Write(definition);
			}
			catch {
			}
			String content = target.ToString("text/html");

			if (String.IsNullOrEmpty(content)) {
				content = "The decompiler was unable to generate source code for the requested object.";
			}

			_Browser.SetContent(content);
		}

		public override void OnDefinitionDoubleClicked(object definition) {
			this.Visible = true;
		}

	}
}
