﻿namespace Monoflector
{
    partial class AssemblySetBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainToolStrip = new System.Windows.Forms.ToolStrip();
            this._searchTermTextBox = new System.Windows.Forms.ToolStripTextBox();
            this._searchToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._clearSearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._assembliesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._presentersTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._mainToolStrip.SuspendLayout();
            this._presentersTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainToolStrip
            // 
            this._mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._clearSearchToolStripButton,
            this._searchToolStripButton,
            this._searchTermTextBox,
            this._searchToolStripLabel,
            this._assembliesToolStripButton,
            this.toolStripSeparator1});
            this._mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this._mainToolStrip.Name = "_mainToolStrip";
            this._mainToolStrip.Size = new System.Drawing.Size(357, 25);
            this._mainToolStrip.TabIndex = 0;
            this._mainToolStrip.Text = "Assembly Set Tools";
            // 
            // _searchTermTextBox
            // 
            this._searchTermTextBox.AcceptsReturn = true;
            this._searchTermTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._searchTermTextBox.Name = "_searchTermTextBox";
            this._searchTermTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // _searchToolStripLabel
            // 
            this._searchToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._searchToolStripLabel.Name = "_searchToolStripLabel";
            this._searchToolStripLabel.Size = new System.Drawing.Size(45, 22);
            this._searchToolStripLabel.Text = "Search:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _clearSearchToolStripButton
            // 
            this._clearSearchToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._clearSearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._clearSearchToolStripButton.Image = global::Monoflector.Properties.Resources.stop;
            this._clearSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._clearSearchToolStripButton.Name = "_clearSearchToolStripButton";
            this._clearSearchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._clearSearchToolStripButton.Text = "Clear Search";
            // 
            // _searchToolStripButton
            // 
            this._searchToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._searchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._searchToolStripButton.Image = global::Monoflector.Properties.Resources.find;
            this._searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._searchToolStripButton.Name = "_searchToolStripButton";
            this._searchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._searchToolStripButton.Text = "Search";
            // 
            // _assembliesToolStripButton
            // 
            this._assembliesToolStripButton.Image = global::Monoflector.Properties.Resources.brick_edit;
            this._assembliesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._assembliesToolStripButton.Name = "_assembliesToolStripButton";
            this._assembliesToolStripButton.Size = new System.Drawing.Size(86, 22);
            this._assembliesToolStripButton.Text = "Assemblies";
            this._assembliesToolStripButton.Click += new System.EventHandler(this._assembliesToolStripButton_Click);
            // 
            // _presentersTabControl
            // 
            this._presentersTabControl.Controls.Add(this.tabPage1);
            this._presentersTabControl.Controls.Add(this.tabPage2);
            this._presentersTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._presentersTabControl.Location = new System.Drawing.Point(0, 25);
            this._presentersTabControl.Name = "_presentersTabControl";
            this._presentersTabControl.SelectedIndex = 0;
            this._presentersTabControl.Size = new System.Drawing.Size(357, 288);
            this._presentersTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(349, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(349, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AssemblySetBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._presentersTabControl);
            this.Controls.Add(this._mainToolStrip);
            this.Name = "AssemblySetBrowser";
            this.Size = new System.Drawing.Size(357, 313);
            this._mainToolStrip.ResumeLayout(false);
            this._mainToolStrip.PerformLayout();
            this._presentersTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _mainToolStrip;
        private System.Windows.Forms.ToolStripButton _searchToolStripButton;
        private System.Windows.Forms.ToolStripTextBox _searchTermTextBox;
        private System.Windows.Forms.ToolStripLabel _searchToolStripLabel;
        private System.Windows.Forms.ToolStripButton _clearSearchToolStripButton;
        private System.Windows.Forms.ToolStripButton _assembliesToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl _presentersTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
