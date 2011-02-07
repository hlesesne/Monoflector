namespace Monoflector.Plugins
{
    partial class ProgressDialog
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
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._fileLabel = new System.Windows.Forms.Label();
            this._completePanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._completePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(12, 12);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(399, 23);
            this._progressBar.TabIndex = 0;
            // 
            // _fileLabel
            // 
            this._fileLabel.Location = new System.Drawing.Point(12, 38);
            this._fileLabel.Name = "_fileLabel";
            this._fileLabel.Size = new System.Drawing.Size(399, 42);
            this._fileLabel.TabIndex = 1;
            this._fileLabel.Text = "label1";
            // 
            // _completePanel
            // 
            this._completePanel.Controls.Add(this._okButton);
            this._completePanel.Controls.Add(this.label1);
            this._completePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._completePanel.Location = new System.Drawing.Point(0, 0);
            this._completePanel.Name = "_completePanel";
            this._completePanel.Size = new System.Drawing.Size(423, 88);
            this._completePanel.TabIndex = 2;
            this._completePanel.Visible = false;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(336, 57);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "&OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installation completed.";
            // 
            // ProgressDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._okButton;
            this.ClientSize = new System.Drawing.Size(423, 88);
            this.ControlBox = false;
            this.Controls.Add(this._completePanel);
            this.Controls.Add(this._fileLabel);
            this.Controls.Add(this._progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installing";
            this._completePanel.ResumeLayout(false);
            this._completePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _fileLabel;
        private System.Windows.Forms.Panel _completePanel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label label1;
    }
}