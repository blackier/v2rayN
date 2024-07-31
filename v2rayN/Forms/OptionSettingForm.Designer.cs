namespace v2rayN.Forms;

partial class OptionSettingForm
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
        btnClose = new System.Windows.Forms.Button();
        tabControl1 = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        groupBox1 = new System.Windows.Forms.GroupBox();
        chkdefAllowInsecure = new System.Windows.Forms.CheckBox();
        label16 = new System.Windows.Forms.Label();
        cmblistenerType = new System.Windows.Forms.ComboBox();
        chksniffingEnabled = new System.Windows.Forms.CheckBox();
        txtremoteDNS = new System.Windows.Forms.TextBox();
        label14 = new System.Windows.Forms.Label();
        chkmuxEnabled = new System.Windows.Forms.CheckBox();
        cmbprotocol = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        chkudpEnabled = new System.Windows.Forms.CheckBox();
        chklogEnabled = new System.Windows.Forms.CheckBox();
        cmbloglevel = new System.Windows.Forms.ComboBox();
        label5 = new System.Windows.Forms.Label();
        txtlocalPort = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        tabPage2 = new System.Windows.Forms.TabPage();
        groupBox2 = new System.Windows.Forms.GroupBox();
        tabControl_Routing = new System.Windows.Forms.TabControl();
        tabPage3 = new System.Windows.Forms.TabPage();
        txtUseragent = new System.Windows.Forms.TextBox();
        tabPage4 = new System.Windows.Forms.TabPage();
        txtUserdirect = new System.Windows.Forms.TextBox();
        tabPage5 = new System.Windows.Forms.TabPage();
        txtUserblock = new System.Windows.Forms.TextBox();
        panel3 = new System.Windows.Forms.Panel();
        label3 = new System.Windows.Forms.Label();
        cmbroutingMode = new System.Windows.Forms.ComboBox();
        linkLabelRoutingDoc = new System.Windows.Forms.LinkLabel();
        labRoutingTips = new System.Windows.Forms.Label();
        cmbdomainStrategy = new System.Windows.Forms.ComboBox();
        tabPage6 = new System.Windows.Forms.TabPage();
        groupBox3 = new System.Windows.Forms.GroupBox();
        label6 = new System.Windows.Forms.Label();
        chkKcpcongestion = new System.Windows.Forms.CheckBox();
        txtKcpmtu = new System.Windows.Forms.TextBox();
        txtKcpwriteBufferSize = new System.Windows.Forms.TextBox();
        label7 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        txtKcptti = new System.Windows.Forms.TextBox();
        txtKcpreadBufferSize = new System.Windows.Forms.TextBox();
        label9 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        txtKcpuplinkCapacity = new System.Windows.Forms.TextBox();
        txtKcpdownlinkCapacity = new System.Windows.Forms.TextBox();
        label8 = new System.Windows.Forms.Label();
        tabPage7 = new System.Windows.Forms.TabPage();
        groupBox4 = new System.Windows.Forms.GroupBox();
        chkAutoRun = new System.Windows.Forms.CheckBox();
        chkKeepOlderDedupl = new System.Windows.Forms.CheckBox();
        chkAllowLANConn = new System.Windows.Forms.CheckBox();
        cbFreshrate = new System.Windows.Forms.ComboBox();
        chkEnableStatistics = new System.Windows.Forms.CheckBox();
        lbFreshrate = new System.Windows.Forms.Label();
        panel2 = new System.Windows.Forms.Panel();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        btnOK = new System.Windows.Forms.Button();
        panel1 = new System.Windows.Forms.Panel();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        groupBox1.SuspendLayout();
        tabPage2.SuspendLayout();
        groupBox2.SuspendLayout();
        tabControl_Routing.SuspendLayout();
        tabPage3.SuspendLayout();
        tabPage4.SuspendLayout();
        tabPage5.SuspendLayout();
        panel3.SuspendLayout();
        tabPage6.SuspendLayout();
        groupBox3.SuspendLayout();
        tabPage7.SuspendLayout();
        groupBox4.SuspendLayout();
        panel2.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnClose
        // 
        btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        btnClose.Location = new System.Drawing.Point(247, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(75, 35);
        btnClose.TabIndex = 7;
        btnClose.Text = "&取消";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage6);
        tabControl1.Controls.Add(tabPage7);
        tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl1.Location = new System.Drawing.Point(0, 10);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(720, 439);
        tabControl1.TabIndex = 10;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(groupBox1);
        tabPage1.Location = new System.Drawing.Point(4, 26);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(3);
        tabPage1.Size = new System.Drawing.Size(712, 409);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Core: 基础设置";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(chkdefAllowInsecure);
        groupBox1.Controls.Add(label16);
        groupBox1.Controls.Add(cmblistenerType);
        groupBox1.Controls.Add(chksniffingEnabled);
        groupBox1.Controls.Add(txtremoteDNS);
        groupBox1.Controls.Add(label14);
        groupBox1.Controls.Add(chkmuxEnabled);
        groupBox1.Controls.Add(cmbprotocol);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(chkudpEnabled);
        groupBox1.Controls.Add(chklogEnabled);
        groupBox1.Controls.Add(cmbloglevel);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(txtlocalPort);
        groupBox1.Controls.Add(label2);
        groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox1.Location = new System.Drawing.Point(3, 3);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(706, 403);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        // 
        // chkdefAllowInsecure
        // 
        chkdefAllowInsecure.AutoSize = true;
        chkdefAllowInsecure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        chkdefAllowInsecure.Location = new System.Drawing.Point(100, 186);
        chkdefAllowInsecure.Name = "chkdefAllowInsecure";
        chkdefAllowInsecure.Size = new System.Drawing.Size(99, 21);
        chkdefAllowInsecure.TabIndex = 35;
        chkdefAllowInsecure.Text = "跳过证书校验";
        chkdefAllowInsecure.UseVisualStyleBackColor = true;
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label16.Location = new System.Drawing.Point(6, 50);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(56, 17);
        label16.TabIndex = 34;
        label16.Text = "代理模式";
        // 
        // cmblistenerType
        // 
        cmblistenerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmblistenerType.FormattingEnabled = true;
        cmblistenerType.Items.AddRange(new object[] { "关闭系统代理", "打开系统代理" });
        cmblistenerType.Location = new System.Drawing.Point(100, 47);
        cmblistenerType.Name = "cmblistenerType";
        cmblistenerType.Size = new System.Drawing.Size(276, 25);
        cmblistenerType.TabIndex = 33;
        // 
        // chksniffingEnabled
        // 
        chksniffingEnabled.AutoSize = true;
        chksniffingEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        chksniffingEnabled.Location = new System.Drawing.Point(100, 105);
        chksniffingEnabled.Name = "chksniffingEnabled";
        chksniffingEnabled.Size = new System.Drawing.Size(75, 21);
        chksniffingEnabled.TabIndex = 31;
        chksniffingEnabled.Text = "流量探测";
        chksniffingEnabled.UseVisualStyleBackColor = true;
        // 
        // txtremoteDNS
        // 
        txtremoteDNS.Location = new System.Drawing.Point(6, 244);
        txtremoteDNS.Multiline = true;
        txtremoteDNS.Name = "txtremoteDNS";
        txtremoteDNS.Size = new System.Drawing.Size(694, 153);
        txtremoteDNS.TabIndex = 30;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new System.Drawing.Point(6, 224);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(213, 17);
        label14.TabIndex = 29;
        label14.Text = "自定义DNS服务器，复数时逗号(,)分割";
        // 
        // chkmuxEnabled
        // 
        chkmuxEnabled.AutoSize = true;
        chkmuxEnabled.Location = new System.Drawing.Point(100, 132);
        chkmuxEnabled.Name = "chkmuxEnabled";
        chkmuxEnabled.Size = new System.Drawing.Size(75, 21);
        chkmuxEnabled.TabIndex = 20;
        chkmuxEnabled.Text = "多路复用";
        chkmuxEnabled.UseVisualStyleBackColor = true;
        // 
        // cmbprotocol
        // 
        cmbprotocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbprotocol.Enabled = false;
        cmbprotocol.FormattingEnabled = true;
        cmbprotocol.Items.AddRange(new object[] { "socks", "http" });
        cmbprotocol.Location = new System.Drawing.Point(279, 16);
        cmbprotocol.Name = "cmbprotocol";
        cmbprotocol.Size = new System.Drawing.Size(97, 25);
        cmbprotocol.TabIndex = 12;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(184, 19);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(89, 17);
        label1.TabIndex = 11;
        label1.Text = "协议(Protocol)";
        // 
        // chkudpEnabled
        // 
        chkudpEnabled.AutoSize = true;
        chkudpEnabled.Location = new System.Drawing.Point(100, 78);
        chkudpEnabled.Name = "chkudpEnabled";
        chkudpEnabled.Size = new System.Drawing.Size(52, 21);
        chkudpEnabled.TabIndex = 10;
        chkudpEnabled.Text = "UDP";
        chkudpEnabled.UseVisualStyleBackColor = true;
        // 
        // chklogEnabled
        // 
        chklogEnabled.AutoSize = true;
        chklogEnabled.Location = new System.Drawing.Point(100, 159);
        chklogEnabled.Name = "chklogEnabled";
        chklogEnabled.Size = new System.Drawing.Size(99, 21);
        chklogEnabled.TabIndex = 9;
        chklogEnabled.Text = "记录本地日志";
        chklogEnabled.UseVisualStyleBackColor = true;
        // 
        // cmbloglevel
        // 
        cmbloglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbloglevel.FormattingEnabled = true;
        cmbloglevel.Items.AddRange(new object[] { "debug", "info", "warning", "error", "none" });
        cmbloglevel.Location = new System.Drawing.Point(503, 16);
        cmbloglevel.Name = "cmbloglevel";
        cmbloglevel.Size = new System.Drawing.Size(97, 25);
        cmbloglevel.TabIndex = 6;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(382, 19);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(115, 17);
        label5.TabIndex = 8;
        label5.Text = "日志等级(LogLevel)";
        // 
        // txtlocalPort
        // 
        txtlocalPort.Location = new System.Drawing.Point(100, 16);
        txtlocalPort.Name = "txtlocalPort";
        txtlocalPort.Size = new System.Drawing.Size(78, 23);
        txtlocalPort.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(6, 19);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(88, 17);
        label2.TabIndex = 2;
        label2.Text = "监听端口(Port)";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(groupBox2);
        tabPage2.Location = new System.Drawing.Point(4, 26);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(712, 409);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Core: 路由设置";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(tabControl_Routing);
        groupBox2.Controls.Add(panel3);
        groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox2.Location = new System.Drawing.Point(3, 3);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(706, 403);
        groupBox2.TabIndex = 12;
        groupBox2.TabStop = false;
        // 
        // tabControl_Routing
        // 
        tabControl_Routing.Controls.Add(tabPage3);
        tabControl_Routing.Controls.Add(tabPage4);
        tabControl_Routing.Controls.Add(tabPage5);
        tabControl_Routing.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl_Routing.Location = new System.Drawing.Point(3, 113);
        tabControl_Routing.Name = "tabControl_Routing";
        tabControl_Routing.SelectedIndex = 0;
        tabControl_Routing.Size = new System.Drawing.Size(700, 287);
        tabControl_Routing.TabIndex = 12;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(txtUseragent);
        tabPage3.Location = new System.Drawing.Point(4, 26);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(3);
        tabPage3.Size = new System.Drawing.Size(692, 257);
        tabPage3.TabIndex = 0;
        tabPage3.Text = "代理";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // txtUseragent
        // 
        txtUseragent.Dock = System.Windows.Forms.DockStyle.Fill;
        txtUseragent.Location = new System.Drawing.Point(3, 3);
        txtUseragent.MaxLength = 0;
        txtUseragent.Multiline = true;
        txtUseragent.Name = "txtUseragent";
        txtUseragent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtUseragent.Size = new System.Drawing.Size(686, 251);
        txtUseragent.TabIndex = 0;
        // 
        // tabPage4
        // 
        tabPage4.Controls.Add(txtUserdirect);
        tabPage4.Location = new System.Drawing.Point(4, 26);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(3);
        tabPage4.Size = new System.Drawing.Size(692, 257);
        tabPage4.TabIndex = 1;
        tabPage4.Text = "直连";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // txtUserdirect
        // 
        txtUserdirect.Dock = System.Windows.Forms.DockStyle.Fill;
        txtUserdirect.Location = new System.Drawing.Point(3, 3);
        txtUserdirect.MaxLength = 0;
        txtUserdirect.Multiline = true;
        txtUserdirect.Name = "txtUserdirect";
        txtUserdirect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtUserdirect.Size = new System.Drawing.Size(686, 251);
        txtUserdirect.TabIndex = 1;
        // 
        // tabPage5
        // 
        tabPage5.Controls.Add(txtUserblock);
        tabPage5.Location = new System.Drawing.Point(4, 26);
        tabPage5.Name = "tabPage5";
        tabPage5.Padding = new System.Windows.Forms.Padding(3);
        tabPage5.Size = new System.Drawing.Size(692, 257);
        tabPage5.TabIndex = 2;
        tabPage5.Text = "黑名单";
        tabPage5.UseVisualStyleBackColor = true;
        // 
        // txtUserblock
        // 
        txtUserblock.Dock = System.Windows.Forms.DockStyle.Fill;
        txtUserblock.Location = new System.Drawing.Point(3, 3);
        txtUserblock.MaxLength = 0;
        txtUserblock.Multiline = true;
        txtUserblock.Name = "txtUserblock";
        txtUserblock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtUserblock.Size = new System.Drawing.Size(686, 251);
        txtUserblock.TabIndex = 1;
        // 
        // panel3
        // 
        panel3.Controls.Add(label3);
        panel3.Controls.Add(cmbroutingMode);
        panel3.Controls.Add(linkLabelRoutingDoc);
        panel3.Controls.Add(labRoutingTips);
        panel3.Controls.Add(cmbdomainStrategy);
        panel3.Dock = System.Windows.Forms.DockStyle.Top;
        panel3.Location = new System.Drawing.Point(3, 19);
        panel3.Name = "panel3";
        panel3.Size = new System.Drawing.Size(700, 94);
        panel3.TabIndex = 19;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new System.Drawing.Point(7, 37);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(80, 17);
        label3.TabIndex = 20;
        label3.Text = "预设路由规则";
        // 
        // cmbroutingMode
        // 
        cmbroutingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbroutingMode.FormattingEnabled = true;
        cmbroutingMode.Items.AddRange(new object[] { "下拉选择添加", "清空", "私有地址", "常见大陆地址", "常见非大陆地址", "常见广告地址" });
        cmbroutingMode.Location = new System.Drawing.Point(93, 34);
        cmbroutingMode.Name = "cmbroutingMode";
        cmbroutingMode.Size = new System.Drawing.Size(160, 25);
        cmbroutingMode.TabIndex = 14;
        cmbroutingMode.SelectedIndexChanged += cmbroutingMode_SelectedIndexChanged;
        // 
        // linkLabelRoutingDoc
        // 
        linkLabelRoutingDoc.AutoSize = true;
        linkLabelRoutingDoc.LinkColor = System.Drawing.Color.Black;
        linkLabelRoutingDoc.Location = new System.Drawing.Point(7, 6);
        linkLabelRoutingDoc.Margin = new System.Windows.Forms.Padding(0);
        linkLabelRoutingDoc.Name = "linkLabelRoutingDoc";
        linkLabelRoutingDoc.Size = new System.Drawing.Size(56, 17);
        linkLabelRoutingDoc.TabIndex = 19;
        linkLabelRoutingDoc.TabStop = true;
        linkLabelRoutingDoc.Text = "域名解析";
        linkLabelRoutingDoc.LinkClicked += linkLabelRoutingDoc_LinkClicked;
        // 
        // labRoutingTips
        // 
        labRoutingTips.AutoSize = true;
        labRoutingTips.ForeColor = System.Drawing.Color.Black;
        labRoutingTips.Location = new System.Drawing.Point(7, 71);
        labRoutingTips.Margin = new System.Windows.Forms.Padding(1);
        labRoutingTips.Name = "labRoutingTips";
        labRoutingTips.Padding = new System.Windows.Forms.Padding(1);
        labRoutingTips.Size = new System.Drawing.Size(245, 19);
        labRoutingTips.TabIndex = 13;
        labRoutingTips.Text = "*设置路由规则，逗号 (,)分割，支持域名和IP";
        // 
        // cmbdomainStrategy
        // 
        cmbdomainStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbdomainStrategy.FormattingEnabled = true;
        cmbdomainStrategy.Items.AddRange(new object[] { "AsIs", "IPIfNonMatch", "IPOnDemand" });
        cmbdomainStrategy.Location = new System.Drawing.Point(93, 3);
        cmbdomainStrategy.Name = "cmbdomainStrategy";
        cmbdomainStrategy.Size = new System.Drawing.Size(160, 25);
        cmbdomainStrategy.TabIndex = 16;
        // 
        // tabPage6
        // 
        tabPage6.Controls.Add(groupBox3);
        tabPage6.Location = new System.Drawing.Point(4, 26);
        tabPage6.Name = "tabPage6";
        tabPage6.Padding = new System.Windows.Forms.Padding(3);
        tabPage6.Size = new System.Drawing.Size(712, 409);
        tabPage6.TabIndex = 2;
        tabPage6.Text = "Core: KCP设置";
        tabPage6.UseVisualStyleBackColor = true;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(label6);
        groupBox3.Controls.Add(chkKcpcongestion);
        groupBox3.Controls.Add(txtKcpmtu);
        groupBox3.Controls.Add(txtKcpwriteBufferSize);
        groupBox3.Controls.Add(label7);
        groupBox3.Controls.Add(label10);
        groupBox3.Controls.Add(txtKcptti);
        groupBox3.Controls.Add(txtKcpreadBufferSize);
        groupBox3.Controls.Add(label9);
        groupBox3.Controls.Add(label11);
        groupBox3.Controls.Add(txtKcpuplinkCapacity);
        groupBox3.Controls.Add(txtKcpdownlinkCapacity);
        groupBox3.Controls.Add(label8);
        groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox3.Location = new System.Drawing.Point(3, 3);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(706, 403);
        groupBox3.TabIndex = 21;
        groupBox3.TabStop = false;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new System.Drawing.Point(6, 19);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(30, 17);
        label6.TabIndex = 4;
        label6.Text = "mtu";
        // 
        // chkKcpcongestion
        // 
        chkKcpcongestion.AutoSize = true;
        chkKcpcongestion.Location = new System.Drawing.Point(104, 103);
        chkKcpcongestion.Name = "chkKcpcongestion";
        chkKcpcongestion.Size = new System.Drawing.Size(91, 21);
        chkKcpcongestion.TabIndex = 20;
        chkKcpcongestion.Text = "congestion";
        chkKcpcongestion.UseVisualStyleBackColor = true;
        // 
        // txtKcpmtu
        // 
        txtKcpmtu.Location = new System.Drawing.Point(105, 16);
        txtKcpmtu.Name = "txtKcpmtu";
        txtKcpmtu.Size = new System.Drawing.Size(100, 23);
        txtKcpmtu.TabIndex = 5;
        // 
        // txtKcpwriteBufferSize
        // 
        txtKcpwriteBufferSize.Location = new System.Drawing.Point(385, 74);
        txtKcpwriteBufferSize.Name = "txtKcpwriteBufferSize";
        txtKcpwriteBufferSize.Size = new System.Drawing.Size(100, 23);
        txtKcpwriteBufferSize.TabIndex = 15;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new System.Drawing.Point(270, 19);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(19, 17);
        label7.TabIndex = 6;
        label7.Text = "tti";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new System.Drawing.Point(270, 77);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(94, 17);
        label10.TabIndex = 14;
        label10.Text = "writeBufferSize";
        // 
        // txtKcptti
        // 
        txtKcptti.Location = new System.Drawing.Point(385, 16);
        txtKcptti.Name = "txtKcptti";
        txtKcptti.Size = new System.Drawing.Size(100, 23);
        txtKcptti.TabIndex = 7;
        // 
        // txtKcpreadBufferSize
        // 
        txtKcpreadBufferSize.Location = new System.Drawing.Point(105, 74);
        txtKcpreadBufferSize.Name = "txtKcpreadBufferSize";
        txtKcpreadBufferSize.Size = new System.Drawing.Size(100, 23);
        txtKcpreadBufferSize.TabIndex = 13;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new System.Drawing.Point(6, 48);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(92, 17);
        label9.TabIndex = 8;
        label9.Text = "uplinkCapacity";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new System.Drawing.Point(6, 77);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(93, 17);
        label11.TabIndex = 12;
        label11.Text = "readBufferSize";
        // 
        // txtKcpuplinkCapacity
        // 
        txtKcpuplinkCapacity.Location = new System.Drawing.Point(105, 45);
        txtKcpuplinkCapacity.Name = "txtKcpuplinkCapacity";
        txtKcpuplinkCapacity.Size = new System.Drawing.Size(100, 23);
        txtKcpuplinkCapacity.TabIndex = 9;
        // 
        // txtKcpdownlinkCapacity
        // 
        txtKcpdownlinkCapacity.Location = new System.Drawing.Point(385, 45);
        txtKcpdownlinkCapacity.Name = "txtKcpdownlinkCapacity";
        txtKcpdownlinkCapacity.Size = new System.Drawing.Size(100, 23);
        txtKcpdownlinkCapacity.TabIndex = 11;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new System.Drawing.Point(270, 45);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(109, 17);
        label8.TabIndex = 10;
        label8.Text = "downlinkCapacity";
        // 
        // tabPage7
        // 
        tabPage7.Controls.Add(groupBox4);
        tabPage7.Location = new System.Drawing.Point(4, 26);
        tabPage7.Name = "tabPage7";
        tabPage7.Padding = new System.Windows.Forms.Padding(3);
        tabPage7.Size = new System.Drawing.Size(712, 409);
        tabPage7.TabIndex = 3;
        tabPage7.Text = "v2rayN设置";
        tabPage7.UseVisualStyleBackColor = true;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(chkAutoRun);
        groupBox4.Controls.Add(chkKeepOlderDedupl);
        groupBox4.Controls.Add(chkAllowLANConn);
        groupBox4.Controls.Add(cbFreshrate);
        groupBox4.Controls.Add(chkEnableStatistics);
        groupBox4.Controls.Add(lbFreshrate);
        groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox4.Location = new System.Drawing.Point(3, 3);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(706, 403);
        groupBox4.TabIndex = 34;
        groupBox4.TabStop = false;
        // 
        // chkAutoRun
        // 
        chkAutoRun.AutoSize = true;
        chkAutoRun.Location = new System.Drawing.Point(6, 22);
        chkAutoRun.Name = "chkAutoRun";
        chkAutoRun.Size = new System.Drawing.Size(75, 21);
        chkAutoRun.TabIndex = 23;
        chkAutoRun.Text = "开机启动";
        chkAutoRun.UseVisualStyleBackColor = true;
        // 
        // chkKeepOlderDedupl
        // 
        chkKeepOlderDedupl.AutoSize = true;
        chkKeepOlderDedupl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        chkKeepOlderDedupl.Location = new System.Drawing.Point(6, 103);
        chkKeepOlderDedupl.Name = "chkKeepOlderDedupl";
        chkKeepOlderDedupl.Size = new System.Drawing.Size(159, 21);
        chkKeepOlderDedupl.TabIndex = 33;
        chkKeepOlderDedupl.Text = "去重时保留序号较小的项";
        chkKeepOlderDedupl.UseVisualStyleBackColor = true;
        // 
        // chkAllowLANConn
        // 
        chkAllowLANConn.AutoSize = true;
        chkAllowLANConn.Location = new System.Drawing.Point(6, 49);
        chkAllowLANConn.Name = "chkAllowLANConn";
        chkAllowLANConn.Size = new System.Drawing.Size(135, 21);
        chkAllowLANConn.TabIndex = 29;
        chkAllowLANConn.Text = "允许来自LAN的连接";
        chkAllowLANConn.UseVisualStyleBackColor = true;
        // 
        // cbFreshrate
        // 
        cbFreshrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbFreshrate.FormattingEnabled = true;
        cbFreshrate.Location = new System.Drawing.Point(107, 130);
        cbFreshrate.Name = "cbFreshrate";
        cbFreshrate.Size = new System.Drawing.Size(105, 25);
        cbFreshrate.TabIndex = 32;
        // 
        // chkEnableStatistics
        // 
        chkEnableStatistics.AutoSize = true;
        chkEnableStatistics.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        chkEnableStatistics.Location = new System.Drawing.Point(6, 76);
        chkEnableStatistics.Name = "chkEnableStatistics";
        chkEnableStatistics.Size = new System.Drawing.Size(159, 21);
        chkEnableStatistics.TabIndex = 29;
        chkEnableStatistics.Text = "流量计速，需要重启软件";
        chkEnableStatistics.UseVisualStyleBackColor = true;
        // 
        // lbFreshrate
        // 
        lbFreshrate.AutoSize = true;
        lbFreshrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        lbFreshrate.Location = new System.Drawing.Point(21, 133);
        lbFreshrate.Name = "lbFreshrate";
        lbFreshrate.Size = new System.Drawing.Size(80, 17);
        lbFreshrate.TabIndex = 30;
        lbFreshrate.Text = "计速刷新频率";
        // 
        // panel2
        // 
        panel2.Controls.Add(tableLayoutPanel1);
        panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        panel2.Location = new System.Drawing.Point(0, 449);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(720, 60);
        panel2.TabIndex = 11;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(btnOK, 2, 1);
        tableLayoutPanel1.Controls.Add(btnClose, 0, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(720, 60);
        tableLayoutPanel1.TabIndex = 9;
        // 
        // btnOK
        // 
        btnOK.Dock = System.Windows.Forms.DockStyle.Left;
        btnOK.Location = new System.Drawing.Point(398, 12);
        btnOK.Name = "btnOK";
        btnOK.Size = new System.Drawing.Size(75, 35);
        btnOK.TabIndex = 8;
        btnOK.Text = "&确定";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // panel1
        // 
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(720, 10);
        panel1.TabIndex = 9;
        // 
        // OptionSettingForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        CancelButton = btnClose;
        ClientSize = new System.Drawing.Size(720, 509);
        Controls.Add(tabControl1);
        Controls.Add(panel2);
        Controls.Add(panel1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Margin = new System.Windows.Forms.Padding(11479, 1022, 11479, 1022);
        Name = "OptionSettingForm";
        Text = "Settings";
        Load += OptionSettingForm_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        tabPage2.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        tabControl_Routing.ResumeLayout(false);
        tabPage3.ResumeLayout(false);
        tabPage3.PerformLayout();
        tabPage4.ResumeLayout(false);
        tabPage4.PerformLayout();
        tabPage5.ResumeLayout(false);
        tabPage5.PerformLayout();
        panel3.ResumeLayout(false);
        panel3.PerformLayout();
        tabPage6.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        tabPage7.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        panel2.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox cmbloglevel;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtlocalPort;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chklogEnabled;
    private System.Windows.Forms.CheckBox chkudpEnabled;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox cmbprotocol;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkmuxEnabled;
    private System.Windows.Forms.TabControl tabControl_Routing;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.Label labRoutingTips;
    private System.Windows.Forms.TextBox txtUseragent;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.TextBox txtUserdirect;
    private System.Windows.Forms.TextBox txtUserblock;
    private System.Windows.Forms.TabPage tabPage6;
    private System.Windows.Forms.TextBox txtKcpmtu;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtKcptti;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtKcpwriteBufferSize;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtKcpreadBufferSize;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtKcpdownlinkCapacity;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtKcpuplinkCapacity;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.CheckBox chkKcpcongestion;
    private System.Windows.Forms.TabPage tabPage7;
    private System.Windows.Forms.CheckBox chkAutoRun;
    private System.Windows.Forms.CheckBox chkAllowLANConn;
    private System.Windows.Forms.TextBox txtremoteDNS;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ComboBox cmbdomainStrategy;
    private System.Windows.Forms.ComboBox cmbroutingMode;
    private System.Windows.Forms.CheckBox chksniffingEnabled;
    private System.Windows.Forms.CheckBox chkEnableStatistics;
    private System.Windows.Forms.ComboBox cbFreshrate;
    private System.Windows.Forms.Label lbFreshrate;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.ComboBox cmblistenerType;
    private System.Windows.Forms.CheckBox chkKeepOlderDedupl;
    private System.Windows.Forms.LinkLabel linkLabelRoutingDoc;
    private System.Windows.Forms.CheckBox chkdefAllowInsecure;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label3;
}