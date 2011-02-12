using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Mono.Cecil;

using Monoflector.WindowsForms.Controls;
using Monoflector.WindowsForms.Controls.Panels;

namespace Monoflector.WindowsForms.Forms {
	public partial class Main : Form {

		internal const int foo = 8;

		private SplitterPanel _Dock;
		private Bookmarks _Bookmarks;
		private Decompiler _Decompiler;
		private Search _Search;
		private BitmapList _BitmapList;

		public Main() {
			InitializeComponent();

			_BitmapList = new BitmapList();
			_Dock = _SplitContainer.Panel2;
			_ComboLanguage.SelectedIndex = 0;

			this._Tree.ImageList = _BitmapList.ImageList;
			this._SplitContainer.FixedPanel = FixedPanel.Panel1;

			InitPanels();

			AssemblyDefinition asm = AssemblyDefinition.ReadAssembly(@"C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll");

			_Tree.BeginUpdate();
			_Tree.AddAssembly(asm);
			_Tree.EndUpdate();

			_MenuItemBookmarks.Click += ToggleBookmarks;
			_ButtonBookmarks.Click += ToggleBookmarks;

			_MenuItemDecompiler.Click += ToggleDecompiler;

			_MenuItemSearch.Click += ToggleSearch;
			_ButtonSearch.Click += delegate(object sender, EventArgs e) {
			  if (String.IsNullOrEmpty(_ComboSearch.Text)) {
			    ToggleSearch(sender, e);
			    return;
			  }

				// TODO - make sure the search panel is open and run a search.
			};
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_Tree.DefinitionSelected += _Tree_DefinitionSelected;
			_Tree.DefinitionDoubleClicked += _Tree_DefinitionDoubleClicked;
			_Tree.NodeMouseClick += _Tree_NodeMouseClick;

		}

		protected override void OnSizeChanged(EventArgs e) {
			
			// TODO - resize the panels within _Dock. it's the only part of the dock mechanism not working correctly.
			
			base.OnSizeChanged(e);
		}

		private void InitPanels() {

			_Bookmarks = new Bookmarks();
			_Search = new Search();
			_Decompiler = new Decompiler();
			
			this._SplitContainer.Panel2.SuspendLayout();
			this._SplitContainer.SuspendLayout();
			this.SuspendLayout();

			AddPanel(_Bookmarks);
			AddPanel(_Search);
			AddPanel(_Decompiler);

			_Bookmarks.Visible = _Search.Visible = _Decompiler.Visible = false;
			_SplitContainer.Panel2Collapsed = true;

			this.ResumeLayout(false);
			this._SplitContainer.Panel2.ResumeLayout(false);
			this._SplitContainer.ResumeLayout(false);
		}

		private void AddPanel(DockPanel panel) {

			IEnumerable<Control> controls = _Dock.Controls.Cast<Control>();

			// the order that controls are added matters
			int controlCount = controls.Where(o => o is DockPanel).Count();
			if (controlCount > 0) {
				Splitter splitter = new Splitter() {
					Dock = DockStyle.Top,
					Height = 6
				};
				
				_Dock.Controls.Add(splitter);

				splitter.Visible = false;
				splitter.BringToFront();
			}

			foreach (var control in controls.Where(o => o is DockPanel)) {
				control.Dock = DockStyle.Top;
			}

			// show the splitter
			if (_Dock.Controls.Count > 1) {
				_Dock.Controls[_Dock.Controls.Count - 2].Visible = true;
			}

			_Dock.Controls.Add(panel);

			panel.BringToFront();
			panel.Dock = DockStyle.Fill;

			panel.VisibleChanged += delegate(object sender, EventArgs e) {

				// the way we're adding controls means the last control added is at the beginning of the stack.
				// we have to do that so the controls will layout properly with all the whacky docking going on.

				Splitter splitter = null;

				if (controls.First() == panel) {
					splitter = panel.Next() as Splitter;

					if (panel.Visible) {
						panel.Dock = DockStyle.Fill;
					}

				}
				else {
					if (panel.Visible) {
						panel.Dock = DockStyle.Top;
					}

					splitter = panel.Previous() as Splitter;
				}

				// set the splitter's visibility, if needed
				if (splitter != null) {
					splitter.Visible = panel.Visible;
				}

				if (!panel.Visible) {
					int visibleCount = controls.Where(o => o is DockPanel && o.Visible).Count();
					_SplitContainer.Panel2Collapsed = (visibleCount == 0);
				}
			};

			panel.BeforeVisibleChanged += delegate(object sender, EventArgs e) {
				if ((controls.Where(o => o.Visible).Count() == 0) && !panel.Visible) {
					_SplitContainer.Panel2Collapsed = false;
				}
			};
		}

		private void ToggleBookmarks(object sender, EventArgs e) {
			_Bookmarks.Toggle();
		}

		private void ToggleDecompiler(object sender, EventArgs e) {
			_Decompiler.Toggle();
		}

		private void ToggleSearch(object sender, EventArgs e) {
			_Search.Toggle();
		}

		private IEnumerable<DockPanel> GetPanels() {
			return _Dock.Controls.Cast<Control>().Where(o => o is DockPanel).Select(o => o as DockPanel);
		}

#region .    EventHandlers    

		private void _Tree_DefinitionSelected(object definition){
			IEnumerable<DockPanel> panels = GetPanels();
			foreach (var panel in panels) {
				panel.OnDefinitionSelected(definition);
			}
		}

		private void _Tree_DefinitionDoubleClicked(object definition) {
			IEnumerable<DockPanel> panels = GetPanels();
			foreach (var panel in panels) {
				panel.OnDefinitionDoubleClicked(definition);
			}
		}

		private void _Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				_TreeMenu.Show(_Tree.PointToScreen(e.Location));
			}
		}

#endregion
	}
}
