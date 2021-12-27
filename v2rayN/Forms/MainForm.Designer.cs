namespace v2rayN.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lvServers = new v2rayN.Extension.ListViewEx();
            this.cmsLv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddVmessServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddVlessServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddShadowsocksServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddSocksServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddTrojanServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddServers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScanScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveDuplicateServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetDefaultServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPingServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTcpingServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRealPingServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSpeedServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTestMe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExport2ShareUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport2SubContent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbServer = new System.Windows.Forms.ToolStripDropDownButton();
            this.qrCodeControl = new v2rayN.Forms.QRCodeControl();
            this.notifyMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSysAgentMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenHttp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseHttp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddServers2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScanScreen2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateSubscriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwScan = new System.ComponentModel.BackgroundWorker();
            this.groupBoxServerList = new System.Windows.Forms.GroupBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.txtMsgBox = new System.Windows.Forms.TextBox();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.toolSslSocksPortLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslSocksPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslBlank1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslHttpPortLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslHttpPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslBlank3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslServerSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSslBlank4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSub = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbSubSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSubUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbQRCodeSwitch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptionSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCheckUpdate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbCheckUpdateN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCheckUpdateCore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbV2rayWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPromotion = new System.Windows.Forms.ToolStripButton();
            this.tsbCheckUpdateDomainList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCheckUpdateIPList = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.cmsLv.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.groupBoxServerList.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(3, 19);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lvServers);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.qrCodeControl);
            this.scMain.Panel2MinSize = 100;
            this.scMain.Size = new System.Drawing.Size(1074, 382);
            this.scMain.SplitterDistance = 814;
            this.scMain.TabIndex = 0;
            this.scMain.TabStop = false;
            // 
            // lvServers
            // 
            this.lvServers.ContextMenuStrip = this.cmsLv;
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServers.FullRowSelect = true;
            this.lvServers.GridLines = true;
            this.lvServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvServers.HideSelection = false;
            this.lvServers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvServers.Location = new System.Drawing.Point(0, 0);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(814, 382);
            this.lvServers.TabIndex = 0;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            this.lvServers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvServers_ColumnClick);
            this.lvServers.SelectedIndexChanged += new System.EventHandler(this.lvServers_SelectedIndexChanged);
            this.lvServers.Click += new System.EventHandler(this.lvServers_Click);
            this.lvServers.DoubleClick += new System.EventHandler(this.lvServers_DoubleClick);
            this.lvServers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvServers_KeyDown);
            // 
            // cmsLv
            // 
            this.cmsLv.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmsLv.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddVmessServer,
            this.menuAddVlessServer,
            this.menuAddShadowsocksServer,
            this.menuAddSocksServer,
            this.menuAddTrojanServer,
            this.menuAddServers,
            this.menuScanScreen,
            this.toolStripSeparator1,
            this.menuRemoveServer,
            this.menuRemoveDuplicateServer,
            this.menuCopyServer,
            this.menuSetDefaultServer,
            this.toolStripSeparator3,
            this.menuMoveTop,
            this.menuMoveUp,
            this.menuMoveDown,
            this.menuMoveBottom,
            this.menuSelectAll,
            this.toolStripSeparator9,
            this.menuPingServer,
            this.menuTcpingServer,
            this.menuRealPingServer,
            this.menuSpeedServer,
            this.tsbTestMe,
            this.toolStripSeparator6,
            this.menuExport2ShareUrl,
            this.menuExport2SubContent});
            this.cmsLv.Name = "cmsLv";
            this.cmsLv.OwnerItem = this.tsbServer;
            this.cmsLv.Size = new System.Drawing.Size(250, 534);
            // 
            // menuAddVmessServer
            // 
            this.menuAddVmessServer.Name = "menuAddVmessServer";
            this.menuAddVmessServer.Size = new System.Drawing.Size(249, 22);
            this.menuAddVmessServer.Text = "添加 [VMess] 服务器";
            this.menuAddVmessServer.Click += new System.EventHandler(this.menuAddVmessServer_Click);
            // 
            // menuAddVlessServer
            // 
            this.menuAddVlessServer.Name = "menuAddVlessServer";
            this.menuAddVlessServer.Size = new System.Drawing.Size(249, 22);
            this.menuAddVlessServer.Text = "添加 [VLESS] 服务器";
            this.menuAddVlessServer.Click += new System.EventHandler(this.menuAddVlessServer_Click);
            // 
            // menuAddShadowsocksServer
            // 
            this.menuAddShadowsocksServer.Name = "menuAddShadowsocksServer";
            this.menuAddShadowsocksServer.Size = new System.Drawing.Size(249, 22);
            this.menuAddShadowsocksServer.Text = "添加 [Shadowsocks] 服务器";
            this.menuAddShadowsocksServer.Click += new System.EventHandler(this.menuAddShadowsocksServer_Click);
            // 
            // menuAddSocksServer
            // 
            this.menuAddSocksServer.Name = "menuAddSocksServer";
            this.menuAddSocksServer.Size = new System.Drawing.Size(249, 22);
            this.menuAddSocksServer.Text = "添加 [Socks] 服务器";
            this.menuAddSocksServer.Click += new System.EventHandler(this.menuAddSocksServer_Click);
            // 
            // menuAddTrojanServer
            // 
            this.menuAddTrojanServer.Name = "menuAddTrojanServer";
            this.menuAddTrojanServer.Size = new System.Drawing.Size(249, 22);
            this.menuAddTrojanServer.Text = "添加 [Trojan] 服务器";
            this.menuAddTrojanServer.Click += new System.EventHandler(this.menuAddTrojanServer_Click);
            // 
            // menuAddServers
            // 
            this.menuAddServers.Name = "menuAddServers";
            this.menuAddServers.Size = new System.Drawing.Size(249, 22);
            this.menuAddServers.Text = "从剪贴板导入bulk URL (Ctrl+V)";
            this.menuAddServers.Click += new System.EventHandler(this.menuAddServers_Click);
            // 
            // menuScanScreen
            // 
            this.menuScanScreen.Name = "menuScanScreen";
            this.menuScanScreen.Size = new System.Drawing.Size(249, 22);
            this.menuScanScreen.Text = "从屏幕扫描QR code (Ctrl+S)";
            this.menuScanScreen.Click += new System.EventHandler(this.menuScanScreen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // menuRemoveServer
            // 
            this.menuRemoveServer.Name = "menuRemoveServer";
            this.menuRemoveServer.Size = new System.Drawing.Size(249, 22);
            this.menuRemoveServer.Text = "删除服务器 (Delete)";
            this.menuRemoveServer.Click += new System.EventHandler(this.menuRemoveServer_Click);
            // 
            // menuRemoveDuplicateServer
            // 
            this.menuRemoveDuplicateServer.Name = "menuRemoveDuplicateServer";
            this.menuRemoveDuplicateServer.Size = new System.Drawing.Size(249, 22);
            this.menuRemoveDuplicateServer.Text = "删除重复服务器";
            this.menuRemoveDuplicateServer.Click += new System.EventHandler(this.menuRemoveDuplicateServer_Click);
            // 
            // menuCopyServer
            // 
            this.menuCopyServer.Name = "menuCopyServer";
            this.menuCopyServer.Size = new System.Drawing.Size(249, 22);
            this.menuCopyServer.Text = "克隆服务器";
            this.menuCopyServer.Click += new System.EventHandler(this.menuCopyServer_Click);
            // 
            // menuSetDefaultServer
            // 
            this.menuSetDefaultServer.Name = "menuSetDefaultServer";
            this.menuSetDefaultServer.Size = new System.Drawing.Size(249, 22);
            this.menuSetDefaultServer.Text = "启动服务器 (Enter)";
            this.menuSetDefaultServer.Click += new System.EventHandler(this.menuSetDefaultServer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(246, 6);
            // 
            // menuMoveTop
            // 
            this.menuMoveTop.Name = "menuMoveTop";
            this.menuMoveTop.Size = new System.Drawing.Size(249, 22);
            this.menuMoveTop.Text = "移到顶部 (T)";
            this.menuMoveTop.Click += new System.EventHandler(this.menuMoveTop_Click);
            // 
            // menuMoveUp
            // 
            this.menuMoveUp.Name = "menuMoveUp";
            this.menuMoveUp.Size = new System.Drawing.Size(249, 22);
            this.menuMoveUp.Text = "向上移 (U)";
            this.menuMoveUp.Click += new System.EventHandler(this.menuMoveUp_Click);
            // 
            // menuMoveDown
            // 
            this.menuMoveDown.Name = "menuMoveDown";
            this.menuMoveDown.Size = new System.Drawing.Size(249, 22);
            this.menuMoveDown.Text = "向下移 (D)";
            this.menuMoveDown.Click += new System.EventHandler(this.menuMoveDown_Click);
            // 
            // menuMoveBottom
            // 
            this.menuMoveBottom.Name = "menuMoveBottom";
            this.menuMoveBottom.Size = new System.Drawing.Size(249, 22);
            this.menuMoveBottom.Text = "移到底部 (B)";
            this.menuMoveBottom.Click += new System.EventHandler(this.menuMoveBottom_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(249, 22);
            this.menuSelectAll.Text = "选择全部 (Ctrl+A)";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(246, 6);
            // 
            // menuPingServer
            // 
            this.menuPingServer.Name = "menuPingServer";
            this.menuPingServer.Size = new System.Drawing.Size(249, 22);
            this.menuPingServer.Text = "测试服务器ping值 (Ctrl+P)";
            this.menuPingServer.Click += new System.EventHandler(this.menuPingServer_Click);
            // 
            // menuTcpingServer
            // 
            this.menuTcpingServer.Name = "menuTcpingServer";
            this.menuTcpingServer.Size = new System.Drawing.Size(249, 22);
            this.menuTcpingServer.Text = "测试服务器tcp延迟 (Ctrl+O)";
            this.menuTcpingServer.Click += new System.EventHandler(this.menuTcpingServer_Click);
            // 
            // menuRealPingServer
            // 
            this.menuRealPingServer.Name = "menuRealPingServer";
            this.menuRealPingServer.Size = new System.Drawing.Size(249, 22);
            this.menuRealPingServer.Text = "测试服务器真延迟 (Ctrl+R)";
            this.menuRealPingServer.Click += new System.EventHandler(this.menuRealPingServer_Click);
            // 
            // menuSpeedServer
            // 
            this.menuSpeedServer.Name = "menuSpeedServer";
            this.menuSpeedServer.Size = new System.Drawing.Size(249, 22);
            this.menuSpeedServer.Text = "测试服务器下载速度 (Ctrl+T)";
            this.menuSpeedServer.Click += new System.EventHandler(this.menuSpeedServer_Click);
            // 
            // tsbTestMe
            // 
            this.tsbTestMe.Name = "tsbTestMe";
            this.tsbTestMe.Size = new System.Drawing.Size(249, 22);
            this.tsbTestMe.Text = "测试服务器状态";
            this.tsbTestMe.Click += new System.EventHandler(this.tsbTestMe_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(246, 6);
            // 
            // menuExport2ShareUrl
            // 
            this.menuExport2ShareUrl.Name = "menuExport2ShareUrl";
            this.menuExport2ShareUrl.Size = new System.Drawing.Size(249, 22);
            this.menuExport2ShareUrl.Text = "导出分享链接到剪贴板 (Ctrl+C)";
            this.menuExport2ShareUrl.Click += new System.EventHandler(this.menuExport2ShareUrl_Click);
            // 
            // menuExport2SubContent
            // 
            this.menuExport2SubContent.Name = "menuExport2SubContent";
            this.menuExport2SubContent.Size = new System.Drawing.Size(249, 22);
            this.menuExport2SubContent.Text = "导出订阅分享(base64)到剪贴板";
            this.menuExport2SubContent.Click += new System.EventHandler(this.menuExport2SubContent_Click);
            // 
            // tsbServer
            // 
            this.tsbServer.DropDown = this.cmsLv;
            this.tsbServer.Image = ((System.Drawing.Image)(resources.GetObject("tsbServer.Image")));
            this.tsbServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServer.Name = "tsbServer";
            this.tsbServer.Size = new System.Drawing.Size(57, 53);
            this.tsbServer.Text = "服务器";
            this.tsbServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // qrCodeControl
            // 
            this.qrCodeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrCodeControl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qrCodeControl.Location = new System.Drawing.Point(0, 0);
            this.qrCodeControl.Margin = new System.Windows.Forms.Padding(6);
            this.qrCodeControl.Name = "qrCodeControl";
            this.qrCodeControl.Size = new System.Drawing.Size(256, 382);
            this.qrCodeControl.TabIndex = 2;
            // 
            // notifyMain
            // 
            this.notifyMain.ContextMenuStrip = this.cmsMain;
            this.notifyMain.Text = "v2rayN";
            this.notifyMain.Visible = true;
            this.notifyMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyMain_MouseClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSysAgentMode,
            this.menuServers,
            this.menuAddServers2,
            this.menuScanScreen2,
            this.menuUpdateSubscriptions,
            this.toolStripSeparator2,
            this.menuExit});
            this.cmsMain.Name = "contextMenuStrip1";
            this.cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMain.ShowCheckMargin = true;
            this.cmsMain.ShowImageMargin = false;
            this.cmsMain.Size = new System.Drawing.Size(201, 142);
            // 
            // menuSysAgentMode
            // 
            this.menuSysAgentMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCloseHttp,
            this.menuOpenHttp});
            this.menuSysAgentMode.Name = "menuSysAgentMode";
            this.menuSysAgentMode.Size = new System.Drawing.Size(200, 22);
            this.menuSysAgentMode.Text = "http代理";
            // 
            // menuCloseHttp
            // 
            this.menuCloseHttp.Name = "menuDelHttp";
            this.menuCloseHttp.Size = new System.Drawing.Size(231, 22);
            this.menuCloseHttp.Text = "关闭系统代理";
            this.menuCloseHttp.Click += new System.EventHandler(this.menuCloseHttp_Click);
            // 
            // menuOpenHttp
            // 
            this.menuOpenHttp.Name = "menuSetHttp";
            this.menuOpenHttp.Size = new System.Drawing.Size(231, 22);
            this.menuOpenHttp.Text = "打开系统代理";
            this.menuOpenHttp.Click += new System.EventHandler(this.menuOpenHttp_Click);
            // 
            // menuServers
            // 
            this.menuServers.Name = "menuServers";
            this.menuServers.Size = new System.Drawing.Size(200, 22);
            this.menuServers.Text = "服务器列表";
            // 
            // menuAddServers2
            // 
            this.menuAddServers2.Name = "menuAddServers2";
            this.menuAddServers2.Size = new System.Drawing.Size(200, 22);
            this.menuAddServers2.Text = "从剪贴板导入bulk URL";
            this.menuAddServers2.Click += new System.EventHandler(this.menuAddServers_Click);
            // 
            // menuScanScreen2
            // 
            this.menuScanScreen2.Name = "menuScanScreen2";
            this.menuScanScreen2.Size = new System.Drawing.Size(200, 22);
            this.menuScanScreen2.Text = "从屏幕扫描QR code";
            this.menuScanScreen2.Click += new System.EventHandler(this.menuScanScreen_Click);
            // 
            // menuUpdateSubscriptions
            // 
            this.menuUpdateSubscriptions.Name = "menuUpdateSubscriptions";
            this.menuUpdateSubscriptions.Size = new System.Drawing.Size(200, 22);
            this.menuUpdateSubscriptions.Text = "更新订阅";
            this.menuUpdateSubscriptions.Click += new System.EventHandler(this.menuUpdateSubscriptions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(200, 22);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // bgwScan
            // 
            this.bgwScan.WorkerReportsProgress = true;
            this.bgwScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwScan_DoWork);
            this.bgwScan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwScan_ProgressChanged);
            // 
            // groupBoxServerList
            // 
            this.groupBoxServerList.Controls.Add(this.scMain);
            this.groupBoxServerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxServerList.Location = new System.Drawing.Point(0, 66);
            this.groupBoxServerList.Name = "groupBoxServerList";
            this.groupBoxServerList.Size = new System.Drawing.Size(1080, 404);
            this.groupBoxServerList.TabIndex = 0;
            this.groupBoxServerList.TabStop = false;
            this.groupBoxServerList.Text = "服务器列表";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.txtMsgBox);
            this.groupBoxInfo.Controls.Add(this.ssMain);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxInfo.Location = new System.Drawing.Point(0, 470);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(1080, 250);
            this.groupBoxInfo.TabIndex = 3;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "v2ray信息";
            // 
            // txtMsgBox
            // 
            this.txtMsgBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.txtMsgBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(228)))));
            this.txtMsgBox.Location = new System.Drawing.Point(3, 19);
            this.txtMsgBox.MaxLength = 0;
            this.txtMsgBox.Multiline = true;
            this.txtMsgBox.Name = "txtMsgBox";
            this.txtMsgBox.ReadOnly = true;
            this.txtMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgBox.Size = new System.Drawing.Size(1074, 200);
            this.txtMsgBox.TabIndex = 3;
            // 
            // ssMain
            // 
            this.ssMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ssMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSslSocksPortLab,
            this.toolSslSocksPort,
            this.toolSslBlank1,
            this.toolSslHttpPortLab,
            this.toolSslHttpPort,
            this.toolSslBlank3,
            this.toolSslServerSpeed,
            this.toolSslBlank4});
            this.ssMain.Location = new System.Drawing.Point(3, 219);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1074, 28);
            this.ssMain.TabIndex = 0;
            this.ssMain.Text = "statusStrip1";
            this.ssMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ssMain_ItemClicked);
            // 
            // toolSslSocksPortLab
            // 
            this.toolSslSocksPortLab.Name = "toolSslSocksPortLab";
            this.toolSslSocksPortLab.Size = new System.Drawing.Size(58, 23);
            this.toolSslSocksPortLab.Text = "SOCKS5:";
            // 
            // toolSslSocksPort
            // 
            this.toolSslSocksPort.Name = "toolSslSocksPort";
            this.toolSslSocksPort.Size = new System.Drawing.Size(0, 23);
            // 
            // toolSslBlank1
            // 
            this.toolSslBlank1.Name = "toolSslBlank1";
            this.toolSslBlank1.Size = new System.Drawing.Size(370, 23);
            this.toolSslBlank1.Spring = true;
            // 
            // toolSslHttpPortLab
            // 
            this.toolSslHttpPortLab.Name = "toolSslHttpPortLab";
            this.toolSslHttpPortLab.Size = new System.Drawing.Size(41, 23);
            this.toolSslHttpPortLab.Text = "HTTP:";
            // 
            // toolSslHttpPort
            // 
            this.toolSslHttpPort.Name = "toolSslHttpPort";
            this.toolSslHttpPort.Size = new System.Drawing.Size(0, 23);
            // 
            // toolSslBlank3
            // 
            this.toolSslBlank3.Name = "toolSslBlank3";
            this.toolSslBlank3.Size = new System.Drawing.Size(370, 23);
            this.toolSslBlank3.Spring = true;
            // 
            // toolSslServerSpeed
            // 
            this.toolSslServerSpeed.AutoSize = false;
            this.toolSslServerSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSslServerSpeed.Name = "toolSslServerSpeed";
            this.toolSslServerSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolSslServerSpeed.Size = new System.Drawing.Size(220, 23);
            this.toolSslServerSpeed.Text = "SPEED Disabled";
            this.toolSslServerSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolSslBlank4
            // 
            this.toolSslBlank4.Name = "toolSslBlank4";
            this.toolSslBlank4.Size = new System.Drawing.Size(0, 23);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 10);
            this.panel1.TabIndex = 2;
            // 
            // tsMain
            // 
            this.tsMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbServer,
            this.toolStripSeparator4,
            this.tsbSub,
            this.tsbQRCodeSwitch,
            this.toolStripSeparator8,
            this.tsbOptionSetting,
            this.toolStripSeparator5,
            this.tsbReload,
            this.toolStripSeparator7,
            this.tsbCheckUpdate,
            this.toolStripSeparator10,
            this.tsbHelp,
            this.tsbPromotion});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1080, 56);
            this.tsMain.TabIndex = 1;
            this.tsMain.TabStop = true;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbSub
            // 
            this.tsbSub.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSubSetting,
            this.tsbSubUpdate});
            this.tsbSub.Image = ((System.Drawing.Image)(resources.GetObject("tsbSub.Image")));
            this.tsbSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSub.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbSub.Name = "tsbSub";
            this.tsbSub.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbSub.Size = new System.Drawing.Size(55, 53);
            this.tsbSub.Text = "订阅";
            this.tsbSub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSubSetting
            // 
            this.tsbSubSetting.Name = "tsbSubSetting";
            this.tsbSubSetting.Size = new System.Drawing.Size(180, 22);
            this.tsbSubSetting.Text = "设置";
            this.tsbSubSetting.Click += new System.EventHandler(this.tsbSubSetting_Click);
            // 
            // tsbSubUpdate
            // 
            this.tsbSubUpdate.Name = "tsbSubUpdate";
            this.tsbSubUpdate.Size = new System.Drawing.Size(180, 22);
            this.tsbSubUpdate.Text = "更新";
            this.tsbSubUpdate.Click += new System.EventHandler(this.tsbSubUpdate_Click);
            // 
            // tsbQRCodeSwitch
            // 
            this.tsbQRCodeSwitch.CheckOnClick = true;
            this.tsbQRCodeSwitch.ForeColor = System.Drawing.Color.Black;
            this.tsbQRCodeSwitch.Image = ((System.Drawing.Image)(resources.GetObject("tsbQRCodeSwitch.Image")));
            this.tsbQRCodeSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQRCodeSwitch.Name = "tsbQRCodeSwitch";
            this.tsbQRCodeSwitch.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tsbQRCodeSwitch.Size = new System.Drawing.Size(46, 53);
            this.tsbQRCodeSwitch.Text = "分享";
            this.tsbQRCodeSwitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQRCodeSwitch.CheckedChanged += new System.EventHandler(this.tsbQRCodeSwitch_CheckedChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbOptionSetting
            // 
            this.tsbOptionSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptionSetting.Image")));
            this.tsbOptionSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptionSetting.Name = "tsbOptionSetting";
            this.tsbOptionSetting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbOptionSetting.Size = new System.Drawing.Size(46, 53);
            this.tsbOptionSetting.Text = "设置";
            this.tsbOptionSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOptionSetting.Click += new System.EventHandler(this.tsbOptionSetting_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbReload
            // 
            this.tsbReload.Image = ((System.Drawing.Image)(resources.GetObject("tsbReload.Image")));
            this.tsbReload.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(60, 53);
            this.tsbReload.Text = "重启服务";
            this.tsbReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbReload.Click += new System.EventHandler(this.tsbReload_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbCheckUpdate
            // 
            this.tsbCheckUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCheckUpdateN,
            this.tsbCheckUpdateCore,
            this.tsbCheckUpdateDomainList,
            this.tsbCheckUpdateIPList});
            this.tsbCheckUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheckUpdate.Image")));
            this.tsbCheckUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckUpdate.Name = "tsbCheckUpdate";
            this.tsbCheckUpdate.Size = new System.Drawing.Size(69, 53);
            this.tsbCheckUpdate.Text = "检查更新";
            this.tsbCheckUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbCheckUpdateN
            // 
            this.tsbCheckUpdateN.Name = "tsbCheckUpdateN";
            this.tsbCheckUpdateN.Size = new System.Drawing.Size(135, 22);
            this.tsbCheckUpdateN.Text = "v2rayN";
            this.tsbCheckUpdateN.Click += new System.EventHandler(this.tsbCheckUpdateN_Click);
            // 
            // tsbCheckUpdateCore
            // 
            this.tsbCheckUpdateCore.Name = "tsbCheckUpdateCore";
            this.tsbCheckUpdateCore.Size = new System.Drawing.Size(135, 22);
            this.tsbCheckUpdateCore.Text = "v2rayCore";
            this.tsbCheckUpdateCore.Click += new System.EventHandler(this.tsbCheckUpdateCore_Click);
            // 
            // tsbCheckUpdateDomainList
            // 
            this.tsbCheckUpdateDomainList.Name = "tsbCheckUpdateDomainList";
            this.tsbCheckUpdateDomainList.Size = new System.Drawing.Size(135, 22);
            this.tsbCheckUpdateDomainList.Text = "Domain list";
            this.tsbCheckUpdateDomainList.Click += new System.EventHandler(this.tsbCheckUpdateDomainList_Click);
            // 
            // tsbCheckUpdateIPList
            // 
            this.tsbCheckUpdateIPList.Name = "tsbCheckUpdateIPList";
            this.tsbCheckUpdateIPList.Size = new System.Drawing.Size(135, 22);
            this.tsbCheckUpdateIPList.Text = "IP list";
            this.tsbCheckUpdateIPList.Click += new System.EventHandler(this.tsbCheckUpdateIPList_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbout,
            this.tsbV2rayWebsite});
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbHelp.Size = new System.Drawing.Size(55, 53);
            this.tsbHelp.Text = "帮助";
            this.tsbHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbAbout
            // 
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(163, 22);
            this.tsbAbout.Text = "v2rayN Project";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbV2rayWebsite
            // 
            this.tsbV2rayWebsite.Name = "tsbV2rayWebsite";
            this.tsbV2rayWebsite.Size = new System.Drawing.Size(163, 22);
            this.tsbV2rayWebsite.Text = "V2Ray Website";
            this.tsbV2rayWebsite.Click += new System.EventHandler(this.tsbV2rayWebsite_Click);
            // 
            // tsbPromotion
            // 
            this.tsbPromotion.ForeColor = System.Drawing.Color.Black;
            this.tsbPromotion.Image = ((System.Drawing.Image)(resources.GetObject("tsbPromotion.Image")));
            this.tsbPromotion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPromotion.Name = "tsbPromotion";
            this.tsbPromotion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbPromotion.Size = new System.Drawing.Size(46, 53);
            this.tsbPromotion.Text = "推广";
            this.tsbPromotion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPromotion.Click += new System.EventHandler(this.tsbPromotion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.groupBoxServerList);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsMain);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.Text = "v2rayN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.cmsLv.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.groupBoxServerList.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.GroupBox groupBoxServerList;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.TextBox txtMsgBox;
        private v2rayN.Extension.ListViewEx lvServers;
        private System.Windows.Forms.NotifyIcon notifyMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuServers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsLv;
        private System.Windows.Forms.ToolStripMenuItem menuAddVmessServer;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveServer;
        private System.Windows.Forms.ToolStripMenuItem menuSetDefaultServer;
        private System.Windows.Forms.ToolStripMenuItem menuCopyServer;
        private System.Windows.Forms.ToolStripMenuItem menuPingServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton tsbServer;
        private System.Windows.Forms.ToolStripButton tsbOptionSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuMoveTop;
        private System.Windows.Forms.ToolStripMenuItem menuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem menuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem menuMoveBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuSysAgentMode;
        private System.Windows.Forms.ToolStripMenuItem menuOpenHttp;
        private System.Windows.Forms.ToolStripMenuItem menuCloseHttp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAddShadowsocksServer;
        private System.Windows.Forms.SplitContainer scMain;
        private QRCodeControl qrCodeControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripDropDownButton tsbCheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsbCheckUpdateN;
        private System.Windows.Forms.ToolStripMenuItem tsbCheckUpdateCore;
        private System.Windows.Forms.ToolStripMenuItem menuAddServers;
        private System.Windows.Forms.ToolStripMenuItem menuExport2ShareUrl;
        private System.Windows.Forms.ToolStripMenuItem menuSpeedServer;
        private System.Windows.Forms.ToolStripDropDownButton tsbHelp;
        private System.Windows.Forms.ToolStripMenuItem tsbAbout;
        private System.Windows.Forms.ToolStripMenuItem menuAddServers2;
        private System.ComponentModel.BackgroundWorker bgwScan;
        private System.Windows.Forms.ToolStripMenuItem menuScanScreen;
        private System.Windows.Forms.ToolStripMenuItem menuScanScreen2;
        private System.Windows.Forms.ToolStripDropDownButton tsbSub;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsbSubSetting;
        private System.Windows.Forms.ToolStripMenuItem tsbSubUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuExport2SubContent;
        private System.Windows.Forms.ToolStripButton tsbPromotion;
        private System.Windows.Forms.ToolStripMenuItem menuAddSocksServer;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel toolSslSocksPort;
        private System.Windows.Forms.ToolStripStatusLabel toolSslHttpPort;
        private System.Windows.Forms.ToolStripStatusLabel toolSslBlank1;
        private System.Windows.Forms.ToolStripStatusLabel toolSslBlank3;
        private System.Windows.Forms.ToolStripStatusLabel toolSslSocksPortLab;
        private System.Windows.Forms.ToolStripStatusLabel toolSslHttpPortLab;
        private System.Windows.Forms.ToolStripStatusLabel toolSslServerSpeed;
        private System.Windows.Forms.ToolStripStatusLabel toolSslBlank4;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveDuplicateServer;
        private System.Windows.Forms.ToolStripMenuItem menuTcpingServer;
        private System.Windows.Forms.ToolStripMenuItem menuRealPingServer;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateSubscriptions;
        private System.Windows.Forms.ToolStripMenuItem tsbV2rayWebsite;
        private System.Windows.Forms.ToolStripMenuItem tsbTestMe;
        private System.Windows.Forms.ToolStripButton tsbReload;
        private System.Windows.Forms.ToolStripButton tsbQRCodeSwitch;
        private System.Windows.Forms.ToolStripMenuItem menuAddVlessServer;
        private System.Windows.Forms.ToolStripMenuItem menuAddTrojanServer;
        private System.Windows.Forms.ToolStripMenuItem tsbCheckUpdateDomainList;
        private System.Windows.Forms.ToolStripMenuItem tsbCheckUpdateIPList;
    }
}

