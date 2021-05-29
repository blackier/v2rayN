namespace v2rayN.Forms
{
    partial class ConfigVMessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigVMessForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGUID = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSecurity = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlterId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panTlsMore = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbAllowInsecure = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmbNetwork = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbStreamSecurity = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRequestHost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbHeaderType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panTlsMore.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(252, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGUID);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbSecurity);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAlterId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 230);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器(Server)";
            // 
            // btnGUID
            // 
            this.btnGUID.Location = new System.Drawing.Point(537, 79);
            this.btnGUID.Name = "btnGUID";
            this.btnGUID.Size = new System.Drawing.Size(110, 25);
            this.btnGUID.TabIndex = 23;
            this.btnGUID.Text = "&生成(generate)";
            this.btnGUID.UseVisualStyleBackColor = true;
            this.btnGUID.Click += new System.EventHandler(this.btnGUID_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(346, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "*可选(optional)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "*推荐auto";
            // 
            // cmbSecurity
            // 
            this.cmbSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurity.FormattingEnabled = true;
            this.cmbSecurity.Items.AddRange(new object[] {
            "aes-128-gcm",
            "chacha20-poly1305",
            "auto",
            "none"});
            this.cmbSecurity.Location = new System.Drawing.Point(197, 141);
            this.cmbSecurity.Name = "cmbSecurity";
            this.cmbSecurity.Size = new System.Drawing.Size(143, 25);
            this.cmbSecurity.TabIndex = 6;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(197, 172);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(143, 23);
            this.txtRemarks.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "别名(Alias)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "加密方式(Security)";
            // 
            // txtAlterId
            // 
            this.txtAlterId.Location = new System.Drawing.Point(197, 109);
            this.txtAlterId.Name = "txtAlterId";
            this.txtAlterId.Size = new System.Drawing.Size(143, 23);
            this.txtAlterId.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "额外ID(AlterId)";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(197, 80);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(278, 23);
            this.txtId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "UUID(id)";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(197, 51);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(278, 23);
            this.txtPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口(Port)";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(197, 22);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(450, 23);
            this.txtAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址(Address)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.panTlsMore);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.cmbNetwork);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cmbStreamSecurity);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtRequestHost);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbHeaderType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 380);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "传输(Transport)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(503, 227);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(161, 17);
            this.label24.TabIndex = 35;
            this.label24.Text = "3)QUIC 加密密钥/Kcp seed";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(503, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 17);
            this.label23.TabIndex = 34;
            this.label23.Text = "4)QUIC securty";
            // 
            // panTlsMore
            // 
            this.panTlsMore.Controls.Add(this.label21);
            this.panTlsMore.Controls.Add(this.cmbAllowInsecure);
            this.panTlsMore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTlsMore.Location = new System.Drawing.Point(3, 317);
            this.panTlsMore.Name = "panTlsMore";
            this.panTlsMore.Size = new System.Drawing.Size(724, 60);
            this.panTlsMore.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(168, 17);
            this.label21.TabIndex = 31;
            this.label21.Text = "跳过证书验证(AllowInsecure)";
            // 
            // cmbAllowInsecure
            // 
            this.cmbAllowInsecure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllowInsecure.FormattingEnabled = true;
            this.cmbAllowInsecure.Items.AddRange(new object[] {
            "",
            "true",
            "false"});
            this.cmbAllowInsecure.Location = new System.Drawing.Point(194, 0);
            this.cmbAllowInsecure.Name = "cmbAllowInsecure";
            this.cmbAllowInsecure.Size = new System.Drawing.Size(143, 25);
            this.cmbAllowInsecure.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "*默认tcp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(503, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 17);
            this.label20.TabIndex = 29;
            this.label20.Text = "3)h2 host 中间逗号(,)隔开";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(197, 190);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(300, 90);
            this.txtPath.TabIndex = 28;
            // 
            // cmbNetwork
            // 
            this.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetwork.FormattingEnabled = true;
            this.cmbNetwork.Items.AddRange(new object[] {
            "tcp",
            "kcp",
            "ws",
            "h2",
            "quic"});
            this.cmbNetwork.Location = new System.Drawing.Point(197, 22);
            this.cmbNetwork.Name = "cmbNetwork";
            this.cmbNetwork.Size = new System.Drawing.Size(143, 25);
            this.cmbNetwork.TabIndex = 12;
            this.cmbNetwork.SelectedIndexChanged += new System.EventHandler(this.cmbNetwork_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "传输协议(Network)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 193);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 17);
            this.label19.TabIndex = 27;
            this.label19.Text = "路径(Path)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(503, 210);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 26;
            this.label18.Text = "2)h2 path";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(503, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "2)ws host";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(503, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 17);
            this.label16.TabIndex = 24;
            this.label16.Text = "1)ws path";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(503, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "1)http host 中间逗号(,)隔开";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "TLS";
            // 
            // cmbStreamSecurity
            // 
            this.cmbStreamSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStreamSecurity.FormattingEnabled = true;
            this.cmbStreamSecurity.Items.AddRange(new object[] {
            "",
            "tls"});
            this.cmbStreamSecurity.Location = new System.Drawing.Point(197, 286);
            this.cmbStreamSecurity.Name = "cmbStreamSecurity";
            this.cmbStreamSecurity.Size = new System.Drawing.Size(143, 25);
            this.cmbStreamSecurity.TabIndex = 21;
            this.cmbStreamSecurity.SelectedIndexChanged += new System.EventHandler(this.cmbStreamSecurity_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(346, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "*tcp或kcp或QUIC伪装类型, 默认none";
            // 
            // txtRequestHost
            // 
            this.txtRequestHost.Location = new System.Drawing.Point(197, 84);
            this.txtRequestHost.Multiline = true;
            this.txtRequestHost.Name = "txtRequestHost";
            this.txtRequestHost.Size = new System.Drawing.Size(300, 100);
            this.txtRequestHost.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "伪装类型(CamouflageType)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "伪装域名(CamouflageDomain)";
            // 
            // cmbHeaderType
            // 
            this.cmbHeaderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeaderType.FormattingEnabled = true;
            this.cmbHeaderType.Items.AddRange(new object[] {
            "none",
            "http",
            "srtp",
            "utp",
            "wechat-video",
            "dtls",
            "wireguard"});
            this.cmbHeaderType.Location = new System.Drawing.Point(197, 53);
            this.cmbHeaderType.Name = "cmbHeaderType";
            this.cmbHeaderType.Size = new System.Drawing.Size(143, 25);
            this.cmbHeaderType.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 620);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 60);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(403, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 10);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 230);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 380);
            this.panel4.TabIndex = 23;
            // 
            // ConfigVMessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(730, 680);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(175, 96, 175, 96);
            this.Name = "ConfigVMessForm";
            this.Text = "VMess";
            this.Load += new System.EventHandler(this.AddServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panTlsMore.ResumeLayout(false);
            this.panTlsMore.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlterId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSecurity;
        private System.Windows.Forms.ComboBox cmbNetwork;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRequestHost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbHeaderType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbStreamSecurity;
        private System.Windows.Forms.Button btnGUID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbAllowInsecure;
        private System.Windows.Forms.Panel panTlsMore;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}