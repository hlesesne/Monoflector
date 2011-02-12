using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Monoflector.WindowsForms.Controls;
using Monoflector.WindowsForms.Controls.Panels;

namespace Monoflector.WindowsForms.Controls.Panels {
	public class Analyzer : DockPanel {
		private TreeView _Tree;

		public Analyzer() : base() {
			InitializeComponent();

			this.Text = "Analyzer";
		}

		private void InitializeComponent() {
			this._Tree = new System.Windows.Forms.TreeView();
			this._Content.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Content
			// 
			this._Content.Controls.Add(this._Tree);
			this._Content.Size = new System.Drawing.Size(445, 75);
			// 
			// _Tree
			// 
			this._Tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this._Tree.Location = new System.Drawing.Point(0, 0);
			this._Tree.Name = "_Tree";
			this._Tree.Size = new System.Drawing.Size(443, 73);
			this._Tree.TabIndex = 0;
			// 
			// Analyzer
			// 
			this.Name = "Analyzer";
			this.Size = new System.Drawing.Size(445, 100);
			this._Content.ResumeLayout(false);
			this.ResumeLayout(false);

		}

	}
}
