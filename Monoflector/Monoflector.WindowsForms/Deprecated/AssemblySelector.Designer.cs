namespace Monoflector
{
    partial class AssemblySelector
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
            this._providersTab = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // _providersTab
            // 
            this._providersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._providersTab.Location = new System.Drawing.Point(0, 0);
            this._providersTab.Name = "_providersTab";
            this._providersTab.SelectedIndex = 0;
            this._providersTab.Size = new System.Drawing.Size(505, 399);
            this._providersTab.TabIndex = 0;
            // 
            // AssemblySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 399);
            this.Controls.Add(this._providersTab);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssemblySelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assembly Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _providersTab;
    }
}