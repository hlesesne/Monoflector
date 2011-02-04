namespace Monoflector
{
    partial class AssemblyProviderSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyProviderSelection));
            this._buttonsPanel = new System.Windows.Forms.Panel();
            this._filterTextBox = new Monoflector.WatermarkBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._mainImageList = new System.Windows.Forms.ImageList(this.components);
            this._iconHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._versionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._assembliesListView = new System.Windows.Forms.ListView();
            this._searchTimer = new System.Windows.Forms.Timer(this.components);
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._filterTextBox);
            this._buttonsPanel.Controls.Add(this._closeButton);
            this._buttonsPanel.Controls.Add(this._addButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 248);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(503, 28);
            this._buttonsPanel.TabIndex = 0;
            // 
            // _filterTextBox
            // 
            this._filterTextBox.Location = new System.Drawing.Point(3, 4);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(335, 20);
            this._filterTextBox.TabIndex = 4;
            this._filterTextBox.Watermark = "Search";
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.Location = new System.Drawing.Point(425, 3);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 3;
            this._closeButton.Text = "Close";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // _addButton
            // 
            this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._addButton.Enabled = false;
            this._addButton.Location = new System.Drawing.Point(344, 3);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 2;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this._addButton_Click);
            // 
            // _mainImageList
            // 
            this._mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_mainImageList.ImageStream")));
            this._mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._mainImageList.Images.SetKeyName(0, "selected");
            // 
            // _iconHeader
            // 
            this._iconHeader.Text = "";
            this._iconHeader.Width = 24;
            // 
            // _nameColumn
            // 
            this._nameColumn.Text = "Name";
            this._nameColumn.Width = 370;
            // 
            // _versionHeader
            // 
            this._versionHeader.Text = "Version";
            this._versionHeader.Width = 100;
            // 
            // _assembliesListView
            // 
            this._assembliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._iconHeader,
            this._nameColumn,
            this._versionHeader});
            this._assembliesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._assembliesListView.FullRowSelect = true;
            this._assembliesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._assembliesListView.Location = new System.Drawing.Point(0, 0);
            this._assembliesListView.Name = "_assembliesListView";
            this._assembliesListView.Size = new System.Drawing.Size(503, 248);
            this._assembliesListView.SmallImageList = this._mainImageList;
            this._assembliesListView.TabIndex = 1;
            this._assembliesListView.UseCompatibleStateImageBehavior = false;
            this._assembliesListView.View = System.Windows.Forms.View.Details;
            this._assembliesListView.SelectedIndexChanged += new System.EventHandler(this._assembliesListView_SelectedIndexChanged);
            // 
            // _searchTimer
            // 
            this._searchTimer.Interval = 1000;
            this._searchTimer.Tick += new System.EventHandler(this._searchTimer_Tick);
            // 
            // AssemblyProviderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._assembliesListView);
            this.Controls.Add(this._buttonsPanel);
            this.Name = "AssemblyProviderSelection";
            this.Size = new System.Drawing.Size(503, 276);
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _buttonsPanel;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.ImageList _mainImageList;
        private System.Windows.Forms.ColumnHeader _iconHeader;
        private System.Windows.Forms.ColumnHeader _nameColumn;
        private System.Windows.Forms.ColumnHeader _versionHeader;
        private System.Windows.Forms.ListView _assembliesListView;
        private System.Windows.Forms.Timer _searchTimer;
        private WatermarkBox _filterTextBox;


    }
}
