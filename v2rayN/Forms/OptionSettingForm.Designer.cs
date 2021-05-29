namespace v2rayN.Forms
{
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkdefAllowInsecure = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmblistenerType = new System.Windows.Forms.ComboBox();
            this.chksniffingEnabled = new System.Windows.Forms.CheckBox();
            this.txtremoteDNS = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkmuxEnabled = new System.Windows.Forms.CheckBox();
            this.cmbprotocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkudpEnabled = new System.Windows.Forms.CheckBox();
            this.chklogEnabled = new System.Windows.Forms.CheckBox();
            this.cmbloglevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlocalPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl_Routing = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtUseragent = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtUserdirect = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtUserblock = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbroutingMode = new System.Windows.Forms.ComboBox();
            this.linkLabelRoutingDoc = new System.Windows.Forms.LinkLabel();
            this.labRoutingTips = new System.Windows.Forms.Label();
            this.cmbdomainStrategy = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkKcpcongestion = new System.Windows.Forms.CheckBox();
            this.txtKcpmtu = new System.Windows.Forms.TextBox();
            this.txtKcpwriteBufferSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKcptti = new System.Windows.Forms.TextBox();
            this.txtKcpreadBufferSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKcpuplinkCapacity = new System.Windows.Forms.TextBox();
            this.txtKcpdownlinkCapacity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.chkKeepOlderDedupl = new System.Windows.Forms.CheckBox();
            this.chkAllowLANConn = new System.Windows.Forms.CheckBox();
            this.cbFreshrate = new System.Windows.Forms.ComboBox();
            this.chkEnableStatistics = new System.Windows.Forms.CheckBox();
            this.lbFreshrate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Routing.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClose.Location = new System.Drawing.Point(398, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 439);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Core: basic settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkdefAllowInsecure);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmblistenerType);
            this.groupBox1.Controls.Add(this.chksniffingEnabled);
            this.groupBox1.Controls.Add(this.txtremoteDNS);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.chkmuxEnabled);
            this.groupBox1.Controls.Add(this.cmbprotocol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkudpEnabled);
            this.groupBox1.Controls.Add(this.chklogEnabled);
            this.groupBox1.Controls.Add(this.cmbloglevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtlocalPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 403);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // chkdefAllowInsecure
            // 
            this.chkdefAllowInsecure.AutoSize = true;
            this.chkdefAllowInsecure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkdefAllowInsecure.Location = new System.Drawing.Point(100, 186);
            this.chkdefAllowInsecure.Name = "chkdefAllowInsecure";
            this.chkdefAllowInsecure.Size = new System.Drawing.Size(106, 21);
            this.chkdefAllowInsecure.TabIndex = 35;
            this.chkdefAllowInsecure.Text = "allowInsecure";
            this.chkdefAllowInsecure.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(6, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 17);
            this.label16.TabIndex = 34;
            this.label16.Text = "Http proxy";
            // 
            // cmblistenerType
            // 
            this.cmblistenerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblistenerType.FormattingEnabled = true;
            this.cmblistenerType.Items.AddRange(new object[] {
            "Not Enabled Http Proxy",
            "Open Http proxy and automatically configure proxy server (global mode)",
            "Only open Http proxy, do not automatically configure proxy server (direct mode)",
            "Only open Http proxy and do nothing"});
            this.cmblistenerType.Location = new System.Drawing.Point(100, 47);
            this.cmblistenerType.Name = "cmblistenerType";
            this.cmblistenerType.Size = new System.Drawing.Size(469, 25);
            this.cmblistenerType.TabIndex = 33;
            // 
            // chksniffingEnabled
            // 
            this.chksniffingEnabled.AutoSize = true;
            this.chksniffingEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chksniffingEnabled.Location = new System.Drawing.Point(100, 105);
            this.chksniffingEnabled.Name = "chksniffingEnabled";
            this.chksniffingEnabled.Size = new System.Drawing.Size(119, 21);
            this.chksniffingEnabled.TabIndex = 31;
            this.chksniffingEnabled.Text = "Turn on Sniffing";
            this.chksniffingEnabled.UseVisualStyleBackColor = true;
            // 
            // txtremoteDNS
            // 
            this.txtremoteDNS.Location = new System.Drawing.Point(6, 244);
            this.txtremoteDNS.Multiline = true;
            this.txtremoteDNS.Name = "txtremoteDNS";
            this.txtremoteDNS.Size = new System.Drawing.Size(694, 153);
            this.txtremoteDNS.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(292, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "Custom DNS (multiple, separated by commas (,))";
            // 
            // chkmuxEnabled
            // 
            this.chkmuxEnabled.AutoSize = true;
            this.chkmuxEnabled.Location = new System.Drawing.Point(100, 132);
            this.chkmuxEnabled.Name = "chkmuxEnabled";
            this.chkmuxEnabled.Size = new System.Drawing.Size(180, 21);
            this.chkmuxEnabled.TabIndex = 20;
            this.chkmuxEnabled.Text = "Turn on Mux Multiplexing ";
            this.chkmuxEnabled.UseVisualStyleBackColor = true;
            // 
            // cmbprotocol
            // 
            this.cmbprotocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbprotocol.Enabled = false;
            this.cmbprotocol.FormattingEnabled = true;
            this.cmbprotocol.Items.AddRange(new object[] {
            "socks",
            "http"});
            this.cmbprotocol.Location = new System.Drawing.Point(273, 16);
            this.cmbprotocol.Name = "cmbprotocol";
            this.cmbprotocol.Size = new System.Drawing.Size(97, 25);
            this.cmbprotocol.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "protocol";
            // 
            // chkudpEnabled
            // 
            this.chkudpEnabled.AutoSize = true;
            this.chkudpEnabled.Location = new System.Drawing.Point(100, 78);
            this.chkudpEnabled.Name = "chkudpEnabled";
            this.chkudpEnabled.Size = new System.Drawing.Size(95, 21);
            this.chkudpEnabled.TabIndex = 10;
            this.chkudpEnabled.Text = "Enable UDP";
            this.chkudpEnabled.UseVisualStyleBackColor = true;
            // 
            // chklogEnabled
            // 
            this.chklogEnabled.AutoSize = true;
            this.chklogEnabled.Location = new System.Drawing.Point(100, 159);
            this.chklogEnabled.Name = "chklogEnabled";
            this.chklogEnabled.Size = new System.Drawing.Size(129, 21);
            this.chklogEnabled.TabIndex = 9;
            this.chklogEnabled.Text = "Record local logs";
            this.chklogEnabled.UseVisualStyleBackColor = true;
            // 
            // cmbloglevel
            // 
            this.cmbloglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloglevel.FormattingEnabled = true;
            this.cmbloglevel.Items.AddRange(new object[] {
            "debug",
            "info",
            "warning",
            "error",
            "none"});
            this.cmbloglevel.Location = new System.Drawing.Point(472, 16);
            this.cmbloglevel.Name = "cmbloglevel";
            this.cmbloglevel.Size = new System.Drawing.Size(97, 25);
            this.cmbloglevel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Log level";
            // 
            // txtlocalPort
            // 
            this.txtlocalPort.Location = new System.Drawing.Point(100, 16);
            this.txtlocalPort.Name = "txtlocalPort";
            this.txtlocalPort.Size = new System.Drawing.Size(78, 23);
            this.txtlocalPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Listening port";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Core: Routing settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl_Routing);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 403);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // tabControl_Routing
            // 
            this.tabControl_Routing.Controls.Add(this.tabPage3);
            this.tabControl_Routing.Controls.Add(this.tabPage4);
            this.tabControl_Routing.Controls.Add(this.tabPage5);
            this.tabControl_Routing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Routing.Location = new System.Drawing.Point(3, 113);
            this.tabControl_Routing.Name = "tabControl_Routing";
            this.tabControl_Routing.SelectedIndex = 0;
            this.tabControl_Routing.Size = new System.Drawing.Size(700, 287);
            this.tabControl_Routing.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtUseragent);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 257);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "1.Proxy Domain or IP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtUseragent
            // 
            this.txtUseragent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUseragent.Location = new System.Drawing.Point(3, 3);
            this.txtUseragent.MaxLength = 0;
            this.txtUseragent.Multiline = true;
            this.txtUseragent.Name = "txtUseragent";
            this.txtUseragent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUseragent.Size = new System.Drawing.Size(686, 251);
            this.txtUseragent.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtUserdirect);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(692, 257);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "2.Direct Domain or IP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtUserdirect
            // 
            this.txtUserdirect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserdirect.Location = new System.Drawing.Point(3, 3);
            this.txtUserdirect.MaxLength = 0;
            this.txtUserdirect.Multiline = true;
            this.txtUserdirect.Name = "txtUserdirect";
            this.txtUserdirect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserdirect.Size = new System.Drawing.Size(686, 251);
            this.txtUserdirect.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtUserblock);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(692, 257);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "3.Block Domain or IP";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtUserblock
            // 
            this.txtUserblock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserblock.Location = new System.Drawing.Point(3, 3);
            this.txtUserblock.MaxLength = 0;
            this.txtUserblock.Multiline = true;
            this.txtUserblock.Name = "txtUserblock";
            this.txtUserblock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserblock.Size = new System.Drawing.Size(686, 251);
            this.txtUserblock.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbroutingMode);
            this.panel3.Controls.Add(this.linkLabelRoutingDoc);
            this.panel3.Controls.Add(this.labRoutingTips);
            this.panel3.Controls.Add(this.cmbdomainStrategy);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 94);
            this.panel3.TabIndex = 19;
            // 
            // cmbroutingMode
            // 
            this.cmbroutingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbroutingMode.FormattingEnabled = true;
            this.cmbroutingMode.Items.AddRange(new object[] {
            "Dropdown and add rules",
            "Global",
            "The LAN address",
            "Mainland address",
            "No mainland address",
            "Ad address "});
            this.cmbroutingMode.Location = new System.Drawing.Point(326, 3);
            this.cmbroutingMode.Name = "cmbroutingMode";
            this.cmbroutingMode.Size = new System.Drawing.Size(160, 25);
            this.cmbroutingMode.TabIndex = 14;
            this.cmbroutingMode.SelectedIndexChanged += new System.EventHandler(this.cmbroutingMode_SelectedIndexChanged);
            // 
            // linkLabelRoutingDoc
            // 
            this.linkLabelRoutingDoc.AutoSize = true;
            this.linkLabelRoutingDoc.Location = new System.Drawing.Point(7, 6);
            this.linkLabelRoutingDoc.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabelRoutingDoc.Name = "linkLabelRoutingDoc";
            this.linkLabelRoutingDoc.Size = new System.Drawing.Size(104, 17);
            this.linkLabelRoutingDoc.TabIndex = 19;
            this.linkLabelRoutingDoc.TabStop = true;
            this.linkLabelRoutingDoc.Text = "Domain strategy";
            this.linkLabelRoutingDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRoutingDoc_LinkClicked);
            // 
            // labRoutingTips
            // 
            this.labRoutingTips.AutoSize = true;
            this.labRoutingTips.ForeColor = System.Drawing.Color.Brown;
            this.labRoutingTips.Location = new System.Drawing.Point(7, 71);
            this.labRoutingTips.Margin = new System.Windows.Forms.Padding(1);
            this.labRoutingTips.Name = "labRoutingTips";
            this.labRoutingTips.Padding = new System.Windows.Forms.Padding(1);
            this.labRoutingTips.Size = new System.Drawing.Size(591, 19);
            this.labRoutingTips.TabIndex = 13;
            this.labRoutingTips.Text = "*Set the rules, separated by commas (,); support Domain (pure string / regular / " +
    "subdomain) and IP";
            // 
            // cmbdomainStrategy
            // 
            this.cmbdomainStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdomainStrategy.FormattingEnabled = true;
            this.cmbdomainStrategy.Items.AddRange(new object[] {
            "AsIs",
            "IPIfNonMatch",
            "IPOnDemand"});
            this.cmbdomainStrategy.Location = new System.Drawing.Point(114, 3);
            this.cmbdomainStrategy.Name = "cmbdomainStrategy";
            this.cmbdomainStrategy.Size = new System.Drawing.Size(128, 25);
            this.cmbdomainStrategy.TabIndex = 16;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(712, 409);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Core: KCP settings";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.chkKcpcongestion);
            this.groupBox3.Controls.Add(this.txtKcpmtu);
            this.groupBox3.Controls.Add(this.txtKcpwriteBufferSize);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtKcptti);
            this.groupBox3.Controls.Add(this.txtKcpreadBufferSize);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtKcpuplinkCapacity);
            this.groupBox3.Controls.Add(this.txtKcpdownlinkCapacity);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 403);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "mtu";
            // 
            // chkKcpcongestion
            // 
            this.chkKcpcongestion.AutoSize = true;
            this.chkKcpcongestion.Location = new System.Drawing.Point(104, 103);
            this.chkKcpcongestion.Name = "chkKcpcongestion";
            this.chkKcpcongestion.Size = new System.Drawing.Size(91, 21);
            this.chkKcpcongestion.TabIndex = 20;
            this.chkKcpcongestion.Text = "congestion";
            this.chkKcpcongestion.UseVisualStyleBackColor = true;
            // 
            // txtKcpmtu
            // 
            this.txtKcpmtu.Location = new System.Drawing.Point(105, 16);
            this.txtKcpmtu.Name = "txtKcpmtu";
            this.txtKcpmtu.Size = new System.Drawing.Size(100, 23);
            this.txtKcpmtu.TabIndex = 5;
            // 
            // txtKcpwriteBufferSize
            // 
            this.txtKcpwriteBufferSize.Location = new System.Drawing.Point(385, 74);
            this.txtKcpwriteBufferSize.Name = "txtKcpwriteBufferSize";
            this.txtKcpwriteBufferSize.Size = new System.Drawing.Size(100, 23);
            this.txtKcpwriteBufferSize.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "tti";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "writeBufferSize";
            // 
            // txtKcptti
            // 
            this.txtKcptti.Location = new System.Drawing.Point(385, 16);
            this.txtKcptti.Name = "txtKcptti";
            this.txtKcptti.Size = new System.Drawing.Size(100, 23);
            this.txtKcptti.TabIndex = 7;
            // 
            // txtKcpreadBufferSize
            // 
            this.txtKcpreadBufferSize.Location = new System.Drawing.Point(105, 74);
            this.txtKcpreadBufferSize.Name = "txtKcpreadBufferSize";
            this.txtKcpreadBufferSize.Size = new System.Drawing.Size(100, 23);
            this.txtKcpreadBufferSize.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "uplinkCapacity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "readBufferSize";
            // 
            // txtKcpuplinkCapacity
            // 
            this.txtKcpuplinkCapacity.Location = new System.Drawing.Point(105, 45);
            this.txtKcpuplinkCapacity.Name = "txtKcpuplinkCapacity";
            this.txtKcpuplinkCapacity.Size = new System.Drawing.Size(100, 23);
            this.txtKcpuplinkCapacity.TabIndex = 9;
            // 
            // txtKcpdownlinkCapacity
            // 
            this.txtKcpdownlinkCapacity.Location = new System.Drawing.Point(385, 45);
            this.txtKcpdownlinkCapacity.Name = "txtKcpdownlinkCapacity";
            this.txtKcpdownlinkCapacity.Size = new System.Drawing.Size(100, 23);
            this.txtKcpdownlinkCapacity.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "downlinkCapacity";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox4);
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(712, 409);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "v2rayN settings";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkAutoRun);
            this.groupBox4.Controls.Add(this.chkKeepOlderDedupl);
            this.groupBox4.Controls.Add(this.chkAllowLANConn);
            this.groupBox4.Controls.Add(this.cbFreshrate);
            this.groupBox4.Controls.Add(this.chkEnableStatistics);
            this.groupBox4.Controls.Add(this.lbFreshrate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(706, 403);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(6, 22);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(238, 21);
            this.chkAutoRun.TabIndex = 23;
            this.chkAutoRun.Text = "Automatically start at system startup";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // chkKeepOlderDedupl
            // 
            this.chkKeepOlderDedupl.AutoSize = true;
            this.chkKeepOlderDedupl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkKeepOlderDedupl.Location = new System.Drawing.Point(6, 103);
            this.chkKeepOlderDedupl.Name = "chkKeepOlderDedupl";
            this.chkKeepOlderDedupl.Size = new System.Drawing.Size(209, 21);
            this.chkKeepOlderDedupl.TabIndex = 33;
            this.chkKeepOlderDedupl.Text = "Keep older when deduplication";
            this.chkKeepOlderDedupl.UseVisualStyleBackColor = true;
            // 
            // chkAllowLANConn
            // 
            this.chkAllowLANConn.AutoSize = true;
            this.chkAllowLANConn.Location = new System.Drawing.Point(6, 49);
            this.chkAllowLANConn.Name = "chkAllowLANConn";
            this.chkAllowLANConn.Size = new System.Drawing.Size(213, 21);
            this.chkAllowLANConn.TabIndex = 29;
            this.chkAllowLANConn.Text = "Allow connections from the LAN";
            this.chkAllowLANConn.UseVisualStyleBackColor = true;
            // 
            // cbFreshrate
            // 
            this.cbFreshrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFreshrate.FormattingEnabled = true;
            this.cbFreshrate.Location = new System.Drawing.Point(139, 130);
            this.cbFreshrate.Name = "cbFreshrate";
            this.cbFreshrate.Size = new System.Drawing.Size(105, 25);
            this.cbFreshrate.TabIndex = 32;
            // 
            // chkEnableStatistics
            // 
            this.chkEnableStatistics.AutoSize = true;
            this.chkEnableStatistics.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkEnableStatistics.Location = new System.Drawing.Point(6, 76);
            this.chkEnableStatistics.Name = "chkEnableStatistics";
            this.chkEnableStatistics.Size = new System.Drawing.Size(547, 21);
            this.chkEnableStatistics.TabIndex = 29;
            this.chkEnableStatistics.Text = "Enable Statistics (Realtime netspeed and traffic records. Require restart the v2r" +
    "ayN client)";
            this.chkEnableStatistics.UseVisualStyleBackColor = true;
            // 
            // lbFreshrate
            // 
            this.lbFreshrate.AutoSize = true;
            this.lbFreshrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbFreshrate.Location = new System.Drawing.Point(21, 133);
            this.lbFreshrate.Name = "lbFreshrate";
            this.lbFreshrate.Size = new System.Drawing.Size(114, 17);
            this.lbFreshrate.TabIndex = 30;
            this.lbFreshrate.Text = "Statistics freshrate";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 60);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 60);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(247, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 10);
            this.panel1.TabIndex = 9;
            // 
            // OptionSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 509);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(11479, 1022, 11479, 1022);
            this.Name = "OptionSettingForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.OptionSettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl_Routing.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}