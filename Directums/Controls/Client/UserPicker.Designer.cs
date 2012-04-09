namespace Directums.Client.Controls.Client
{
    partial class UserPicker
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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.btnPick = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(0, 16);
            this.tbUser.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(171, 20);
            this.tbUser.TabIndex = 1;
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
            // lbUser
            // 
            this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUser.Location = new System.Drawing.Point(0, 0);
            this.lbUser.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(171, 13);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Пользователь:";
            // 
            // UserPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.tbUser);
            this.MaximumSize = new System.Drawing.Size(2000, 36);
            this.MinimumSize = new System.Drawing.Size(200, 36);
            this.Name = "UserPicker";
            this.Size = new System.Drawing.Size(200, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Label lbUser;

    }
}
