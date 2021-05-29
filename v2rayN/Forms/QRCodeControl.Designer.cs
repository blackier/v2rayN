namespace v2rayN.Forms
{
    partial class QRCodeControl
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtUrl.Location = new System.Drawing.Point(0, 300);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(250, 100);
            this.txtUrl.TabIndex = 0;
            // 
            // picQRCode
            // 
            this.picQRCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picQRCode.Location = new System.Drawing.Point(0, 0);
            this.picQRCode.Margin = new System.Windows.Forms.Padding(4);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(250, 300);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 24;
            this.picQRCode.TabStop = false;
            // 
            // QRCodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.txtUrl);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QRCodeControl";
            this.Size = new System.Drawing.Size(250, 400);
            this.Load += new System.EventHandler(this.QRCodeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.PictureBox picQRCode;
    }
}
