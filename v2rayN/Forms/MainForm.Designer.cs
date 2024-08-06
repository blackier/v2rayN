using v2rayN.Controls;

namespace v2rayN.Forms;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        scMain = new System.Windows.Forms.SplitContainer();
        lvServers = new ListViewControl();
        cmsLv = new ImageGlass.UI.ModernMenu(components);
        menuAddVmessServer = new System.Windows.Forms.ToolStripMenuItem();
        menuAddVlessServer = new System.Windows.Forms.ToolStripMenuItem();
        menuAddShadowsocksServer = new System.Windows.Forms.ToolStripMenuItem();
        menuAddSocksServer = new System.Windows.Forms.ToolStripMenuItem();
        menuAddTrojanServer = new System.Windows.Forms.ToolStripMenuItem();
        menuAddServers = new System.Windows.Forms.ToolStripMenuItem();
        menuScanScreen = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        menuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
        menuRemoveDuplicateServer = new System.Windows.Forms.ToolStripMenuItem();
        menuCopyServer = new System.Windows.Forms.ToolStripMenuItem();
        menuEditServer = new System.Windows.Forms.ToolStripMenuItem();
        menuSetDefaultServer = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        menuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
        menuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
        menuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
        menuMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
        menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
        menuPingServer = new System.Windows.Forms.ToolStripMenuItem();
        menuTcpingServer = new System.Windows.Forms.ToolStripMenuItem();
        menuRealPingServer = new System.Windows.Forms.ToolStripMenuItem();
        menuSpeedServer = new System.Windows.Forms.ToolStripMenuItem();
        tsbTestMe = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        menuExport2ShareUrl = new System.Windows.Forms.ToolStripMenuItem();
        menuExport2SubContent = new System.Windows.Forms.ToolStripMenuItem();
        qrCodeControl = new QRCodeControl();
        tsbServer = new System.Windows.Forms.ToolStripDropDownButton();
        notifyMain = new System.Windows.Forms.NotifyIcon(components);
        cmsMain = new ImageGlass.UI.ModernMenu(components);
        menuSysAgentMode = new System.Windows.Forms.ToolStripMenuItem();
        menuCloseHttp = new System.Windows.Forms.ToolStripMenuItem();
        menuOpenHttp = new System.Windows.Forms.ToolStripMenuItem();
        menuOpenSocks = new System.Windows.Forms.ToolStripMenuItem();
        menuServers = new System.Windows.Forms.ToolStripMenuItem();
        menuAddServers2 = new System.Windows.Forms.ToolStripMenuItem();
        menuScanScreen2 = new System.Windows.Forms.ToolStripMenuItem();
        menuUpdateSubscriptions = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        menuExit = new System.Windows.Forms.ToolStripMenuItem();
        bgwScan = new System.ComponentModel.BackgroundWorker();
        groupBoxServerList = new System.Windows.Forms.GroupBox();
        groupBoxInfo = new System.Windows.Forms.GroupBox();
        txtMsgBox = new System.Windows.Forms.TextBox();
        ssMain = new System.Windows.Forms.StatusStrip();
        toolSslSocksPortLab = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslSocksPort = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslBlank1 = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslHttpPortLab = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslHttpPort = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslBlank3 = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslServerSpeed = new System.Windows.Forms.ToolStripStatusLabel();
        toolSslBlank4 = new System.Windows.Forms.ToolStripStatusLabel();
        panel1 = new System.Windows.Forms.Panel();
        tsMain = new System.Windows.Forms.ToolStrip();
        toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        tsbSub = new System.Windows.Forms.ToolStripDropDownButton();
        tsbSubSetting = new System.Windows.Forms.ToolStripMenuItem();
        tsbSubUpdate = new System.Windows.Forms.ToolStripMenuItem();
        tsbSubUpdateAndPing = new System.Windows.Forms.ToolStripMenuItem();
        tsbQRCodeSwitch = new System.Windows.Forms.ToolStripButton();
        toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
        tsbOptionSetting = new System.Windows.Forms.ToolStripButton();
        toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        tsbReload = new System.Windows.Forms.ToolStripButton();
        toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        tsbCheckUpdate = new System.Windows.Forms.ToolStripDropDownButton();
        tsbCheckUpdateN = new System.Windows.Forms.ToolStripMenuItem();
        tsbCheckUpdateCore = new System.Windows.Forms.ToolStripMenuItem();
        tsbCheckUpdateDomainList = new System.Windows.Forms.ToolStripMenuItem();
        tsbCheckUpdateIPList = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
        tsbHelp = new System.Windows.Forms.ToolStripDropDownButton();
        tsbAbout = new System.Windows.Forms.ToolStripMenuItem();
        tsbV2rayWebsite = new System.Windows.Forms.ToolStripMenuItem();
        tsbPromotion = new System.Windows.Forms.ToolStripButton();
        ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
        scMain.Panel1.SuspendLayout();
        scMain.Panel2.SuspendLayout();
        scMain.SuspendLayout();
        cmsLv.SuspendLayout();
        cmsMain.SuspendLayout();
        groupBoxServerList.SuspendLayout();
        groupBoxInfo.SuspendLayout();
        ssMain.SuspendLayout();
        tsMain.SuspendLayout();
        SuspendLayout();
        // 
        // scMain
        // 
        scMain.Dock = System.Windows.Forms.DockStyle.Fill;
        scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        scMain.Location = new System.Drawing.Point(3, 19);
        scMain.Name = "scMain";
        // 
        // scMain.Panel1
        // 
        scMain.Panel1.Controls.Add(lvServers);
        // 
        // scMain.Panel2
        // 
        scMain.Panel2.Controls.Add(qrCodeControl);
        scMain.Panel2MinSize = 100;
        scMain.Size = new System.Drawing.Size(1074, 382);
        scMain.SplitterDistance = 814;
        scMain.TabIndex = 0;
        scMain.TabStop = false;
        // 
        // lvServers
        // 
        lvServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lvServers.ContextMenuStrip = cmsLv;
        lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
        lvServers.FullRowSelect = true;
        lvServers.GridLines = true;
        lvServers.Location = new System.Drawing.Point(0, 0);
        lvServers.Name = "lvServers";
        lvServers.Size = new System.Drawing.Size(814, 382);
        lvServers.SortColumnIndex = -1;
        lvServers.SortColumnOrder = System.Windows.Forms.SortOrder.None;
        lvServers.TabIndex = 0;
        lvServers.UseCompatibleStateImageBehavior = false;
        lvServers.View = System.Windows.Forms.View.Details;
        lvServers.ColumnClick += lvServers_ColumnClick;
        lvServers.SelectedIndexChanged += lvServers_SelectedIndexChanged;
        lvServers.Click += lvServers_Click;
        lvServers.DoubleClick += menuSetDefaultServer_Click;
        lvServers.KeyDown += lvServers_KeyDown;
        // 
        // cmsLv
        // 
        cmsLv.CurrentDpi = 96;
        cmsLv.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
        cmsLv.ImageScalingSize = new System.Drawing.Size(20, 20);
        cmsLv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuAddVmessServer, menuAddVlessServer, menuAddShadowsocksServer, menuAddSocksServer, menuAddTrojanServer, menuAddServers, menuScanScreen, toolStripSeparator1, menuRemoveServer, menuRemoveDuplicateServer, menuCopyServer, menuEditServer, menuSetDefaultServer, toolStripSeparator3, menuMoveTop, menuMoveUp, menuMoveDown, menuMoveBottom, menuSelectAll, toolStripSeparator9, menuPingServer, menuTcpingServer, menuRealPingServer, menuSpeedServer, tsbTestMe, toolStripSeparator6, menuExport2ShareUrl, menuExport2SubContent });
        cmsLv.Name = "cmsLv";
        cmsLv.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        cmsLv.Size = new System.Drawing.Size(247, 556);
        // 
        // menuAddVmessServer
        // 
        menuAddVmessServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddVmessServer.Name = "menuAddVmessServer";
        menuAddVmessServer.Size = new System.Drawing.Size(246, 22);
        menuAddVmessServer.Text = "添加 [VMess] 服务器";
        menuAddVmessServer.Click += menuAddVmessServer_Click;
        // 
        // menuAddVlessServer
        // 
        menuAddVlessServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddVlessServer.Name = "menuAddVlessServer";
        menuAddVlessServer.Size = new System.Drawing.Size(246, 22);
        menuAddVlessServer.Text = "添加 [VLESS] 服务器";
        menuAddVlessServer.Click += menuAddVlessServer_Click;
        // 
        // menuAddShadowsocksServer
        // 
        menuAddShadowsocksServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddShadowsocksServer.Name = "menuAddShadowsocksServer";
        menuAddShadowsocksServer.Size = new System.Drawing.Size(246, 22);
        menuAddShadowsocksServer.Text = "添加 [Shadowsocks] 服务器";
        menuAddShadowsocksServer.Click += menuAddShadowsocksServer_Click;
        // 
        // menuAddSocksServer
        // 
        menuAddSocksServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddSocksServer.Name = "menuAddSocksServer";
        menuAddSocksServer.Size = new System.Drawing.Size(246, 22);
        menuAddSocksServer.Text = "添加 [Socks] 服务器";
        menuAddSocksServer.Click += menuAddSocksServer_Click;
        // 
        // menuAddTrojanServer
        // 
        menuAddTrojanServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddTrojanServer.Name = "menuAddTrojanServer";
        menuAddTrojanServer.Size = new System.Drawing.Size(246, 22);
        menuAddTrojanServer.Text = "添加 [Trojan] 服务器";
        menuAddTrojanServer.Click += menuAddTrojanServer_Click;
        // 
        // menuAddServers
        // 
        menuAddServers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddServers.Name = "menuAddServers";
        menuAddServers.ShortcutKeyDisplayString = "Ctrl+V";
        menuAddServers.Size = new System.Drawing.Size(246, 22);
        menuAddServers.Text = "从剪贴板导入bulk URL";
        menuAddServers.Click += menuAddServers_Click;
        // 
        // menuScanScreen
        // 
        menuScanScreen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuScanScreen.Name = "menuScanScreen";
        menuScanScreen.ShortcutKeyDisplayString = "Ctrl+S";
        menuScanScreen.Size = new System.Drawing.Size(246, 22);
        menuScanScreen.Text = "从屏幕扫描QR code";
        menuScanScreen.Click += menuScanScreen_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
        // 
        // menuRemoveServer
        // 
        menuRemoveServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuRemoveServer.Name = "menuRemoveServer";
        menuRemoveServer.ShortcutKeyDisplayString = "Delete";
        menuRemoveServer.Size = new System.Drawing.Size(246, 22);
        menuRemoveServer.Text = "删除服务器";
        menuRemoveServer.Click += menuRemoveServer_Click;
        // 
        // menuRemoveDuplicateServer
        // 
        menuRemoveDuplicateServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuRemoveDuplicateServer.Name = "menuRemoveDuplicateServer";
        menuRemoveDuplicateServer.Size = new System.Drawing.Size(246, 22);
        menuRemoveDuplicateServer.Text = "删除重复服务器";
        menuRemoveDuplicateServer.Click += menuRemoveDuplicateServer_Click;
        // 
        // menuCopyServer
        // 
        menuCopyServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuCopyServer.Name = "menuCopyServer";
        menuCopyServer.Size = new System.Drawing.Size(246, 22);
        menuCopyServer.Text = "克隆服务器";
        menuCopyServer.Click += menuCopyServer_Click;
        // 
        // menuEditServer
        // 
        menuEditServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuEditServer.Name = "menuEditServer";
        menuEditServer.Size = new System.Drawing.Size(246, 22);
        menuEditServer.Text = "编辑服务器";
        menuEditServer.Click += lvServers_DoubleClick;
        // 
        // menuSetDefaultServer
        // 
        menuSetDefaultServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuSetDefaultServer.Name = "menuSetDefaultServer";
        menuSetDefaultServer.ShortcutKeyDisplayString = "Enter";
        menuSetDefaultServer.Size = new System.Drawing.Size(246, 22);
        menuSetDefaultServer.Text = "启动服务器";
        menuSetDefaultServer.Click += menuSetDefaultServer_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
        // 
        // menuMoveTop
        // 
        menuMoveTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuMoveTop.Name = "menuMoveTop";
        menuMoveTop.ShortcutKeyDisplayString = "T";
        menuMoveTop.Size = new System.Drawing.Size(246, 22);
        menuMoveTop.Text = "移到顶部";
        menuMoveTop.Click += menuMoveTop_Click;
        // 
        // menuMoveUp
        // 
        menuMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuMoveUp.Name = "menuMoveUp";
        menuMoveUp.ShortcutKeyDisplayString = "U";
        menuMoveUp.Size = new System.Drawing.Size(246, 22);
        menuMoveUp.Text = "向上移";
        menuMoveUp.Click += menuMoveUp_Click;
        // 
        // menuMoveDown
        // 
        menuMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuMoveDown.Name = "menuMoveDown";
        menuMoveDown.ShortcutKeyDisplayString = "D";
        menuMoveDown.Size = new System.Drawing.Size(246, 22);
        menuMoveDown.Text = "向下移";
        menuMoveDown.Click += menuMoveDown_Click;
        // 
        // menuMoveBottom
        // 
        menuMoveBottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuMoveBottom.Name = "menuMoveBottom";
        menuMoveBottom.ShortcutKeyDisplayString = "B";
        menuMoveBottom.Size = new System.Drawing.Size(246, 22);
        menuMoveBottom.Text = "移到底部";
        menuMoveBottom.Click += menuMoveBottom_Click;
        // 
        // menuSelectAll
        // 
        menuSelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuSelectAll.Name = "menuSelectAll";
        menuSelectAll.ShortcutKeyDisplayString = "Ctrl+A";
        menuSelectAll.Size = new System.Drawing.Size(246, 22);
        menuSelectAll.Text = "选择全部";
        menuSelectAll.Click += menuSelectAll_Click;
        // 
        // toolStripSeparator9
        // 
        toolStripSeparator9.Name = "toolStripSeparator9";
        toolStripSeparator9.Size = new System.Drawing.Size(243, 6);
        // 
        // menuPingServer
        // 
        menuPingServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuPingServer.Name = "menuPingServer";
        menuPingServer.ShortcutKeyDisplayString = "Ctrl+P";
        menuPingServer.Size = new System.Drawing.Size(246, 22);
        menuPingServer.Text = "测试服务器ping值";
        menuPingServer.Click += menuPingServer_Click;
        // 
        // menuTcpingServer
        // 
        menuTcpingServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuTcpingServer.Name = "menuTcpingServer";
        menuTcpingServer.ShortcutKeyDisplayString = "Ctrl+O";
        menuTcpingServer.Size = new System.Drawing.Size(246, 22);
        menuTcpingServer.Text = "测试服务器tcp延迟";
        menuTcpingServer.Click += menuTcpingServer_Click;
        // 
        // menuRealPingServer
        // 
        menuRealPingServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuRealPingServer.Name = "menuRealPingServer";
        menuRealPingServer.ShortcutKeyDisplayString = "Ctrl+R";
        menuRealPingServer.Size = new System.Drawing.Size(246, 22);
        menuRealPingServer.Text = "测试服务器真延迟";
        menuRealPingServer.Click += menuRealPingServer_Click;
        // 
        // menuSpeedServer
        // 
        menuSpeedServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuSpeedServer.Name = "menuSpeedServer";
        menuSpeedServer.ShortcutKeyDisplayString = "Ctrl+T";
        menuSpeedServer.Size = new System.Drawing.Size(246, 22);
        menuSpeedServer.Text = "测试服务器下载速度";
        menuSpeedServer.Click += menuSpeedServer_Click;
        // 
        // tsbTestMe
        // 
        tsbTestMe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        tsbTestMe.Name = "tsbTestMe";
        tsbTestMe.Size = new System.Drawing.Size(246, 22);
        tsbTestMe.Text = "测试服务器状态";
        tsbTestMe.Click += tsbTestMe_Click;
        // 
        // toolStripSeparator6
        // 
        toolStripSeparator6.Name = "toolStripSeparator6";
        toolStripSeparator6.Size = new System.Drawing.Size(243, 6);
        // 
        // menuExport2ShareUrl
        // 
        menuExport2ShareUrl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuExport2ShareUrl.Name = "menuExport2ShareUrl";
        menuExport2ShareUrl.ShortcutKeyDisplayString = "Ctrl+C";
        menuExport2ShareUrl.Size = new System.Drawing.Size(246, 22);
        menuExport2ShareUrl.Text = "导出分享链接到剪贴板";
        menuExport2ShareUrl.Click += menuExport2ShareUrl_Click;
        // 
        // menuExport2SubContent
        // 
        menuExport2SubContent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuExport2SubContent.Name = "menuExport2SubContent";
        menuExport2SubContent.Size = new System.Drawing.Size(246, 22);
        menuExport2SubContent.Text = "导出订阅分享(base64)到剪贴板";
        menuExport2SubContent.Click += menuExport2SubContent_Click;
        // 
        // qrCodeControl
        // 
        qrCodeControl.Dock = System.Windows.Forms.DockStyle.Fill;
        qrCodeControl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
        qrCodeControl.Location = new System.Drawing.Point(0, 0);
        qrCodeControl.Margin = new System.Windows.Forms.Padding(6);
        qrCodeControl.Name = "qrCodeControl";
        qrCodeControl.Size = new System.Drawing.Size(256, 382);
        qrCodeControl.TabIndex = 2;
        // 
        // tsbServer
        // 
        tsbServer.DropDown = cmsLv;
        tsbServer.Image = (System.Drawing.Image)resources.GetObject("tsbServer.Image");
        tsbServer.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbServer.Name = "tsbServer";
        tsbServer.Size = new System.Drawing.Size(57, 53);
        tsbServer.Text = "服务器";
        tsbServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        // 
        // notifyMain
        // 
        notifyMain.ContextMenuStrip = cmsMain;
        notifyMain.Text = "v2rayN";
        notifyMain.Visible = true;
        notifyMain.MouseClick += notifyMain_MouseClick;
        // 
        // cmsMain
        // 
        cmsMain.CurrentDpi = 96;
        cmsMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
        cmsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
        cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuSysAgentMode, menuServers, menuAddServers2, menuScanScreen2, menuUpdateSubscriptions, toolStripSeparator2, menuExit });
        cmsMain.Name = "contextMenuStrip1";
        cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        cmsMain.Size = new System.Drawing.Size(201, 164);
        // 
        // menuSysAgentMode
        // 
        menuSysAgentMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuCloseHttp, menuOpenHttp, menuOpenSocks });
        menuSysAgentMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuSysAgentMode.Name = "menuSysAgentMode";
        menuSysAgentMode.Size = new System.Drawing.Size(200, 22);
        menuSysAgentMode.Text = "http代理";
        // 
        // menuCloseHttp
        // 
        menuCloseHttp.Name = "menuCloseHttp";
        menuCloseHttp.Size = new System.Drawing.Size(189, 22);
        menuCloseHttp.Text = "关闭系统代理";
        menuCloseHttp.Click += menuCloseHttp_Click;
        // 
        // menuOpenHttp
        // 
        menuOpenHttp.Name = "menuOpenHttp";
        menuOpenHttp.Size = new System.Drawing.Size(189, 22);
        menuOpenHttp.Text = "打开系统代理(http)";
        menuOpenHttp.Click += menuOpenHttp_Click;
        // 
        // menuOpenSocks
        // 
        menuOpenSocks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuOpenSocks.Name = "menuOpenSocks";
        menuOpenSocks.Size = new System.Drawing.Size(189, 22);
        menuOpenSocks.Text = "打开系统代理(socks)";
        menuOpenSocks.Click += menuOpenSocks_Click;
        // 
        // menuServers
        // 
        menuServers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuServers.Name = "menuServers";
        menuServers.Size = new System.Drawing.Size(200, 22);
        menuServers.Text = "服务器列表";
        // 
        // menuAddServers2
        // 
        menuAddServers2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuAddServers2.Name = "menuAddServers2";
        menuAddServers2.Size = new System.Drawing.Size(200, 22);
        menuAddServers2.Text = "从剪贴板导入bulk URL";
        menuAddServers2.Click += menuAddServers_Click;
        // 
        // menuScanScreen2
        // 
        menuScanScreen2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuScanScreen2.Name = "menuScanScreen2";
        menuScanScreen2.Size = new System.Drawing.Size(200, 22);
        menuScanScreen2.Text = "从屏幕扫描QR code";
        menuScanScreen2.Click += menuScanScreen_Click;
        // 
        // menuUpdateSubscriptions
        // 
        menuUpdateSubscriptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuUpdateSubscriptions.Name = "menuUpdateSubscriptions";
        menuUpdateSubscriptions.Size = new System.Drawing.Size(200, 22);
        menuUpdateSubscriptions.Text = "更新订阅";
        menuUpdateSubscriptions.Click += menuUpdateSubscriptions_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
        // 
        // menuExit
        // 
        menuExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        menuExit.Name = "menuExit";
        menuExit.Size = new System.Drawing.Size(200, 22);
        menuExit.Text = "退出";
        menuExit.Click += menuExit_Click;
        // 
        // bgwScan
        // 
        bgwScan.WorkerReportsProgress = true;
        bgwScan.DoWork += bgwScan_DoWork;
        bgwScan.ProgressChanged += bgwScan_ProgressChanged;
        // 
        // groupBoxServerList
        // 
        groupBoxServerList.Controls.Add(scMain);
        groupBoxServerList.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBoxServerList.Location = new System.Drawing.Point(0, 66);
        groupBoxServerList.Name = "groupBoxServerList";
        groupBoxServerList.Size = new System.Drawing.Size(1080, 404);
        groupBoxServerList.TabIndex = 0;
        groupBoxServerList.TabStop = false;
        groupBoxServerList.Text = "服务器列表";
        // 
        // groupBoxInfo
        // 
        groupBoxInfo.Controls.Add(txtMsgBox);
        groupBoxInfo.Controls.Add(ssMain);
        groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
        groupBoxInfo.Location = new System.Drawing.Point(0, 470);
        groupBoxInfo.Name = "groupBoxInfo";
        groupBoxInfo.Size = new System.Drawing.Size(1080, 250);
        groupBoxInfo.TabIndex = 3;
        groupBoxInfo.TabStop = false;
        groupBoxInfo.Text = "v2ray信息";
        // 
        // txtMsgBox
        // 
        txtMsgBox.BackColor = System.Drawing.Color.FromArgb(41, 49, 52);
        txtMsgBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        txtMsgBox.Dock = System.Windows.Forms.DockStyle.Fill;
        txtMsgBox.ForeColor = System.Drawing.Color.FromArgb(224, 226, 228);
        txtMsgBox.Location = new System.Drawing.Point(3, 19);
        txtMsgBox.MaxLength = 0;
        txtMsgBox.Multiline = true;
        txtMsgBox.Name = "txtMsgBox";
        txtMsgBox.ReadOnly = true;
        txtMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtMsgBox.Size = new System.Drawing.Size(1074, 206);
        txtMsgBox.TabIndex = 3;
        // 
        // ssMain
        // 
        ssMain.Font = new System.Drawing.Font("Consolas", 9F);
        ssMain.ImageScalingSize = new System.Drawing.Size(24, 24);
        ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolSslSocksPortLab, toolSslSocksPort, toolSslBlank1, toolSslHttpPortLab, toolSslHttpPort, toolSslBlank3, toolSslServerSpeed, toolSslBlank4 });
        ssMain.Location = new System.Drawing.Point(3, 225);
        ssMain.Name = "ssMain";
        ssMain.Size = new System.Drawing.Size(1074, 22);
        ssMain.TabIndex = 0;
        ssMain.Text = "statusStrip1";
        ssMain.ItemClicked += ssMain_ItemClicked;
        // 
        // toolSslSocksPortLab
        // 
        toolSslSocksPortLab.Name = "toolSslSocksPortLab";
        toolSslSocksPortLab.Size = new System.Drawing.Size(56, 17);
        toolSslSocksPortLab.Text = "SOCKS5:";
        // 
        // toolSslSocksPort
        // 
        toolSslSocksPort.Name = "toolSslSocksPort";
        toolSslSocksPort.Size = new System.Drawing.Size(0, 17);
        // 
        // toolSslBlank1
        // 
        toolSslBlank1.Name = "toolSslBlank1";
        toolSslBlank1.Size = new System.Drawing.Size(428, 17);
        toolSslBlank1.Spring = true;
        // 
        // toolSslHttpPortLab
        // 
        toolSslHttpPortLab.Name = "toolSslHttpPortLab";
        toolSslHttpPortLab.Size = new System.Drawing.Size(42, 17);
        toolSslHttpPortLab.Text = "HTTP:";
        // 
        // toolSslHttpPort
        // 
        toolSslHttpPort.Name = "toolSslHttpPort";
        toolSslHttpPort.Size = new System.Drawing.Size(0, 17);
        // 
        // toolSslBlank3
        // 
        toolSslBlank3.Name = "toolSslBlank3";
        toolSslBlank3.Size = new System.Drawing.Size(428, 17);
        toolSslBlank3.Spring = true;
        // 
        // toolSslServerSpeed
        // 
        toolSslServerSpeed.Name = "toolSslServerSpeed";
        toolSslServerSpeed.Size = new System.Drawing.Size(105, 17);
        toolSslServerSpeed.Text = "SPEED Disabled";
        // 
        // toolSslBlank4
        // 
        toolSslBlank4.Name = "toolSslBlank4";
        toolSslBlank4.Size = new System.Drawing.Size(0, 17);
        // 
        // panel1
        // 
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 56);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(1080, 10);
        panel1.TabIndex = 2;
        // 
        // tsMain
        // 
        tsMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
        tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
        tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbServer, toolStripSeparator4, tsbSub, tsbQRCodeSwitch, toolStripSeparator8, tsbOptionSetting, toolStripSeparator5, tsbReload, toolStripSeparator7, tsbCheckUpdate, toolStripSeparator10, tsbHelp, tsbPromotion });
        tsMain.Location = new System.Drawing.Point(0, 0);
        tsMain.Name = "tsMain";
        tsMain.Size = new System.Drawing.Size(1080, 56);
        tsMain.TabIndex = 1;
        tsMain.TabStop = true;
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new System.Drawing.Size(6, 56);
        // 
        // tsbSub
        // 
        tsbSub.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbSubSetting, tsbSubUpdate, tsbSubUpdateAndPing });
        tsbSub.Image = (System.Drawing.Image)resources.GetObject("tsbSub.Image");
        tsbSub.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbSub.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
        tsbSub.Name = "tsbSub";
        tsbSub.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        tsbSub.Size = new System.Drawing.Size(55, 53);
        tsbSub.Text = "订阅";
        tsbSub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        // 
        // tsbSubSetting
        // 
        tsbSubSetting.Name = "tsbSubSetting";
        tsbSubSetting.Size = new System.Drawing.Size(148, 22);
        tsbSubSetting.Text = "设置";
        tsbSubSetting.Click += tsbSubSetting_Click;
        // 
        // tsbSubUpdate
        // 
        tsbSubUpdate.Name = "tsbSubUpdate";
        tsbSubUpdate.Size = new System.Drawing.Size(148, 22);
        tsbSubUpdate.Text = "更新";
        tsbSubUpdate.Click += tsbSubUpdate_Click;
        // 
        // tsbSubUpdateAndPing
        // 
        tsbSubUpdateAndPing.Name = "tsbSubUpdateAndPing";
        tsbSubUpdateAndPing.Size = new System.Drawing.Size(148, 22);
        tsbSubUpdateAndPing.Text = "更新并测延迟";
        tsbSubUpdateAndPing.Click += tsbSubUpdateAndPing_Click;
        // 
        // tsbQRCodeSwitch
        // 
        tsbQRCodeSwitch.CheckOnClick = true;
        tsbQRCodeSwitch.ForeColor = System.Drawing.Color.Black;
        tsbQRCodeSwitch.Image = (System.Drawing.Image)resources.GetObject("tsbQRCodeSwitch.Image");
        tsbQRCodeSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbQRCodeSwitch.Name = "tsbQRCodeSwitch";
        tsbQRCodeSwitch.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
        tsbQRCodeSwitch.Size = new System.Drawing.Size(46, 53);
        tsbQRCodeSwitch.Text = "分享";
        tsbQRCodeSwitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbQRCodeSwitch.CheckedChanged += tsbQRCodeSwitch_CheckedChanged;
        // 
        // toolStripSeparator8
        // 
        toolStripSeparator8.Name = "toolStripSeparator8";
        toolStripSeparator8.Size = new System.Drawing.Size(6, 56);
        // 
        // tsbOptionSetting
        // 
        tsbOptionSetting.Image = (System.Drawing.Image)resources.GetObject("tsbOptionSetting.Image");
        tsbOptionSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbOptionSetting.Name = "tsbOptionSetting";
        tsbOptionSetting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        tsbOptionSetting.Size = new System.Drawing.Size(46, 53);
        tsbOptionSetting.Text = "设置";
        tsbOptionSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbOptionSetting.Click += tsbOptionSetting_Click;
        // 
        // toolStripSeparator5
        // 
        toolStripSeparator5.Name = "toolStripSeparator5";
        toolStripSeparator5.Size = new System.Drawing.Size(6, 56);
        // 
        // tsbReload
        // 
        tsbReload.Image = (System.Drawing.Image)resources.GetObject("tsbReload.Image");
        tsbReload.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
        tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbReload.Name = "tsbReload";
        tsbReload.Size = new System.Drawing.Size(60, 53);
        tsbReload.Text = "重启服务";
        tsbReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbReload.Click += tsbReload_Click;
        // 
        // toolStripSeparator7
        // 
        toolStripSeparator7.Name = "toolStripSeparator7";
        toolStripSeparator7.Size = new System.Drawing.Size(6, 56);
        // 
        // tsbCheckUpdate
        // 
        tsbCheckUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbCheckUpdateN, tsbCheckUpdateCore, tsbCheckUpdateDomainList, tsbCheckUpdateIPList });
        tsbCheckUpdate.Image = (System.Drawing.Image)resources.GetObject("tsbCheckUpdate.Image");
        tsbCheckUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbCheckUpdate.Name = "tsbCheckUpdate";
        tsbCheckUpdate.Size = new System.Drawing.Size(69, 53);
        tsbCheckUpdate.Text = "检查更新";
        tsbCheckUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        // 
        // tsbCheckUpdateN
        // 
        tsbCheckUpdateN.Name = "tsbCheckUpdateN";
        tsbCheckUpdateN.Size = new System.Drawing.Size(141, 22);
        tsbCheckUpdateN.Text = "v2rayN";
        tsbCheckUpdateN.Click += tsbCheckUpdateN_Click;
        // 
        // tsbCheckUpdateCore
        // 
        tsbCheckUpdateCore.Name = "tsbCheckUpdateCore";
        tsbCheckUpdateCore.Size = new System.Drawing.Size(141, 22);
        tsbCheckUpdateCore.Text = "v2rayCore";
        tsbCheckUpdateCore.Click += tsbCheckUpdateCore_Click;
        // 
        // tsbCheckUpdateDomainList
        // 
        tsbCheckUpdateDomainList.Name = "tsbCheckUpdateDomainList";
        tsbCheckUpdateDomainList.Size = new System.Drawing.Size(141, 22);
        tsbCheckUpdateDomainList.Text = "Domain list";
        tsbCheckUpdateDomainList.Click += tsbCheckUpdateDomainList_Click;
        // 
        // tsbCheckUpdateIPList
        // 
        tsbCheckUpdateIPList.Name = "tsbCheckUpdateIPList";
        tsbCheckUpdateIPList.Size = new System.Drawing.Size(141, 22);
        tsbCheckUpdateIPList.Text = "IP list";
        tsbCheckUpdateIPList.Click += tsbCheckUpdateIPList_Click;
        // 
        // toolStripSeparator10
        // 
        toolStripSeparator10.Name = "toolStripSeparator10";
        toolStripSeparator10.Size = new System.Drawing.Size(6, 56);
        // 
        // tsbHelp
        // 
        tsbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbAbout, tsbV2rayWebsite });
        tsbHelp.Image = (System.Drawing.Image)resources.GetObject("tsbHelp.Image");
        tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbHelp.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
        tsbHelp.Name = "tsbHelp";
        tsbHelp.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        tsbHelp.Size = new System.Drawing.Size(55, 53);
        tsbHelp.Text = "帮助";
        tsbHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        // 
        // tsbAbout
        // 
        tsbAbout.Name = "tsbAbout";
        tsbAbout.Size = new System.Drawing.Size(163, 22);
        tsbAbout.Text = "v2rayN Project";
        tsbAbout.Click += tsbAbout_Click;
        // 
        // tsbV2rayWebsite
        // 
        tsbV2rayWebsite.Name = "tsbV2rayWebsite";
        tsbV2rayWebsite.Size = new System.Drawing.Size(163, 22);
        tsbV2rayWebsite.Text = "V2Ray Website";
        tsbV2rayWebsite.Click += tsbV2rayWebsite_Click;
        // 
        // tsbPromotion
        // 
        tsbPromotion.ForeColor = System.Drawing.Color.Black;
        tsbPromotion.Image = (System.Drawing.Image)resources.GetObject("tsbPromotion.Image");
        tsbPromotion.ImageTransparentColor = System.Drawing.Color.Magenta;
        tsbPromotion.Name = "tsbPromotion";
        tsbPromotion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        tsbPromotion.Size = new System.Drawing.Size(46, 53);
        tsbPromotion.Text = "推广";
        tsbPromotion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbPromotion.Click += tsbPromotion_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        ClientSize = new System.Drawing.Size(1080, 720);
        Controls.Add(groupBoxServerList);
        Controls.Add(groupBoxInfo);
        Controls.Add(panel1);
        Controls.Add(tsMain);
        MaximizeBox = true;
        MinimizeBox = true;
        Name = "MainForm";
        ShowInTaskbar = false;
        Text = "v2rayN";
        WindowState = System.Windows.Forms.FormWindowState.Minimized;
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        VisibleChanged += MainForm_VisibleChanged;
        scMain.Panel1.ResumeLayout(false);
        scMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
        scMain.ResumeLayout(false);
        cmsLv.ResumeLayout(false);
        cmsMain.ResumeLayout(false);
        groupBoxServerList.ResumeLayout(false);
        groupBoxInfo.ResumeLayout(false);
        groupBoxInfo.PerformLayout();
        ssMain.ResumeLayout(false);
        ssMain.PerformLayout();
        tsMain.ResumeLayout(false);
        tsMain.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxServerList;
    private System.Windows.Forms.GroupBox groupBoxInfo;
    private System.Windows.Forms.TextBox txtMsgBox;
    private ListViewControl lvServers;
    private System.Windows.Forms.NotifyIcon notifyMain;
    private ImageGlass.UI.ModernMenu cmsMain;
    private System.Windows.Forms.ToolStripMenuItem menuExit;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStripMenuItem menuServers;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private ImageGlass.UI.ModernMenu cmsLv;
    private System.Windows.Forms.ToolStripMenuItem menuAddVmessServer;
    private System.Windows.Forms.ToolStripMenuItem menuRemoveServer;
    private System.Windows.Forms.ToolStripMenuItem menuEditServer;
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
    private System.Windows.Forms.ToolStripMenuItem menuOpenSocks;
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
    private System.Windows.Forms.ToolStripMenuItem tsbSubUpdateAndPing;
}

