namespace v2rayN.Forms
{
    partial class SubSettingControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEnabled);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.txtUrl);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(600, 156);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订阅信息(SubscriptionDetails)";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkEnabled.Location = new System.Drawing.Point(492, 26);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(98, 21);
            this.chkEnabled.TabIndex = 25;
            this.chkEnabled.Text = "使用(Enable)";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.Leave += new System.EventHandler(this.txtRemarks_Leave);
            // 
            // btnRemove
            // 
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(492, 55);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 33);
            this.btnRemove.TabIndex = 24;
            this.btnRemove.Text = "&移除(Remove)";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(98, 55);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(386, 70);
            this.txtUrl.TabIndex = 23;
            this.txtUrl.Leave += new System.EventHandler(this.txtRemarks_Leave);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(98, 24);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(385, 23);
            this.txtRemarks.TabIndex = 11;
            this.txtRemarks.Leave += new System.EventHandler(this.txtRemarks_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "别名(Alias)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "地址(Address)";
            // 
            // SubSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubSettingControl";
            this.Size = new System.Drawing.Size(600, 170);
            this.Load += new System.EventHandler(this.SubSettingControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}
