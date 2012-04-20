namespace Directums.Client.Forms.Client
{
    partial class NotificationForm
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
            this.lbClose = new System.Windows.Forms.Label();
            this.pbNotificationIconUser = new System.Windows.Forms.PictureBox();
            this.lbText = new System.Windows.Forms.Label();
            this.pbNotificationIconMessage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationIconUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationIconMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbClose
            // 
            this.lbClose.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbClose.Location = new System.Drawing.Point(125, -2);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(25, 26);
            this.lbClose.TabIndex = 0;
            this.lbClose.Text = "X";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // pbNotificationIconUser
            // 
            this.pbNotificationIconUser.Image = global::Directums.Client.Properties.Resources.i1;
            this.pbNotificationIconUser.Location = new System.Drawing.Point(0, 0);
            this.pbNotificationIconUser.Name = "pbNotificationIconUser";
            this.pbNotificationIconUser.Size = new System.Drawing.Size(92, 71);
            this.pbNotificationIconUser.TabIndex = 1;
            this.pbNotificationIconUser.TabStop = false;
            this.pbNotificationIconUser.Visible = false;
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(16, 92);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(109, 54);
            this.lbText.TabIndex = 2;
            this.lbText.Text = "Текст для отображения";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbNotificationIconMessage
            // 
            this.pbNotificationIconMessage.Image = global::Directums.Client.Properties.Resources.convert;
            this.pbNotificationIconMessage.Location = new System.Drawing.Point(0, -2);
            this.pbNotificationIconMessage.Name = "pbNotificationIconMessage";
            this.pbNotificationIconMessage.Size = new System.Drawing.Size(92, 73);
            this.pbNotificationIconMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotificationIconMessage.TabIndex = 3;
            this.pbNotificationIconMessage.TabStop = false;
            this.pbNotificationIconMessage.Visible = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(147, 157);
            this.ControlBox = false;
            this.Controls.Add(this.pbNotificationIconMessage);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.pbNotificationIconUser);
            this.Controls.Add(this.lbClose);
            this.DoubleBuffered = true;
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationIconUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationIconMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.PictureBox pbNotificationIconUser;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.PictureBox pbNotificationIconMessage;
    }
}