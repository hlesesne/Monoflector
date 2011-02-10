namespace Monoflector.Bootstrap
{
    partial class PluginSelection
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
            this._pluginsListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this._installButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this._installationPanel = new System.Windows.Forms.Panel();
            this._pluginLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this._installationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pluginsListView
            // 
            this._pluginsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._pluginsListView.CheckBoxes = true;
            this._pluginsListView.HideSelection = false;
            this._pluginsListView.Location = new System.Drawing.Point(12, 32);
            this._pluginsListView.MultiSelect = false;
            this._pluginsListView.Name = "_pluginsListView";
            this._pluginsListView.Size = new System.Drawing.Size(147, 233);
            this._pluginsListView.TabIndex = 0;
            this._pluginsListView.UseCompatibleStateImageBehavior = false;
            this._pluginsListView.View = System.Windows.Forms.View.List;
            this._pluginsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this._pluginsListView_ItemChecked);
            this._pluginsListView.SelectedIndexChanged += new System.EventHandler(this._pluginsListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plugins:";
            // 
            // _installButton
            // 
            this._installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._installButton.Location = new System.Drawing.Point(280, 272);
            this._installButton.Name = "_installButton";
            this._installButton.Size = new System.Drawing.Size(75, 23);
            this._installButton.TabIndex = 1;
            this._installButton.Text = "Install";
            this._installButton.UseVisualStyleBackColor = true;
            this._installButton.Click += new System.EventHandler(this._installButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(361, 272);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._webBrowser);
            this.panel1.Location = new System.Drawing.Point(165, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 254);
            this.panel1.TabIndex = 4;
            // 
            // _webBrowser
            // 
            this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webBrowser.Location = new System.Drawing.Point(0, 0);
            this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser.Name = "_webBrowser";
            this._webBrowser.Size = new System.Drawing.Size(269, 252);
            this._webBrowser.TabIndex = 0;
            // 
            // _installationPanel
            // 
            this._installationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._installationPanel.Controls.Add(this._pluginLabel);
            this._installationPanel.Controls.Add(this.label3);
            this._installationPanel.Controls.Add(this._progressBar);
            this._installationPanel.Controls.Add(this.label2);
            this._installationPanel.Location = new System.Drawing.Point(12, 12);
            this._installationPanel.Name = "_installationPanel";
            this._installationPanel.Size = new System.Drawing.Size(424, 283);
            this._installationPanel.TabIndex = 3;
            this._installationPanel.Visible = false;
            // 
            // _pluginLabel
            // 
            this._pluginLabel.AutoSize = true;
            this._pluginLabel.Location = new System.Drawing.Point(45, 57);
            this._pluginLabel.Name = "_pluginLabel";
            this._pluginLabel.Size = new System.Drawing.Size(0, 13);
            this._pluginLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plugin:";
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(0, 31);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(423, 23);
            this._progressBar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Installing...";
            // 
            // PluginSelection
            // 
            this.AcceptButton = this._installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(448, 307);
            this.Controls.Add(this._installationPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._installButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._pluginsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PluginSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Installation";
            this.panel1.ResumeLayout(false);
            this._installationPanel.ResumeLayout(false);
            this._installationPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _pluginsListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _installButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser _webBrowser;
        private System.Windows.Forms.Panel _installationPanel;
        private System.Windows.Forms.Label _pluginLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label label2;
    }
}