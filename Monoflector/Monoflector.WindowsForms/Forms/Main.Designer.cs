﻿namespace Monoflector.Forms {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._SplitContainer = new System.Windows.Forms.SplitContainer();
            this._SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this._Tree = new Monoflector.Windows.Controls.AssemblyTree();
            this._BrowserObject = new Monoflector.Windows.Controls.CodeBrowser();
            this._Container = new System.Windows.Forms.ToolStripContainer();
            this._Status = new System.Windows.Forms.StatusStrip();
            this._MenuStrip = new System.Windows.Forms.MenuStrip();
            this._MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemOpenGac = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuItemBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemBookmarkRemove = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuItemGoogle = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemMsdn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuView = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemBookmarks = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemDecompiler = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemAnalyzer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuItemPrefs = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuItemHelpDummy = new System.Windows.Forms.ToolStripMenuItem();
            this._ButtonStrip = new System.Windows.Forms.ToolStrip();
            this._ButtonOpen = new System.Windows.Forms.ToolStripSplitButton();
            this._ButtonItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._ButtonItemOpenGac = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._ButtonBack = new System.Windows.Forms.ToolStripButton();
            this._ButtonForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._ButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._ButtonBookmarks = new System.Windows.Forms.ToolStripButton();
            this._ComboSearch = new System.Windows.Forms.ToolStripComboBox();
            this._ButtonSearch = new System.Windows.Forms.ToolStripButton();
            this._ComboLanguage = new System.Windows.Forms.ToolStripComboBox();
            this._TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._PopItemBack = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemForward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._PopItemDecompile = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemAnalyze = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._PopItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemBookmarkAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemBookmarkRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this._PopItemGoogle = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemMsdn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._PopItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemBaseType = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemFieldType = new System.Windows.Forms.ToolStripMenuItem();
            this._PopItemPropertyType = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainer)).BeginInit();
            this._SplitContainer.Panel1.SuspendLayout();
            this._SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainerLeft)).BeginInit();
            this._SplitContainerLeft.Panel1.SuspendLayout();
            this._SplitContainerLeft.Panel2.SuspendLayout();
            this._SplitContainerLeft.SuspendLayout();
            this._Container.BottomToolStripPanel.SuspendLayout();
            this._Container.ContentPanel.SuspendLayout();
            this._Container.TopToolStripPanel.SuspendLayout();
            this._Container.SuspendLayout();
            this._MenuStrip.SuspendLayout();
            this._ButtonStrip.SuspendLayout();
            this._TreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _SplitContainer
            // 
            this._SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._SplitContainer.Location = new System.Drawing.Point(0, 0);
            this._SplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._SplitContainer.Name = "_SplitContainer";
            // 
            // _SplitContainer.Panel1
            // 
            this._SplitContainer.Panel1.Controls.Add(this._SplitContainerLeft);
            this._SplitContainer.Panel2Collapsed = true;
            this._SplitContainer.Size = new System.Drawing.Size(517, 526);
            this._SplitContainer.SplitterDistance = 365;
            this._SplitContainer.TabIndex = 2;
            // 
            // _SplitContainerLeft
            // 
            this._SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._SplitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this._SplitContainerLeft.Name = "_SplitContainerLeft";
            this._SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _SplitContainerLeft.Panel1
            // 
            this._SplitContainerLeft.Panel1.Controls.Add(this._Tree);
            // 
            // _SplitContainerLeft.Panel2
            // 
            this._SplitContainerLeft.Panel2.Controls.Add(this._BrowserObject);
            this._SplitContainerLeft.Size = new System.Drawing.Size(517, 526);
            this._SplitContainerLeft.SplitterDistance = 408;
            this._SplitContainerLeft.TabIndex = 0;
            // 
            // _Tree
            // 
            this._Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tree.HotTracking = true;
            this._Tree.ItemHeight = 20;
            this._Tree.Location = new System.Drawing.Point(0, 0);
            this._Tree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._Tree.Name = "_Tree";
            this._Tree.ShowLines = false;
            this._Tree.ShowNodeToolTips = true;
            this._Tree.Size = new System.Drawing.Size(517, 408);
            this._Tree.TabIndex = 0;
            // 
            // _BrowserObject
            // 
            this._BrowserObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this._BrowserObject.Location = new System.Drawing.Point(0, 0);
            this._BrowserObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._BrowserObject.MinimumSize = new System.Drawing.Size(23, 23);
            this._BrowserObject.Name = "_BrowserObject";
            this._BrowserObject.Size = new System.Drawing.Size(517, 114);
            this._BrowserObject.TabIndex = 0;
            // 
            // _Container
            // 
            // 
            // _Container.BottomToolStripPanel
            // 
            this._Container.BottomToolStripPanel.Controls.Add(this._Status);
            // 
            // _Container.ContentPanel
            // 
            this._Container.ContentPanel.Controls.Add(this._SplitContainer);
            this._Container.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._Container.ContentPanel.Size = new System.Drawing.Size(517, 526);
            this._Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Container.Location = new System.Drawing.Point(0, 0);
            this._Container.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._Container.Name = "_Container";
            this._Container.Size = new System.Drawing.Size(517, 597);
            this._Container.TabIndex = 4;
            // 
            // _Container.TopToolStripPanel
            // 
            this._Container.TopToolStripPanel.Controls.Add(this._MenuStrip);
            this._Container.TopToolStripPanel.Controls.Add(this._ButtonStrip);
            // 
            // _Status
            // 
            this._Status.Dock = System.Windows.Forms.DockStyle.None;
            this._Status.Location = new System.Drawing.Point(0, 0);
            this._Status.Name = "_Status";
            this._Status.Size = new System.Drawing.Size(517, 22);
            this._Status.TabIndex = 4;
            // 
            // _MenuStrip
            // 
            this._MenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuFile,
            this._MenuView,
            this._MenuHelp});
            this._MenuStrip.Location = new System.Drawing.Point(0, 0);
            this._MenuStrip.Name = "_MenuStrip";
            this._MenuStrip.Size = new System.Drawing.Size(517, 24);
            this._MenuStrip.TabIndex = 4;
            // 
            // _MenuFile
            // 
            this._MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemOpen,
            this._MenuItemOpenGac,
            this.toolStripMenuItem1,
            this._MenuItemBookmark,
            this._MenuItemBookmarkRemove,
            this._MenuItemClose,
            this.toolStripMenuItem2,
            this._MenuItemGoogle,
            this._MenuItemMsdn,
            this.toolStripSeparator1,
            this._MenuItemExit});
            this._MenuFile.Name = "_MenuFile";
            this._MenuFile.Size = new System.Drawing.Size(37, 20);
            this._MenuFile.Text = "&File";
            // 
            // _MenuItemOpen
            // 
            this._MenuItemOpen.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemOpen.Image")));
            this._MenuItemOpen.Name = "_MenuItemOpen";
            this._MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._MenuItemOpen.Size = new System.Drawing.Size(243, 22);
            this._MenuItemOpen.Text = "&Open File...";
            // 
            // _MenuItemOpenGac
            // 
            this._MenuItemOpenGac.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemOpenGac.Image")));
            this._MenuItemOpenGac.Name = "_MenuItemOpenGac";
            this._MenuItemOpenGac.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this._MenuItemOpenGac.Size = new System.Drawing.Size(243, 22);
            this._MenuItemOpenGac.Text = "Open from &GAC...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 6);
            // 
            // _MenuItemBookmark
            // 
            this._MenuItemBookmark.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemBookmark.Image")));
            this._MenuItemBookmark.Name = "_MenuItemBookmark";
            this._MenuItemBookmark.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._MenuItemBookmark.Size = new System.Drawing.Size(243, 22);
            this._MenuItemBookmark.Text = "&Bookmark";
            // 
            // _MenuItemBookmarkRemove
            // 
            this._MenuItemBookmarkRemove.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemBookmarkRemove.Image")));
            this._MenuItemBookmarkRemove.Name = "_MenuItemBookmarkRemove";
            this._MenuItemBookmarkRemove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._MenuItemBookmarkRemove.Size = new System.Drawing.Size(243, 22);
            this._MenuItemBookmarkRemove.Text = "&Remove Bookmark";
            this._MenuItemBookmarkRemove.Visible = false;
            // 
            // _MenuItemClose
            // 
            this._MenuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemClose.Image")));
            this._MenuItemClose.Name = "_MenuItemClose";
            this._MenuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this._MenuItemClose.Size = new System.Drawing.Size(243, 22);
            this._MenuItemClose.Text = "&Close Assembly";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 6);
            // 
            // _MenuItemGoogle
            // 
            this._MenuItemGoogle.Name = "_MenuItemGoogle";
            this._MenuItemGoogle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this._MenuItemGoogle.Size = new System.Drawing.Size(243, 22);
            this._MenuItemGoogle.Text = "Search Google";
            // 
            // _MenuItemMsdn
            // 
            this._MenuItemMsdn.Name = "_MenuItemMsdn";
            this._MenuItemMsdn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.F3)));
            this._MenuItemMsdn.Size = new System.Drawing.Size(243, 22);
            this._MenuItemMsdn.Text = "Search MSDN";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // _MenuItemExit
            // 
            this._MenuItemExit.Name = "_MenuItemExit";
            this._MenuItemExit.Size = new System.Drawing.Size(243, 22);
            this._MenuItemExit.Text = "E&xit";
            // 
            // _MenuView
            // 
            this._MenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemBookmarks,
            this._MenuItemSearch,
            this._MenuItemDecompiler,
            this._MenuItemAnalyzer,
            this.toolStripMenuItem7,
            this._MenuItemPrefs});
            this._MenuView.Name = "_MenuView";
            this._MenuView.Size = new System.Drawing.Size(44, 20);
            this._MenuView.Text = "View";
            // 
            // _MenuItemBookmarks
            // 
            this._MenuItemBookmarks.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemBookmarks.Image")));
            this._MenuItemBookmarks.Name = "_MenuItemBookmarks";
            this._MenuItemBookmarks.Size = new System.Drawing.Size(135, 22);
            this._MenuItemBookmarks.Text = "&Bookmarks";
            // 
            // _MenuItemSearch
            // 
            this._MenuItemSearch.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemSearch.Image")));
            this._MenuItemSearch.Name = "_MenuItemSearch";
            this._MenuItemSearch.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this._MenuItemSearch.Size = new System.Drawing.Size(135, 22);
            this._MenuItemSearch.Text = "&Search";
            // 
            // _MenuItemDecompiler
            // 
            this._MenuItemDecompiler.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemDecompiler.Image")));
            this._MenuItemDecompiler.Name = "_MenuItemDecompiler";
            this._MenuItemDecompiler.Size = new System.Drawing.Size(135, 22);
            this._MenuItemDecompiler.Text = "&Decompiler";
            // 
            // _MenuItemAnalyzer
            // 
            this._MenuItemAnalyzer.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemAnalyzer.Image")));
            this._MenuItemAnalyzer.Name = "_MenuItemAnalyzer";
            this._MenuItemAnalyzer.Size = new System.Drawing.Size(135, 22);
            this._MenuItemAnalyzer.Text = "&Analyzer";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(132, 6);
            // 
            // _MenuItemPrefs
            // 
            this._MenuItemPrefs.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemPrefs.Image")));
            this._MenuItemPrefs.Name = "_MenuItemPrefs";
            this._MenuItemPrefs.Size = new System.Drawing.Size(135, 22);
            this._MenuItemPrefs.Text = "&Preferences";
            // 
            // _MenuHelp
            // 
            this._MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemHelpDummy});
            this._MenuHelp.Name = "_MenuHelp";
            this._MenuHelp.Size = new System.Drawing.Size(44, 20);
            this._MenuHelp.Text = "Help";
            // 
            // _MenuItemHelpDummy
            // 
            this._MenuItemHelpDummy.Image = ((System.Drawing.Image)(resources.GetObject("_MenuItemHelpDummy.Image")));
            this._MenuItemHelpDummy.Name = "_MenuItemHelpDummy";
            this._MenuItemHelpDummy.Size = new System.Drawing.Size(147, 22);
            this._MenuItemHelpDummy.Text = "Dummy Entry";
            // 
            // _ButtonStrip
            // 
            this._ButtonStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._ButtonStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ButtonOpen,
            this.toolStripSeparator2,
            this._ButtonBack,
            this._ButtonForward,
            this.toolStripSeparator3,
            this._ButtonRefresh,
            this.toolStripSeparator4,
            this._ButtonBookmarks,
            this._ComboSearch,
            this._ButtonSearch,
            this._ComboLanguage});
            this._ButtonStrip.Location = new System.Drawing.Point(0, 24);
            this._ButtonStrip.Name = "_ButtonStrip";
            this._ButtonStrip.Size = new System.Drawing.Size(517, 25);
            this._ButtonStrip.Stretch = true;
            this._ButtonStrip.TabIndex = 3;
            // 
            // _ButtonOpen
            // 
            this._ButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ButtonItemOpen,
            this._ButtonItemOpenGac});
            this._ButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonOpen.Image")));
            this._ButtonOpen.Name = "_ButtonOpen";
            this._ButtonOpen.Size = new System.Drawing.Size(32, 22);
            this._ButtonOpen.Text = "Open...";
            // 
            // _ButtonItemOpen
            // 
            this._ButtonItemOpen.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonItemOpen.Image")));
            this._ButtonItemOpen.Name = "_ButtonItemOpen";
            this._ButtonItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._ButtonItemOpen.Size = new System.Drawing.Size(243, 22);
            this._ButtonItemOpen.Text = "&Open File...";
            // 
            // _ButtonItemOpenGac
            // 
            this._ButtonItemOpenGac.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonItemOpenGac.Image")));
            this._ButtonItemOpenGac.Name = "_ButtonItemOpenGac";
            this._ButtonItemOpenGac.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this._ButtonItemOpenGac.Size = new System.Drawing.Size(243, 22);
            this._ButtonItemOpenGac.Text = "Open from &GAC...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _ButtonBack
            // 
            this._ButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonBack.Image")));
            this._ButtonBack.Name = "_ButtonBack";
            this._ButtonBack.Size = new System.Drawing.Size(23, 22);
            this._ButtonBack.Text = "Back";
            // 
            // _ButtonForward
            // 
            this._ButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonForward.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonForward.Image")));
            this._ButtonForward.Name = "_ButtonForward";
            this._ButtonForward.Size = new System.Drawing.Size(23, 22);
            this._ButtonForward.Text = "Forward";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // _ButtonRefresh
            // 
            this._ButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonRefresh.Image")));
            this._ButtonRefresh.Name = "_ButtonRefresh";
            this._ButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this._ButtonRefresh.Text = "Refresh";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // _ButtonBookmarks
            // 
            this._ButtonBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonBookmarks.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonBookmarks.Image")));
            this._ButtonBookmarks.Name = "_ButtonBookmarks";
            this._ButtonBookmarks.Size = new System.Drawing.Size(23, 22);
            this._ButtonBookmarks.Text = "Bookmarks";
            // 
            // _ComboSearch
            // 
            this._ComboSearch.DropDownWidth = 200;
            this._ComboSearch.Name = "_ComboSearch";
            this._ComboSearch.Size = new System.Drawing.Size(200, 25);
            // 
            // _ButtonSearch
            // 
            this._ButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonSearch.Image")));
            this._ButtonSearch.Name = "_ButtonSearch";
            this._ButtonSearch.Size = new System.Drawing.Size(23, 22);
            this._ButtonSearch.Text = "Search";
            // 
            // _ComboLanguage
            // 
            this._ComboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ComboLanguage.Items.AddRange(new object[] {
            "C#",
            "VB.NET"});
            this._ComboLanguage.Name = "_ComboLanguage";
            this._ComboLanguage.Size = new System.Drawing.Size(121, 25);
            // 
            // _TreeMenu
            // 
            this._TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._PopItemBack,
            this._PopItemForward,
            this.toolStripSeparator6,
            this._PopItemDecompile,
            this._PopItemAnalyze,
            this._PopItemExport,
            this.toolStripSeparator5,
            this._PopItemCopy,
            this._PopItemBookmarkAdd,
            this._PopItemBookmarkRemove,
            this.toolStripMenuItem5,
            this._PopItemGoogle,
            this._PopItemMsdn,
            this.toolStripSeparator7,
            this._PopItemClose,
            this._PopItemBaseType,
            this._PopItemFieldType,
            this._PopItemPropertyType});
            this._TreeMenu.Name = "_TreeMenu";
            this._TreeMenu.Size = new System.Drawing.Size(225, 336);
            // 
            // _PopItemBack
            // 
            this._PopItemBack.Name = "_PopItemBack";
            this._PopItemBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this._PopItemBack.Size = new System.Drawing.Size(224, 22);
            this._PopItemBack.Text = "&Back";
            // 
            // _PopItemForward
            // 
            this._PopItemForward.Name = "_PopItemForward";
            this._PopItemForward.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this._PopItemForward.Size = new System.Drawing.Size(224, 22);
            this._PopItemForward.Text = "&Forward";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(221, 6);
            // 
            // _PopItemDecompile
            // 
            this._PopItemDecompile.Name = "_PopItemDecompile";
            this._PopItemDecompile.Size = new System.Drawing.Size(224, 22);
            this._PopItemDecompile.Text = "&Decompile";
            // 
            // _PopItemAnalyze
            // 
            this._PopItemAnalyze.Name = "_PopItemAnalyze";
            this._PopItemAnalyze.Size = new System.Drawing.Size(224, 22);
            this._PopItemAnalyze.Text = "&Analyze";
            // 
            // _PopItemExport
            // 
            this._PopItemExport.Name = "_PopItemExport";
            this._PopItemExport.Size = new System.Drawing.Size(224, 22);
            this._PopItemExport.Text = "&Export...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(221, 6);
            // 
            // _PopItemCopy
            // 
            this._PopItemCopy.Name = "_PopItemCopy";
            this._PopItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._PopItemCopy.Size = new System.Drawing.Size(224, 22);
            this._PopItemCopy.Text = "Co&py";
            // 
            // _PopItemBookmarkAdd
            // 
            this._PopItemBookmarkAdd.Image = ((System.Drawing.Image)(resources.GetObject("_PopItemBookmarkAdd.Image")));
            this._PopItemBookmarkAdd.Name = "_PopItemBookmarkAdd";
            this._PopItemBookmarkAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._PopItemBookmarkAdd.Size = new System.Drawing.Size(224, 22);
            this._PopItemBookmarkAdd.Text = "&Bookmark";
            // 
            // _PopItemBookmarkRemove
            // 
            this._PopItemBookmarkRemove.Image = ((System.Drawing.Image)(resources.GetObject("_PopItemBookmarkRemove.Image")));
            this._PopItemBookmarkRemove.Name = "_PopItemBookmarkRemove";
            this._PopItemBookmarkRemove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._PopItemBookmarkRemove.Size = new System.Drawing.Size(224, 22);
            this._PopItemBookmarkRemove.Text = "&Remove Bookmark";
            this._PopItemBookmarkRemove.Visible = false;
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(221, 6);
            // 
            // _PopItemGoogle
            // 
            this._PopItemGoogle.Name = "_PopItemGoogle";
            this._PopItemGoogle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this._PopItemGoogle.Size = new System.Drawing.Size(224, 22);
            this._PopItemGoogle.Text = "Search Google";
            // 
            // _PopItemMsdn
            // 
            this._PopItemMsdn.Name = "_PopItemMsdn";
            this._PopItemMsdn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.F3)));
            this._PopItemMsdn.Size = new System.Drawing.Size(224, 22);
            this._PopItemMsdn.Text = "Search MSDN";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(221, 6);
            // 
            // _PopItemClose
            // 
            this._PopItemClose.Image = ((System.Drawing.Image)(resources.GetObject("_PopItemClose.Image")));
            this._PopItemClose.Name = "_PopItemClose";
            this._PopItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this._PopItemClose.Size = new System.Drawing.Size(224, 22);
            this._PopItemClose.Text = "&Close Assembly";
            // 
            // _PopItemBaseType
            // 
            this._PopItemBaseType.Name = "_PopItemBaseType";
            this._PopItemBaseType.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this._PopItemBaseType.Size = new System.Drawing.Size(224, 22);
            this._PopItemBaseType.Text = "Go to Base &Type";
            // 
            // _PopItemFieldType
            // 
            this._PopItemFieldType.Name = "_PopItemFieldType";
            this._PopItemFieldType.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this._PopItemFieldType.Size = new System.Drawing.Size(224, 22);
            this._PopItemFieldType.Text = "Go to Field &Type";
            // 
            // _PopItemPropertyType
            // 
            this._PopItemPropertyType.Name = "_PopItemPropertyType";
            this._PopItemPropertyType.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this._PopItemPropertyType.Size = new System.Drawing.Size(224, 22);
            this._PopItemPropertyType.Text = "Go to Property &Type";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 597);
            this.Controls.Add(this._Container);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Monoflector";
            this._SplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainer)).EndInit();
            this._SplitContainer.ResumeLayout(false);
            this._SplitContainerLeft.Panel1.ResumeLayout(false);
            this._SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainerLeft)).EndInit();
            this._SplitContainerLeft.ResumeLayout(false);
            this._Container.BottomToolStripPanel.ResumeLayout(false);
            this._Container.BottomToolStripPanel.PerformLayout();
            this._Container.ContentPanel.ResumeLayout(false);
            this._Container.TopToolStripPanel.ResumeLayout(false);
            this._Container.TopToolStripPanel.PerformLayout();
            this._Container.ResumeLayout(false);
            this._Container.PerformLayout();
            this._MenuStrip.ResumeLayout(false);
            this._MenuStrip.PerformLayout();
            this._ButtonStrip.ResumeLayout(false);
            this._ButtonStrip.PerformLayout();
            this._TreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer _SplitContainer;
		private Monoflector.Windows.Controls.AssemblyTree _Tree;
		private Monoflector.Windows.Controls.CodeBrowser _BrowserObject;
		private System.Windows.Forms.ToolStripContainer _Container;
		private System.Windows.Forms.StatusStrip _Status;
		private System.Windows.Forms.ToolStrip _ButtonStrip;
		private System.Windows.Forms.MenuStrip _MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem _MenuFile;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemOpen;
		private System.Windows.Forms.ToolStripMenuItem _MenuView;
		private System.Windows.Forms.ToolStripMenuItem _MenuHelp;
		private System.Windows.Forms.ContextMenuStrip _TreeMenu;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemOpenGac;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemClose;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemExit;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemHelpDummy;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemBookmarks;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemSearch;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemDecompiler;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemGoogle;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemMsdn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemAnalyzer;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemBookmark;
		private System.Windows.Forms.ToolStripButton _ButtonBack;
		private System.Windows.Forms.ToolStripButton _ButtonForward;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSplitButton _ButtonOpen;
		private System.Windows.Forms.ToolStripMenuItem _ButtonItemOpen;
		private System.Windows.Forms.ToolStripMenuItem _ButtonItemOpenGac;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton _ButtonRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton _ButtonBookmarks;
		private System.Windows.Forms.ToolStripComboBox _ComboSearch;
		private System.Windows.Forms.ToolStripButton _ButtonSearch;
		private System.Windows.Forms.ToolStripComboBox _ComboLanguage;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemBookmarkRemove;
		private System.Windows.Forms.ToolStripMenuItem _PopItemBack;
		private System.Windows.Forms.ToolStripMenuItem _PopItemForward;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem _PopItemBookmarkAdd;
		private System.Windows.Forms.ToolStripMenuItem _PopItemBookmarkRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem _PopItemClose;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemPrefs;
		private System.Windows.Forms.ToolStripMenuItem _PopItemDecompile;
		private System.Windows.Forms.ToolStripMenuItem _PopItemAnalyze;
		private System.Windows.Forms.ToolStripMenuItem _PopItemExport;
		private System.Windows.Forms.ToolStripMenuItem _PopItemCopy;
		private System.Windows.Forms.ToolStripMenuItem _PopItemGoogle;
		private System.Windows.Forms.ToolStripMenuItem _PopItemMsdn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem _PopItemBaseType;
		private System.Windows.Forms.ToolStripMenuItem _PopItemFieldType;
		private System.Windows.Forms.ToolStripMenuItem _PopItemPropertyType;
		private System.Windows.Forms.SplitContainer _SplitContainerLeft;

	}
}

