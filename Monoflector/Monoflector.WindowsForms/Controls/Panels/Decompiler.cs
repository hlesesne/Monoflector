using Cecil.Decompiler.Languages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Cecil;

using Monoflector.WindowsForms.Controls;
using Monoflector.WindowsForms.Controls.Panels;

namespace Monoflector.WindowsForms.Controls.Panels {
    public class Decompiler : DockPanel
    {
        private CodeBrowser _Browser;

		public Decompiler() : base() {
			this.Text = "Decompiler";

			InitializeComponent();

			_Browser.Navigate("about:blank");
		}

		private void InitializeComponent() {
            this._Browser = new Monoflector.WindowsForms.Controls.CodeBrowser();
            this._Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Content
            // 
            this._Content.Controls.Add(this._Browser);
            this._Content.Padding = new System.Windows.Forms.Padding(2);
            this._Content.Size = new System.Drawing.Size(455, 157);
            // 
            // _Browser
            // 
            this._Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Browser.Location = new System.Drawing.Point(2, 2);
            this._Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this._Browser.Name = "_Browser";
            this._Browser.Size = new System.Drawing.Size(449, 151);
            this._Browser.TabIndex = 1;
            // 
            // Decompiler
            // 
            this.Name = "Decompiler";
            this.Size = new System.Drawing.Size(455, 182);
            this._Content.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		public override void OnDefinitionSelected(object definition) {

			//var def = definition as MethodDefinition;
			var target = ApplicationContext.Instance.SelectedLanguage.CreateDecompilationTarget();
				
			try {
                target.WriteDefinition(definition);
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
