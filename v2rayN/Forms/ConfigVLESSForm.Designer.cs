namespace v2rayN.Forms;

partial class ConfigVLESSForm
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
        groupBox1 = new System.Windows.Forms.GroupBox();
        cmbFlow = new System.Windows.Forms.ComboBox();
        label4 = new System.Windows.Forms.Label();
        btnGUID = new System.Windows.Forms.Button();
        label13 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        cmbSecurity = new System.Windows.Forms.ComboBox();
        txtRemarks = new System.Windows.Forms.TextBox();
        label6 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        txtId = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        txtPort = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        txtAddress = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        groupBox2 = new System.Windows.Forms.GroupBox();
        label24 = new System.Windows.Forms.Label();
        label23 = new System.Windows.Forms.Label();
        panTlsMore = new System.Windows.Forms.Panel();
        label21 = new System.Windows.Forms.Label();
        cmbAllowInsecure = new System.Windows.Forms.ComboBox();
        label9 = new System.Windows.Forms.Label();
        label20 = new System.Windows.Forms.Label();
        txtPath = new System.Windows.Forms.TextBox();
        cmbNetwork = new System.Windows.Forms.ComboBox();
        label7 = new System.Windows.Forms.Label();
        label19 = new System.Windows.Forms.Label();
        label18 = new System.Windows.Forms.Label();
        label17 = new System.Windows.Forms.Label();
        label16 = new System.Windows.Forms.Label();
        label14 = new System.Windows.Forms.Label();
        label15 = new System.Windows.Forms.Label();
        cmbStreamSecurity = new System.Windows.Forms.ComboBox();
        label12 = new System.Windows.Forms.Label();
        txtRequestHost = new System.Windows.Forms.TextBox();
        label11 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        cmbHeaderType = new System.Windows.Forms.ComboBox();
        panel1 = new System.Windows.Forms.Panel();
        btnOK = new System.Windows.Forms.Button();
        btnClose = new System.Windows.Forms.Button();
        panel2 = new System.Windows.Forms.Panel();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        panelServer = new System.Windows.Forms.Panel();
        panel4 = new System.Windows.Forms.Panel();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        panTlsMore.SuspendLayout();
        panel2.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        panelServer.SuspendLayout();
        panel4.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(cmbFlow);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(btnGUID);
        groupBox1.Controls.Add(label13);
        groupBox1.Controls.Add(label8);
        groupBox1.Controls.Add(cmbSecurity);
        groupBox1.Controls.Add(txtRemarks);
        groupBox1.Controls.Add(label6);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(txtId);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(txtPort);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(txtAddress);
        groupBox1.Controls.Add(label1);
        groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox1.Location = new System.Drawing.Point(0, 0);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(730, 230);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "服务器(Server)";
        // 
        // cmbFlow
        // 
        cmbFlow.FormattingEnabled = true;
        cmbFlow.Items.AddRange(new object[] { "", "xtls-rprx-origin", "xtls-rprx-origin-udp443", "xtls-rprx-direct", "xtls-rprx-direct-udp443" });
        cmbFlow.Location = new System.Drawing.Point(197, 109);
        cmbFlow.Name = "cmbFlow";
        cmbFlow.Size = new System.Drawing.Size(143, 25);
        cmbFlow.TabIndex = 24;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label4.Location = new System.Drawing.Point(12, 112);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(66, 17);
        label4.TabIndex = 25;
        label4.Text = "流控(Flow)";
        // 
        // btnGUID
        // 
        btnGUID.Location = new System.Drawing.Point(537, 79);
        btnGUID.Name = "btnGUID";
        btnGUID.Size = new System.Drawing.Size(110, 25);
        btnGUID.TabIndex = 23;
        btnGUID.Text = "&生成(generate)";
        btnGUID.UseVisualStyleBackColor = true;
        btnGUID.Click += btnGUID_Click;
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new System.Drawing.Point(346, 174);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(93, 17);
        label13.TabIndex = 22;
        label13.Text = "*可选(optional)";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label8.Location = new System.Drawing.Point(346, 143);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(66, 17);
        label8.TabIndex = 14;
        label8.Text = "*推荐none";
        // 
        // cmbSecurity
        // 
        cmbSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        cmbSecurity.FormattingEnabled = true;
        cmbSecurity.Items.AddRange(new object[] { "none" });
        cmbSecurity.Location = new System.Drawing.Point(197, 140);
        cmbSecurity.Name = "cmbSecurity";
        cmbSecurity.Size = new System.Drawing.Size(143, 25);
        cmbSecurity.TabIndex = 6;
        // 
        // txtRemarks
        // 
        txtRemarks.Location = new System.Drawing.Point(197, 171);
        txtRemarks.Name = "txtRemarks";
        txtRemarks.Size = new System.Drawing.Size(143, 23);
        txtRemarks.TabIndex = 11;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new System.Drawing.Point(12, 171);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(67, 17);
        label6.TabIndex = 10;
        label6.Text = "别名(Alias)";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(12, 143);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(125, 17);
        label5.TabIndex = 8;
        label5.Text = "加密方式(Encryption)";
        // 
        // txtId
        // 
        txtId.Location = new System.Drawing.Point(197, 80);
        txtId.Name = "txtId";
        txtId.Size = new System.Drawing.Size(278, 23);
        txtId.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new System.Drawing.Point(12, 83);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(58, 17);
        label3.TabIndex = 4;
        label3.Text = "UUID(id)";
        // 
        // txtPort
        // 
        txtPort.Location = new System.Drawing.Point(197, 51);
        txtPort.Name = "txtPort";
        txtPort.Size = new System.Drawing.Size(278, 23);
        txtPort.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(12, 54);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(64, 17);
        label2.TabIndex = 2;
        label2.Text = "端口(Port)";
        // 
        // txtAddress
        // 
        txtAddress.Location = new System.Drawing.Point(197, 22);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(450, 23);
        txtAddress.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(12, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(88, 17);
        label1.TabIndex = 0;
        label1.Text = "地址(Address)";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(label24);
        groupBox2.Controls.Add(label23);
        groupBox2.Controls.Add(panTlsMore);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(label20);
        groupBox2.Controls.Add(txtPath);
        groupBox2.Controls.Add(cmbNetwork);
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(label19);
        groupBox2.Controls.Add(label18);
        groupBox2.Controls.Add(label17);
        groupBox2.Controls.Add(label16);
        groupBox2.Controls.Add(label14);
        groupBox2.Controls.Add(label15);
        groupBox2.Controls.Add(cmbStreamSecurity);
        groupBox2.Controls.Add(label12);
        groupBox2.Controls.Add(txtRequestHost);
        groupBox2.Controls.Add(label11);
        groupBox2.Controls.Add(label10);
        groupBox2.Controls.Add(cmbHeaderType);
        groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox2.Location = new System.Drawing.Point(0, 0);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(730, 380);
        groupBox2.TabIndex = 21;
        groupBox2.TabStop = false;
        groupBox2.Text = "传输(Transport)";
        // 
        // label24
        // 
        label24.AutoSize = true;
        label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label24.Location = new System.Drawing.Point(503, 227);
        label24.Name = "label24";
        label24.Size = new System.Drawing.Size(161, 17);
        label24.TabIndex = 35;
        label24.Text = "3)QUIC 加密密钥/Kcp seed";
        // 
        // label23
        // 
        label23.AutoSize = true;
        label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label23.Location = new System.Drawing.Point(503, 138);
        label23.Name = "label23";
        label23.Size = new System.Drawing.Size(95, 17);
        label23.TabIndex = 34;
        label23.Text = "4)QUIC securty";
        // 
        // panTlsMore
        // 
        panTlsMore.Controls.Add(label21);
        panTlsMore.Controls.Add(cmbAllowInsecure);
        panTlsMore.Dock = System.Windows.Forms.DockStyle.Bottom;
        panTlsMore.Location = new System.Drawing.Point(3, 317);
        panTlsMore.Name = "panTlsMore";
        panTlsMore.Size = new System.Drawing.Size(724, 60);
        panTlsMore.TabIndex = 33;
        // 
        // label21
        // 
        label21.AutoSize = true;
        label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label21.Location = new System.Drawing.Point(9, 3);
        label21.Name = "label21";
        label21.Size = new System.Drawing.Size(168, 17);
        label21.TabIndex = 31;
        label21.Text = "跳过证书验证(AllowInsecure)";
        // 
        // cmbAllowInsecure
        // 
        cmbAllowInsecure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbAllowInsecure.FormattingEnabled = true;
        cmbAllowInsecure.Items.AddRange(new object[] { "", "true", "false" });
        cmbAllowInsecure.Location = new System.Drawing.Point(194, 0);
        cmbAllowInsecure.Name = "cmbAllowInsecure";
        cmbAllowInsecure.Size = new System.Drawing.Size(143, 25);
        cmbAllowInsecure.TabIndex = 30;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new System.Drawing.Point(346, 25);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(67, 17);
        label9.TabIndex = 15;
        label9.Text = "*默认值tcp";
        // 
        // label20
        // 
        label20.AutoSize = true;
        label20.Location = new System.Drawing.Point(503, 121);
        label20.Name = "label20";
        label20.Size = new System.Drawing.Size(149, 17);
        label20.TabIndex = 29;
        label20.Text = "3)h2 host 中间逗号(,)隔开";
        // 
        // txtPath
        // 
        txtPath.Location = new System.Drawing.Point(197, 190);
        txtPath.Multiline = true;
        txtPath.Name = "txtPath";
        txtPath.Size = new System.Drawing.Size(300, 90);
        txtPath.TabIndex = 28;
        // 
        // cmbNetwork
        // 
        cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbNetwork.FormattingEnabled = true;
        cmbNetwork.Items.AddRange(new object[] { "tcp", "kcp", "ws", "h2", "quic" });
        cmbNetwork.Location = new System.Drawing.Point(197, 22);
        cmbNetwork.Name = "cmbNetwork";
        cmbNetwork.Size = new System.Drawing.Size(143, 25);
        cmbNetwork.TabIndex = 12;
        cmbNetwork.SelectedIndexChanged += cmbNetwork_SelectedIndexChanged;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new System.Drawing.Point(12, 25);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(114, 17);
        label7.TabIndex = 13;
        label7.Text = "传输协议(Network)";
        // 
        // label19
        // 
        label19.AutoSize = true;
        label19.Location = new System.Drawing.Point(12, 193);
        label19.Name = "label19";
        label19.Size = new System.Drawing.Size(65, 17);
        label19.TabIndex = 27;
        label19.Text = "路径(Path)";
        // 
        // label18
        // 
        label18.AutoSize = true;
        label18.Location = new System.Drawing.Point(503, 210);
        label18.Name = "label18";
        label18.Size = new System.Drawing.Size(63, 17);
        label18.TabIndex = 26;
        label18.Text = "2)h2 path";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Location = new System.Drawing.Point(503, 104);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(63, 17);
        label17.TabIndex = 25;
        label17.Text = "2)ws host";
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.Location = new System.Drawing.Point(503, 193);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(64, 17);
        label16.TabIndex = 24;
        label16.Text = "1)ws path";
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new System.Drawing.Point(503, 87);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(158, 17);
        label14.TabIndex = 23;
        label14.Text = "1)http host 中间逗号(,)隔开";
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Location = new System.Drawing.Point(12, 289);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(28, 17);
        label15.TabIndex = 22;
        label15.Text = "TLS";
        // 
        // cmbStreamSecurity
        // 
        cmbStreamSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbStreamSecurity.FormattingEnabled = true;
        cmbStreamSecurity.Items.AddRange(new object[] { "", "tls", "xtls" });
        cmbStreamSecurity.Location = new System.Drawing.Point(197, 286);
        cmbStreamSecurity.Name = "cmbStreamSecurity";
        cmbStreamSecurity.Size = new System.Drawing.Size(143, 25);
        cmbStreamSecurity.TabIndex = 21;
        cmbStreamSecurity.SelectedIndexChanged += cmbStreamSecurity_SelectedIndexChanged;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new System.Drawing.Point(346, 56);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(215, 17);
        label12.TabIndex = 20;
        label12.Text = "*tcp或kcp或QUIC伪装类型, 默认none";
        // 
        // txtRequestHost
        // 
        txtRequestHost.Location = new System.Drawing.Point(197, 84);
        txtRequestHost.Multiline = true;
        txtRequestHost.Name = "txtRequestHost";
        txtRequestHost.Size = new System.Drawing.Size(300, 100);
        txtRequestHost.TabIndex = 16;
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new System.Drawing.Point(12, 53);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(162, 17);
        label11.TabIndex = 19;
        label11.Text = "伪装类型(CamouflageType)";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new System.Drawing.Point(12, 87);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(179, 17);
        label10.TabIndex = 17;
        label10.Text = "伪装域名(CamouflageDomain)";
        // 
        // cmbHeaderType
        // 
        cmbHeaderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbHeaderType.FormattingEnabled = true;
        cmbHeaderType.Items.AddRange(new object[] { "none", "http", "srtp", "utp", "wechat-video", "dtls", "wireguard" });
        cmbHeaderType.Location = new System.Drawing.Point(197, 53);
        cmbHeaderType.Name = "cmbHeaderType";
        cmbHeaderType.Size = new System.Drawing.Size(143, 25);
        cmbHeaderType.TabIndex = 18;
        // 
        // panel1
        // 
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(730, 10);
        panel1.TabIndex = 6;
        // 
        // btnOK
        // 
        btnOK.Dock = System.Windows.Forms.DockStyle.Left;
        btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        btnOK.Location = new System.Drawing.Point(403, 12);
        btnOK.Name = "btnOK";
        btnOK.Size = new System.Drawing.Size(75, 35);
        btnOK.TabIndex = 5;
        btnOK.Text = "&确定";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // btnClose
        // 
        btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        btnClose.Location = new System.Drawing.Point(252, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(75, 35);
        btnClose.TabIndex = 4;
        btnClose.Text = "&取消";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // panel2
        // 
        panel2.Controls.Add(tableLayoutPanel1);
        panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        panel2.Location = new System.Drawing.Point(0, 620);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(730, 60);
        panel2.TabIndex = 7;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(btnClose, 0, 1);
        tableLayoutPanel1.Controls.Add(btnOK, 2, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(730, 60);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // panelServer
        // 
        panelServer.Controls.Add(groupBox1);
        panelServer.Dock = System.Windows.Forms.DockStyle.Top;
        panelServer.Location = new System.Drawing.Point(0, 10);
        panelServer.Name = "panelServer";
        panelServer.Size = new System.Drawing.Size(730, 230);
        panelServer.TabIndex = 36;
        // 
        // panel4
        // 
        panel4.Controls.Add(groupBox2);
        panel4.Dock = System.Windows.Forms.DockStyle.Fill;
        panel4.Location = new System.Drawing.Point(0, 240);
        panel4.Name = "panel4";
        panel4.Size = new System.Drawing.Size(730, 380);
        panel4.TabIndex = 37;
        // 
        // ConfigVLESSForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        CancelButton = btnClose;
        ClientSize = new System.Drawing.Size(730, 680);
        Controls.Add(panel4);
        Controls.Add(panelServer);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Margin = new System.Windows.Forms.Padding(451392, 17286, 451392, 17286);
        Name = "ConfigVLESSForm";
        Text = "VLESS";
        Load += AddServer5Form_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        panTlsMore.ResumeLayout(false);
        panTlsMore.PerformLayout();
        panel2.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        panelServer.ResumeLayout(false);
        panel4.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtRemarks;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
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
    private System.Windows.Forms.ComboBox cmbFlow;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panelServer;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
}