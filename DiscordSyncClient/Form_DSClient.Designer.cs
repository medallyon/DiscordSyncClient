namespace DiscordSyncClient
{
    partial class Form_DSClient
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
            this.ProgressBar_Upload = new System.Windows.Forms.ProgressBar();
            this.Button_Upload = new System.Windows.Forms.Button();
            this.Button_SetPath = new System.Windows.Forms.Button();
            this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.Label_Progress = new System.Windows.Forms.Label();
            this.TextBox_Token = new DiscordSyncClient.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // ProgressBar_Upload
            // 
            this.ProgressBar_Upload.Location = new System.Drawing.Point(52, 72);
            this.ProgressBar_Upload.Name = "ProgressBar_Upload";
            this.ProgressBar_Upload.Size = new System.Drawing.Size(255, 32);
            this.ProgressBar_Upload.Step = 1;
            this.ProgressBar_Upload.TabIndex = 0;
            this.ProgressBar_Upload.Click += new System.EventHandler(this.ProgressBar_Upload_Click);
            // 
            // Button_Upload
            // 
            this.Button_Upload.Location = new System.Drawing.Point(232, 126);
            this.Button_Upload.Name = "Button_Upload";
            this.Button_Upload.Size = new System.Drawing.Size(75, 23);
            this.Button_Upload.TabIndex = 1;
            this.Button_Upload.Text = "Upload";
            this.Button_Upload.UseVisualStyleBackColor = true;
            this.Button_Upload.Click += new System.EventHandler(this.Button_Upload_Click);
            // 
            // Button_SetPath
            // 
            this.Button_SetPath.Location = new System.Drawing.Point(52, 126);
            this.Button_SetPath.Name = "Button_SetPath";
            this.Button_SetPath.Size = new System.Drawing.Size(75, 23);
            this.Button_SetPath.TabIndex = 2;
            this.Button_SetPath.Text = "Select File";
            this.Button_SetPath.UseVisualStyleBackColor = true;
            this.Button_SetPath.Click += new System.EventHandler(this.Button_SetPath_Click);
            // 
            // FileBrowser
            // 
            this.FileBrowser.FileName = "DiscordSync.lua";
            // 
            // Label_Progress
            // 
            this.Label_Progress.AutoSize = true;
            this.Label_Progress.BackColor = System.Drawing.Color.Transparent;
            this.Label_Progress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Progress.Location = new System.Drawing.Point(159, 82);
            this.Label_Progress.Name = "Label_Progress";
            this.Label_Progress.Size = new System.Drawing.Size(48, 13);
            this.Label_Progress.TabIndex = 3;
            this.Label_Progress.Text = "Progress";
            // 
            // TextBox_Token
            // 
            this.TextBox_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.TextBox_Token.ForeColor = System.Drawing.Color.Gray;
            this.TextBox_Token.Location = new System.Drawing.Point(52, 26);
            this.TextBox_Token.Name = "TextBox_Token";
            this.TextBox_Token.PlaceHolderText = "Account Token";
            this.TextBox_Token.Size = new System.Drawing.Size(255, 20);
            this.TextBox_Token.TabIndex = 4;
            this.TextBox_Token.Text = "Account Token";
            this.TextBox_Token.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_Token.TextChanged += new System.EventHandler(this.TextBox_Token_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.Controls.Add(this.TextBox_Token);
            this.Controls.Add(this.Label_Progress);
            this.Controls.Add(this.Button_SetPath);
            this.Controls.Add(this.Button_Upload);
            this.Controls.Add(this.ProgressBar_Upload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_Upload;
        private System.Windows.Forms.Button Button_Upload;
        private System.Windows.Forms.Button Button_SetPath;
        private System.Windows.Forms.OpenFileDialog FileBrowser;
        private System.Windows.Forms.Label Label_Progress;
        private PlaceHolderTextBox TextBox_Token;
    }
}

