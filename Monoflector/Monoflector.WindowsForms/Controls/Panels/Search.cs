using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Monoflector.Windows.Controls;
using Monoflector.Windows.Controls.Panels;

namespace Monoflector.Windows.Controls.Panels {
	public class Search : DockPanel {
		private ListView _List;
		private ColumnHeader _HeaderType;
		private ColumnHeader _HeaderNamespace;
		private ColumnHeader _HeaderAssembly;

		public Search() : base() {
			InitializeComponent();

			this.Text = "Search";
		}

		private void InitializeComponent() {
			this._List = new System.Windows.Forms.ListView();
			this._HeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._HeaderNamespace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._HeaderAssembly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._Content.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Content
			// 
			this._Content.Controls.Add(this._List);
			this._Content.Size = new System.Drawing.Size(445, 95);
			// 
			// _List
			// 
			this._List.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._HeaderType,
            this._HeaderNamespace,
            this._HeaderAssembly});
			this._List.Dock = System.Windows.Forms.DockStyle.Fill;
			this._List.FullRowSelect = true;
			this._List.Location = new System.Drawing.Point(0, 0);
			this._List.MultiSelect = false;
			this._List.Name = "_List";
			this._List.ShowGroups = false;
			this._List.Size = new System.Drawing.Size(443, 93);
			this._List.TabIndex = 0;
			this._List.UseCompatibleStateImageBehavior = false;
			this._List.View = System.Windows.Forms.View.List;
			// 
			// _HeaderType
			// 
			this._HeaderType.Text = "Type Name";
			// 
			// _HeaderNamespace
			// 
			this._HeaderNamespace.Text = "Namespace";
			// 
			// _HeaderAssembly
			// 
			this._HeaderAssembly.Text = "Assembly";
			// 
			// Search
			// 
			this.Name = "Search";
			this.Size = new System.Drawing.Size(445, 120);
			this._Content.ResumeLayout(false);
			this.ResumeLayout(false);

		}

	}
}
