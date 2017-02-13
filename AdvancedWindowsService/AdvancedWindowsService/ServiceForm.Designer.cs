namespace AdvancedWindowsService
{
    partial class ServiceForm
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
            this.WorkingPanelTextBox = new System.Windows.Forms.TextBox();
            this.WorkingPanelLabel = new System.Windows.Forms.Label();
            this.Start_Button = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.WatchingDirectoryLabel = new System.Windows.Forms.Label();
            this.WatchingDirectoryName = new System.Windows.Forms.Label();
            this.ArchiveFileDirectoryLabel = new System.Windows.Forms.Label();
            this.ArchiveFileDirectoryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WorkingPanelTextBox
            // 
            this.WorkingPanelTextBox.Location = new System.Drawing.Point(30, 75);
            this.WorkingPanelTextBox.Multiline = true;
            this.WorkingPanelTextBox.Name = "WorkingPanelTextBox";
            this.WorkingPanelTextBox.ReadOnly = true;
            this.WorkingPanelTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WorkingPanelTextBox.Size = new System.Drawing.Size(403, 188);
            this.WorkingPanelTextBox.TabIndex = 0;
            // 
            // WorkingPanelLabel
            // 
            this.WorkingPanelLabel.AutoSize = true;
            this.WorkingPanelLabel.Location = new System.Drawing.Point(27, 59);
            this.WorkingPanelLabel.Name = "WorkingPanelLabel";
            this.WorkingPanelLabel.Size = new System.Drawing.Size(79, 13);
            this.WorkingPanelLabel.TabIndex = 1;
            this.WorkingPanelLabel.Text = "Working panel:";
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(278, 269);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(75, 23);
            this.Start_Button.TabIndex = 2;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.Location = new System.Drawing.Point(379, 269);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(75, 23);
            this.Stop_Button.TabIndex = 3;
            this.Stop_Button.Text = "Stop";
            this.Stop_Button.UseVisualStyleBackColor = true;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // WatchingDirectoryLabel
            // 
            this.WatchingDirectoryLabel.AutoSize = true;
            this.WatchingDirectoryLabel.Location = new System.Drawing.Point(27, 9);
            this.WatchingDirectoryLabel.Name = "WatchingDirectoryLabel";
            this.WatchingDirectoryLabel.Size = new System.Drawing.Size(101, 13);
            this.WatchingDirectoryLabel.TabIndex = 4;
            this.WatchingDirectoryLabel.Text = "Watching Directory:";
            // 
            // WatchingDirectoryName
            // 
            this.WatchingDirectoryName.AutoSize = true;
            this.WatchingDirectoryName.Location = new System.Drawing.Point(134, 9);
            this.WatchingDirectoryName.Name = "WatchingDirectoryName";
            this.WatchingDirectoryName.Size = new System.Drawing.Size(0, 13);
            this.WatchingDirectoryName.TabIndex = 5;
            // 
            // ArchiveFileDirectoryLabel
            // 
            this.ArchiveFileDirectoryLabel.AutoSize = true;
            this.ArchiveFileDirectoryLabel.Location = new System.Drawing.Point(27, 32);
            this.ArchiveFileDirectoryLabel.Name = "ArchiveFileDirectoryLabel";
            this.ArchiveFileDirectoryLabel.Size = new System.Drawing.Size(110, 13);
            this.ArchiveFileDirectoryLabel.TabIndex = 6;
            this.ArchiveFileDirectoryLabel.Text = "Archive File Directory:";
            // 
            // ArchiveFileDirectoryName
            // 
            this.ArchiveFileDirectoryName.AutoSize = true;
            this.ArchiveFileDirectoryName.Location = new System.Drawing.Point(140, 32);
            this.ArchiveFileDirectoryName.Name = "ArchiveFileDirectoryName";
            this.ArchiveFileDirectoryName.Size = new System.Drawing.Size(0, 13);
            this.ArchiveFileDirectoryName.TabIndex = 7;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 304);
            this.Controls.Add(this.ArchiveFileDirectoryName);
            this.Controls.Add(this.ArchiveFileDirectoryLabel);
            this.Controls.Add(this.WatchingDirectoryName);
            this.Controls.Add(this.WatchingDirectoryLabel);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.WorkingPanelLabel);
            this.Controls.Add(this.WorkingPanelTextBox);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WorkingPanelTextBox;
        private System.Windows.Forms.Label WorkingPanelLabel;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Label WatchingDirectoryLabel;
        private System.Windows.Forms.Label WatchingDirectoryName;
        private System.Windows.Forms.Label ArchiveFileDirectoryLabel;
        private System.Windows.Forms.Label ArchiveFileDirectoryName;
    }
}