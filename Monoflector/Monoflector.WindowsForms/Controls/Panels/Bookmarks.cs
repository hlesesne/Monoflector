using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monoflector.Controls.Panels {
	public class Bookmarks : DockPanel {
		private ListBox _List;

		public Bookmarks() : base() {
			InitializeComponent();

			this.Text = "Bookmarks";
		}

		private void InitializeComponent() {
			this._List = new System.Windows.Forms.ListBox();
			this._Content.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Content
			// 
			this._Content.Controls.Add(this._List);
			this._Content.Size = new System.Drawing.Size(445, 75);
			// 
			// _List
			// 
			this._List.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._List.Dock = System.Windows.Forms.DockStyle.Fill;
			this._List.FormattingEnabled = true;
			this._List.Location = new System.Drawing.Point(0, 0);
			this._List.Margin = new System.Windows.Forms.Padding(0);
			this._List.Name = "_List";
			this._List.Size = new System.Drawing.Size(443, 73);
			this._List.TabIndex = 0;
			// 
			// Bookmarks
			// 
			this.Name = "Bookmarks";
			this.Size = new System.Drawing.Size(445, 100);
			this._Content.ResumeLayout(false);
			this.ResumeLayout(false);

		}

	}
}
