namespace Monoflector
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mainToolstrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._nodesTreeView = new System.Windows.Forms.TreeView();
            this._setsTabControl = new System.Windows.Forms.TabControl();
            this._mainMenuStrip.SuspendLayout();
            this._mainToolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainMenuStrip
            // 
            this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._mainMenuStrip.Name = "_mainMenuStrip";
            this._mainMenuStrip.Size = new System.Drawing.Size(704, 24);
            this._mainMenuStrip.TabIndex = 0;
            this._mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newSetToolStripMenuItem
            // 
            this.newSetToolStripMenuItem.Image = global::Monoflector.Properties.Resources.package_add;
            this.newSetToolStripMenuItem.Name = "newSetToolStripMenuItem";
            this.newSetToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newSetToolStripMenuItem.Text = "&New Set...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // _mainToolstrip
            // 
            this._mainToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this._mainToolstrip.Location = new System.Drawing.Point(0, 24);
            this._mainToolstrip.Name = "_mainToolstrip";
            this._mainToolstrip.Size = new System.Drawing.Size(704, 25);
            this._mainToolstrip.TabIndex = 1;
            this._mainToolstrip.Text = "Tools";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Monoflector.Properties.Resources.wrench;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Settings";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._nodesTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._setsTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(704, 433);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 2;
            // 
            // _nodesTreeView
            // 
            this._nodesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._nodesTreeView.Location = new System.Drawing.Point(0, 0);
            this._nodesTreeView.Name = "_nodesTreeView";
            this._nodesTreeView.Size = new System.Drawing.Size(234, 433);
            this._nodesTreeView.TabIndex = 0;
            this._nodesTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this._nodesTreeView_BeforeExpand);
            // 
            // _setsTabControl
            // 
            this._setsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._setsTabControl.Location = new System.Drawing.Point(0, 0);
            this._setsTabControl.Name = "_setsTabControl";
            this._setsTabControl.SelectedIndex = 0;
            this._setsTabControl.Size = new System.Drawing.Size(466, 433);
            this._setsTabControl.TabIndex = 0;
            this._setsTabControl.SelectedIndexChanged += new System.EventHandler(this._setsTabControl_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 482);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._mainToolstrip);
            this.Controls.Add(this._mainMenuStrip);
            this.MainMenuStrip = this._mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Monoflector";
            this._mainMenuStrip.ResumeLayout(false);
            this._mainMenuStrip.PerformLayout();
            this._mainToolstrip.ResumeLayout(false);
            this._mainToolstrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip _mainToolstrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl _setsTabControl;
        private System.Windows.Forms.TreeView _nodesTreeView;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSetToolStripMenuItem;
    }
}

