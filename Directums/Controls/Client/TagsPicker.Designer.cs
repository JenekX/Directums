namespace Directums.Client.Controls.Client
{
    partial class TagsPicker
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
            this.tbText = new System.Windows.Forms.TextBox();
            this.btnPick = new System.Windows.Forms.Button();
            this.lblTags = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(0, 16);
            this.tbText.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.Size = new System.Drawing.Size(171, 20);
            this.tbText.TabIndex = 1;
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(177, 13);
            this.btnPick.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(23, 23);
            this.btnPick.TabIndex = 2;
            this.btnPick.Text = "...";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // lblTags
            // 
            this.lblTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTags.Location = new System.Drawing.Point(0, 0);
            this.lblTags.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(171, 13);
            this.lblTags.TabIndex = 0;
            this.lblTags.Text = "Теги:";
            // 
            // TagsPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.tbText);
            this.MaximumSize = new System.Drawing.Size(2000, 36);
            this.MinimumSize = new System.Drawing.Size(200, 36);
            this.Name = "TagsPicker";
            this.Size = new System.Drawing.Size(200, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Label lblTags;

    }
}
