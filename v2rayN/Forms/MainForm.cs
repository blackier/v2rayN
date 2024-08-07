﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using ImageGlass.Base;
using ImageGlass.Base.WinApi;
using v2rayN.Config;
using v2rayN.Extensions;
using v2rayN.Handlers;

namespace v2rayN.Forms;

public partial class MainForm : BaseForm
{
    private v2rayHandler v2rayHandler;
    private List<int> lvSelecteds = new List<int>();
    private StatisticsHandler statistics = null;

    private ImageGlass.UI.IgTheme _theme { get; set; }

    public MainForm()
    {
        InitializeComponent();

        // Kobe-Light
        _theme = new ImageGlass.UI.IgTheme();
        _theme.Settings.IsDarkMode = false;
        _theme.Colors.ToolbarBgColor = ThemeColor("#F5F6F700");
        _theme.Colors.ToolbarTextColor = ThemeColor("#000");
        _theme.Colors.ToolbarItemHoverColor = ThemeColor("accent:70");
        _theme.Colors.ToolbarItemActiveColor = ThemeColor("accent:120");
        _theme.Colors.ToolbarItemSelectedColor = ThemeColor("accent:100");
        _theme.Colors.MenuBgColor = ThemeColor("#F5F6F7");
        _theme.Colors.MenuBgHoverColor = ThemeColor("accent:120");
        _theme.Colors.MenuTextColor = ThemeColor("#000");
        _theme.Colors.MenuTextHoverColor = ThemeColor("#000");

        cmsLv.Theme = _theme;
        cmsMain.Theme = _theme;

        var tsbSubDropDownMenu = new ImageGlass.UI.ModernMenu(components) { Theme = _theme };
        while (tsbSub.DropDownItems.Count > 0)
            tsbSubDropDownMenu.Items.Add(tsbSub.DropDownItems[0]);
        tsbSub.DropDown = tsbSubDropDownMenu;

        var tsbCheckUpdateDropDownMenu = new ImageGlass.UI.ModernMenu(components) { Theme = _theme };
        while (tsbCheckUpdate.DropDownItems.Count > 0)
            tsbCheckUpdateDropDownMenu.Items.Add(tsbCheckUpdate.DropDownItems[0]);
        tsbCheckUpdate.DropDown = tsbCheckUpdateDropDownMenu;

        var tsbHelpDropDownMenu = new ImageGlass.UI.ModernMenu(components) { Theme = _theme };
        while (tsbHelp.DropDownItems.Count > 0)
            tsbHelpDropDownMenu.Items.Add(tsbHelp.DropDownItems[0]);
        tsbHelp.DropDown = tsbHelpDropDownMenu;

        Text = Misc.GetVersion();

        PACHandler.ProcessEvent += v2rayHandler_ProcessEvent;

        v2rayNConfigHandler.LoadConfig(ref config);
        v2rayHandler = new v2rayHandler();
        v2rayHandler.ProcessEvent += v2rayHandler_ProcessEvent;

        if (config.enableStatistics)
        {
            statistics = new StatisticsHandler(config, UpdateStatisticsHandler);
        }

        Application.ApplicationExit += (sender, args) =>
        {
            v2rayHandler.V2rayStop();

            SystemProxyHandler.Update(config);

            v2rayNConfigHandler.SaveConfig(ref config);
            statistics?.SaveToFile();
            statistics?.Close();
        };

        InitServersView();
        RestoreUI();
    }

    public Color ThemeColor(string? value)
    {
        Color colorItem;
        var systemAccentColor = WinColorsApi.GetAccentColor(true);
        if (value.StartsWith(Const.THEME_SYSTEM_ACCENT_COLOR, StringComparison.InvariantCultureIgnoreCase))
        {
            // example: accent:180
            var valueArr = value.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var accentAlpha = 255;

            // adjust accent color alpha
            if (valueArr.Length > 1)
            {
                _ = int.TryParse(valueArr[1], out accentAlpha);
            }

            colorItem = systemAccentColor.Blend(Color.White, 0.7f, accentAlpha);
        }
        else
        {
            colorItem = BHelper.ColorFromHex(value);
        }
        return colorItem;
    }

    private void MainForm_VisibleChanged(object sender, EventArgs e)
    {
        if (statistics == null || !statistics.Enable)
        {
            return;
        }

        if ((sender as Form).Visible)
        {
            statistics.UpdateUI = true;
        }
        else
        {
            statistics.UpdateUI = false;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        RefreshServers();

        LoadV2ray();

        HideForm();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            StorageUI();
            e.Cancel = true;
            HideForm();
            return;
        }
        PACHandler.StopListenner();
    }

    private void RestoreUI()
    {
        scMain.Panel2Collapsed = true;

        if (!config.uiItem.mainSize.IsEmpty)
        {
            Width = config.uiItem.mainSize.Width;
            Height = config.uiItem.mainSize.Height;
        }

        for (int k = 0; k < lvServers.Columns.Count; k++)
        {
            var width = v2rayNConfigHandler.GetformMainLvColWidth(
                ref config,
                ((EServerColName)k).ToString(),
                lvServers.Columns[k].Width
            );
            lvServers.Columns[k].Width = width;
        }
    }

    private void StorageUI()
    {
        config.uiItem.mainSize = new Size(Width, Height);

        for (int k = 0; k < lvServers.Columns.Count; k++)
        {
            v2rayNConfigHandler.AddformMainLvColWidth(
                ref config,
                ((EServerColName)k).ToString(),
                lvServers.Columns[k].Width
            );
        }
    }

    #region 显示服务器 listview 和 menu

    /// <summary>
    /// 刷新服务器
    /// </summary>
    private void RefreshServers()
    {
        RefreshServersView();
        //lvServers.AutoResizeColumns();
        //RefreshServersMenu();
    }

    /// <summary>
    /// 初始化服务器列表
    /// </summary>
    private void InitServersView()
    {
        lvServers.BeginUpdate();
        lvServers.SmallImageList = new ImageList() { ImageSize = new Size(1, 24) };
        lvServers.Items.Clear();

        lvServers.Columns.Add("", 30);
        lvServers.Columns.Add(StringsRes.I18N("LvServiceType"), 80);
        lvServers.Columns.Add(StringsRes.I18N("LvAlias"), 150);
        lvServers.Columns.Add(StringsRes.I18N("LvAddress"), 150);
        lvServers.Columns.Add(StringsRes.I18N("LvPort"), 80);
        lvServers.Columns.Add(StringsRes.I18N("LvEncryptionMethod"), 100);
        lvServers.Columns.Add(StringsRes.I18N("LvTransportProtocol"), 100);
        lvServers.Columns.Add(StringsRes.I18N("LvSubscription"), 80);
        lvServers.Columns.Add(StringsRes.I18N("LvTestResults"), 100);

        if (statistics != null && statistics.Enable)
        {
            lvServers.Columns.Add(StringsRes.I18N("LvTodayDownloadDataAmount"), 100);
            lvServers.Columns.Add(StringsRes.I18N("LvTodayUploadDataAmount"), 100);
            lvServers.Columns.Add(StringsRes.I18N("LvTotalDownloadDataAmount"), 100);
            lvServers.Columns.Add(StringsRes.I18N("LvTotalUploadDataAmount"), 100);
        }
        lvServers.EndUpdate();
    }

    /// <summary>
    /// 刷新服务器列表
    /// </summary>
    private void RefreshServersView()
    {
        int bottomItemIndex = lvServers.TopItem?.Index ?? 0;
        for (; bottomItemIndex < lvServers.Items.Count; bottomItemIndex++)
        {
            if (!lvServers.Items[bottomItemIndex].Bounds.IntersectsWith(lvServers.ClientRectangle))
            {
                bottomItemIndex -= 2;
                break;
            }
        }

        lvServers.BeginUpdate();
        lvServers.Items.Clear();

        for (int k = 0; k < config.vmess.Count; k++)
        {
            string totalUp = string.Empty,
                totalDown = string.Empty,
                todayUp = string.Empty,
                todayDown = string.Empty;

            ListViewItem lvItem = new ListViewItem();
            if (config.index.Equals(k))
            {
                lvItem.SubItems[0].Text = "√";
                lvItem.ForeColor = Color.DodgerBlue;
                lvItem.Font = new Font(lvItem.Font, FontStyle.Bold);
            }
            // 隔行着色
            if (k % 2 == 1)
            {
                lvItem.BackColor = Color.WhiteSmoke;
            }

            ProfileItem item = config.vmess[k];

            void _addSubItem(ListViewItem i, string name, string text)
            {
                i.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = name, Text = text });
            }
            _addSubItem(lvItem, EServerColName.configType.ToString(), ((EConfigType)item.configType).ToString());
            _addSubItem(lvItem, EServerColName.remarks.ToString(), item.remarks);
            _addSubItem(lvItem, EServerColName.address.ToString(), item.address);
            _addSubItem(lvItem, EServerColName.port.ToString(), item.port.ToString());
            _addSubItem(lvItem, EServerColName.security.ToString(), item.security);
            _addSubItem(lvItem, EServerColName.network.ToString(), item.network);
            _addSubItem(lvItem, EServerColName.subRemarks.ToString(), item.getSubRemarks(config));
            _addSubItem(lvItem, EServerColName.testResult.ToString(), item.testResult);
            if (statistics != null && statistics.Enable)
            {
                ServerStatItem sItem = statistics.Statistic.Find(item_ => item_.itemId == item.getItemId());
                if (sItem != null)
                {
                    totalUp = Misc.HumanFy(sItem.totalUp);
                    totalDown = Misc.HumanFy(sItem.totalDown);
                    todayUp = Misc.HumanFy(sItem.todayUp);
                    todayDown = Misc.HumanFy(sItem.todayDown);
                }
                _addSubItem(lvItem, EServerColName.todayDown.ToString(), todayDown);
                _addSubItem(lvItem, EServerColName.todayUp.ToString(), todayUp);
                _addSubItem(lvItem, EServerColName.totalDown.ToString(), totalDown);
                _addSubItem(lvItem, EServerColName.totalUp.ToString(), totalUp);
            }

            lvServers.Items.Add(lvItem);
        }
        lvServers.EndUpdate();

        if (bottomItemIndex < lvServers.Items.Count)
            lvServers.EnsureVisible(bottomItemIndex);
        else if (config.index > 0 && config.index < lvServers.Items.Count)
            lvServers.EnsureVisible(config.index);
    }

    /// <summary>
    /// 刷新托盘服务器菜单
    /// </summary>
    private void RefreshServersMenu()
    {
        var dropDownMenu = new ImageGlass.UI.ModernMenu(components) { Theme = _theme };
        for (int k = 0; k < config.vmess.Count; k++)
        {
            ToolStripMenuItem ts = new ToolStripMenuItem(config.vmess[k].getSummary()) { Tag = k };
            ts.Click += new EventHandler(ts_Click);
            if (config.index.Equals(k))
                ts.Checked = true;

            dropDownMenu.Items.Add(ts);
        }
        menuServers.DropDown = dropDownMenu;
    }

    private void ts_Click(object sender, EventArgs e)
    {
        try
        {
            ToolStripItem ts = (ToolStripItem)sender;
            int index = Misc.ToInt(ts.Tag);
            SetDefaultServer(index);
        }
        catch { }
    }

    private void lvServers_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = -1;
        try
        {
            if (lvServers.SelectedIndices.Count > 0)
            {
                index = lvServers.SelectedIndices[0];
            }
        }
        catch { }
        if (index < 0)
        {
            return;
        }
        //qrCodeControl.showQRCode(index, config);
    }

    private void DisplayToolStatus()
    {
        toolSslSocksPort.Text = $"{Global.Loopback}:{config.inbound[0].localPort}";
        toolSslHttpPort.Text = $"{Global.Loopback}:{config.inbound[0].localPort + 1}";

        notifyMain.Icon = MainFormHandler.Instance.GetNotifyIcon(config, Icon);
    }

    private void ssMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        if (!Misc.IsNullOrEmpty(e.ClickedItem.Text))
        {
            Misc.SetClipboardData(e.ClickedItem.Text);
        }
    }

    private void lvServers_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (e.Column < 0)
            return;

        try
        {
            var tag = lvServers.Columns[e.Column].Tag?.ToString();
            bool asc = Misc.IsNullOrEmpty(tag) ? true : !Convert.ToBoolean(tag);
            if (v2rayNConfigHandler.SortServers(ref config, (EServerColName)e.Column, asc) != 0)
                return;

            lvServers.Columns[e.Column].Tag = Convert.ToString(asc);
            lvServers.SortColumnIndex = e.Column > 0 ? e.Column : -1;
            lvServers.SortColumnOrder = asc ? SortOrder.Ascending : SortOrder.Descending;
            RefreshServers();
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }
    #endregion

    #region v2ray 操作

    /// <summary>
    /// 载入V2ray
    /// </summary>
    private void LoadV2ray()
    {
        tsbReload.Enabled = false;

        if (Global.reloadV2ray)
        {
            ClearMsg();
        }
        v2rayHandler.LoadV2ray(config);
        Global.reloadV2ray = false;
        v2rayNConfigHandler.SaveConfig(ref config, false);
        statistics?.SaveToFile();

        ChangeHttpProxyStatus(config.listenerType);

        tsbReload.Enabled = true;
    }

    /// <summary>
    /// 关闭V2ray
    /// </summary>
    private void CloseV2ray()
    {
        v2rayNConfigHandler.SaveConfig(ref config, false);
        statistics?.SaveToFile();

        ChangeHttpProxyStatus(0);

        v2rayHandler.V2rayStop();
    }

    #endregion

    #region 功能按钮

    private void lvServers_Click(object sender, EventArgs e)
    {
        int index = -1;
        try
        {
            if (lvServers.SelectedIndices.Count > 0)
            {
                index = lvServers.SelectedIndices[0];
            }
        }
        catch { }
        if (index < 0)
        {
            return;
        }
        qrCodeControl.showQRCode(index, config);
    }

    private void lvServers_DoubleClick(object sender, EventArgs e)
    {
        int index = GetLvSelectedIndex();
        if (index < 0)
        {
            return;
        }
        ShowServerForm(config.vmess[index].configType, index);
    }

    private void ShowServerForm(EConfigType configType, int index)
    {
        BaseServerForm fm;
        switch (configType)
        {
            case EConfigType.VMess:
                fm = new ConfigVMessForm();
                break;
            case EConfigType.Shadowsocks:
                fm = new ConfigShadowsocksForm();
                break;
            case EConfigType.Socks:
                fm = new ConfigSocksForm();
                break;
            case EConfigType.VLESS:
                fm = new ConfigVLESSForm();
                break;
            case EConfigType.Trojan:
                fm = new ConfigTrojanForm();
                break;
            default:
                fm = new();
                break;
        }
        fm.EditIndex = index;
        if (fm.ShowDialog() == DialogResult.OK)
        {
            //刷新
            RefreshServers();
            LoadV2ray();
        }
    }

    private void lvServers_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    menuSelectAll_Click(null, null);
                    break;
                case Keys.C:
                    menuExport2ShareUrl_Click(null, null);
                    break;
                case Keys.V:
                    menuAddServers_Click(null, null);
                    break;
                case Keys.P:
                    menuPingServer_Click(null, null);
                    break;
                case Keys.O:
                    menuTcpingServer_Click(null, null);
                    break;
                case Keys.R:
                    menuRealPingServer_Click(null, null);
                    break;
                case Keys.S:
                    menuScanScreen_Click(null, null);
                    break;
                case Keys.T:
                    menuSpeedServer_Click(null, null);
                    break;
            }
        }
        else
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    menuSetDefaultServer_Click(null, null);
                    break;
                case Keys.Delete:
                    menuRemoveServer_Click(null, null);
                    break;
                case Keys.T:
                    menuMoveTop_Click(null, null);
                    break;
                case Keys.B:
                    menuMoveBottom_Click(null, null);
                    break;
                case Keys.U:
                    menuMoveUp_Click(null, null);
                    break;
                case Keys.D:
                    menuMoveDown_Click(null, null);
                    break;
            }
        }
    }

    private void menuAddVmessServer_Click(object sender, EventArgs e)
    {
        ShowServerForm(EConfigType.VMess, -1);
    }

    private void menuAddVlessServer_Click(object sender, EventArgs e)
    {
        ShowServerForm(EConfigType.VLESS, -1);
    }

    private void menuRemoveServer_Click(object sender, EventArgs e)
    {
        int index = GetLvSelectedIndex();
        if (index < 0)
        {
            return;
        }
        if (MsgBox.ShowYesNo(StringsRes.I18N("RemoveServer")) == DialogResult.No)
        {
            return;
        }
        for (int k = lvSelecteds.Count - 1; k >= 0; k--)
        {
            v2rayNConfigHandler.RemoveServer(ref config, lvSelecteds[k]);
        }
        //刷新
        RefreshServers();
        LoadV2ray();
    }

    private void menuRemoveDuplicateServer_Click(object sender, EventArgs e)
    {
        Misc.DedupServerList(config.vmess, out List<ProfileItem> servers, config.keepOlderDedupl);
        int oldCount = config.vmess.Count;
        int newCount = servers.Count;
        if (servers != null)
        {
            config.vmess = servers;
        }
        //刷新
        RefreshServers();
        LoadV2ray();
        MsgBox.Show(string.Format(StringsRes.I18N("RemoveDuplicateServerResult"), oldCount, newCount));
    }

    private void menuCopyServer_Click(object sender, EventArgs e)
    {
        int index = GetLvSelectedIndex();
        if (index < 0)
        {
            return;
        }
        if (v2rayNConfigHandler.CopyServer(ref config, index) == 0)
        {
            //刷新
            RefreshServers();
        }
    }

    private void menuSetDefaultServer_Click(object sender, EventArgs e)
    {
        int index = GetLvSelectedIndex();
        if (index < 0)
        {
            return;
        }
        SetDefaultServer(index);
    }

    private void menuPingServer_Click(object sender, EventArgs e)
    {
        Speedtest("ping");
    }

    private void menuTcpingServer_Click(object sender, EventArgs e)
    {
        Speedtest("tcping");
    }

    private void menuRealPingServer_Click(object sender, EventArgs e)
    {
        //if (!config.sysAgentEnabled)
        //{
        //    UI.Show(UIRes.I18N("NeedHttpGlobalProxy"));
        //    return;
        //}

        //UI.Show(UIRes.I18N("SpeedServerTips"));

        Speedtest("realping");
    }

    private void menuSpeedServer_Click(object sender, EventArgs e)
    {
        //if (!config.sysAgentEnabled)
        //{
        //    UI.Show(UIRes.I18N("NeedHttpGlobalProxy"));
        //    return;
        //}

        //UI.Show(UIRes.I18N("SpeedServerTips"));

        Speedtest("speedtest");
    }

    private void Speedtest(string actionType)
    {
        if (GetLvSelectedIndex() < 0)
        {
            return;
        }

        ClearTestResult();
        SpeedTestHandler statistics = new SpeedTestHandler(
            ref config,
            ref v2rayHandler,
            lvSelecteds,
            actionType,
            UpdateSpeedtestHandler
        );
    }

    private void SpeedtestAll(string actionType)
    {
        lvSelecteds.Clear();
        for (int i = 0; i < lvServers.Items.Count; i++)
        {
            lvSelecteds.Add(i);
        }

        ClearTestResult();
        SpeedTestHandler statistics = new SpeedTestHandler(
            ref config,
            ref v2rayHandler,
            lvSelecteds,
            actionType,
            UpdateSpeedtestHandler
        );
    }

    private void tsbTestMe_Click(object sender, EventArgs e)
    {
        string result = httpProxyTest() + "ms";
        AppendText(false, string.Format(StringsRes.I18N("TestMeOutput"), result));
    }

    private int httpProxyTest()
    {
        SpeedTestHandler statistics = new SpeedTestHandler(
            ref config,
            ref v2rayHandler,
            lvSelecteds,
            "",
            UpdateSpeedtestHandler
        );
        return statistics.RunAvailabilityCheck();
    }

    private void menuExport2ShareUrl_Click(object sender, EventArgs e)
    {
        GetLvSelectedIndex();

        StringBuilder sb = new StringBuilder();
        foreach (int v in lvSelecteds)
        {
            string url = v2rayNConfigHandler.GetVmessQRCode(config, v);
            if (Misc.IsNullOrEmpty(url))
            {
                continue;
            }
            sb.Append(url);
            sb.AppendLine();
        }
        if (sb.Length > 0)
        {
            Misc.SetClipboardData(sb.ToString());
            AppendText(false, StringsRes.I18N("BatchExportURLSuccessfully"));
            //UI.Show(UIRes.I18N("BatchExportURLSuccessfully"));
        }
    }

    private void menuExport2SubContent_Click(object sender, EventArgs e)
    {
        GetLvSelectedIndex();

        StringBuilder sb = new StringBuilder();
        foreach (int v in lvSelecteds)
        {
            string url = v2rayNConfigHandler.GetVmessQRCode(config, v);
            if (Misc.IsNullOrEmpty(url))
            {
                continue;
            }
            sb.Append(url);
            sb.AppendLine();
        }
        if (sb.Length > 0)
        {
            Misc.SetClipboardData(Misc.Base64Encode(sb.ToString()));
            MsgBox.Show(StringsRes.I18N("BatchExportSubscriptionSuccessfully"));
        }
    }

    private void tsbOptionSetting_Click(object sender, EventArgs e)
    {
        OptionSettingForm fm = new OptionSettingForm();
        if (fm.ShowDialog() == DialogResult.OK)
        {
            //刷新
            RefreshServers();
            LoadV2ray();
            SystemProxyHandler.Update(config);
        }
    }

    private void tsbReload_Click(object sender, EventArgs e)
    {
        Global.reloadV2ray = true;
        LoadV2ray();
    }

    private void tsbClose_Click(object sender, EventArgs e)
    {
        HideForm();
        //this.WindowState = FormWindowState.Minimized;
    }

    /// <summary>
    /// 设置活动服务器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private int SetDefaultServer(int index)
    {
        if (index < 0)
        {
            MsgBox.Show(StringsRes.I18N("PleaseSelectServer"));
            return -1;
        }
        if (v2rayNConfigHandler.SetDefaultServer(ref config, index) == 0)
        {
            //刷新
            RefreshServers();
            LoadV2ray();
        }
        return 0;
    }

    /// <summary>
    /// 取得ListView选中的行
    /// </summary>
    /// <returns></returns>
    private int GetLvSelectedIndex()
    {
        int index = -1;
        lvSelecteds.Clear();
        try
        {
            if (lvServers.SelectedIndices.Count <= 0)
            {
                MsgBox.Show(StringsRes.I18N("PleaseSelectServer"));
                return index;
            }

            index = lvServers.SelectedIndices[0];
            foreach (int i in lvServers.SelectedIndices)
            {
                lvSelecteds.Add(i);
            }
            return index;
        }
        catch
        {
            return index;
        }
    }

    private void menuAddCustomServer_Click(object sender, EventArgs e)
    {
        MsgBox.Show(StringsRes.I18N("CustomServerTips"));

        OpenFileDialog fileDialog = new OpenFileDialog { Multiselect = false, Filter = "Config|*.json|All|*.*" };
        if (fileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        string fileName = fileDialog.FileName;
        if (Misc.IsNullOrEmpty(fileName))
        {
            return;
        }

        if (v2rayNConfigHandler.AddCustomServer(ref config, fileName) == 0)
        {
            //刷新
            RefreshServers();
            //LoadV2ray();
            MsgBox.Show(StringsRes.I18N("SuccessfullyImportedCustomServer"));
        }
        else
        {
            MsgBox.ShowWarning(StringsRes.I18N("FailedImportedCustomServer"));
        }
    }

    private void menuAddShadowsocksServer_Click(object sender, EventArgs e)
    {
        ShowServerForm(EConfigType.Shadowsocks, -1);
        ShowForm();
    }

    private void menuAddSocksServer_Click(object sender, EventArgs e)
    {
        ShowServerForm(EConfigType.Socks, -1);
        ShowForm();
    }

    private void menuAddTrojanServer_Click(object sender, EventArgs e)
    {
        ShowServerForm(EConfigType.Trojan, -1);
        ShowForm();
    }

    private void menuAddServers_Click(object sender, EventArgs e)
    {
        string clipboardData = Misc.GetClipboardData();
        int result = AddBatchServers(clipboardData);
        if (result > 0)
        {
            MsgBox.Show(string.Format(StringsRes.I18N("SuccessfullyImportedServerViaClipboard"), result));
        }
    }

    private void menuScanScreen_Click(object sender, EventArgs e)
    {
        HideForm();
        bgwScan.RunWorkerAsync();
    }

    private int AddBatchServers(string clipboardData, string subid = "", string protocolFilter = "")
    {
        int counter;
        int _Add()
        {
            return v2rayNConfigHandler.AddBatchServers(ref config, clipboardData, subid, protocolFilter);
        }
        counter = _Add();
        if (counter < 1)
        {
            clipboardData = Misc.Base64Decode(clipboardData);
            counter = _Add();
        }
        RefreshServers();
        return counter;
    }

    private void menuUpdateSubscriptions_Click(object sender, EventArgs e)
    {
        UpdateSubscriptionProcess();
    }

    #endregion

    #region 提示信息

    /// <summary>
    /// 消息委托
    /// </summary>
    /// <param name="notify"></param>
    /// <param name="msg"></param>
    void v2rayHandler_ProcessEvent(bool notify, string msg)
    {
        AppendText(notify, msg);
    }

    delegate void AppendTextDelegate(string text);

    void AppendText(bool notify, string msg)
    {
        try
        {
            AppendText(msg);
            if (notify)
            {
                notifyMsg(msg);
            }
        }
        catch { }
    }

    void AppendText(string text)
    {
        if (txtMsgBox.InvokeRequired)
        {
            Invoke(new AppendTextDelegate(AppendText), new object[] { text });
        }
        else
        {
            //this.txtMsgBox.AppendText(text);
            ShowMsg(text);
        }
    }

    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="msg"></param>
    private void ShowMsg(string msg)
    {
        if (txtMsgBox.Lines.Length > 999)
        {
            ClearMsg();
        }
        txtMsgBox.AppendText(msg);
        if (!msg.EndsWith(Environment.NewLine))
        {
            txtMsgBox.AppendText(Environment.NewLine);
        }
    }

    /// <summary>
    /// 清除信息
    /// </summary>
    private void ClearMsg()
    {
        txtMsgBox.Clear();
    }

    /// <summary>
    /// 托盘信息
    /// </summary>
    /// <param name="msg"></param>
    private void notifyMsg(string msg)
    {
        notifyMain.Text = msg;
    }

    #endregion

    #region 托盘事件

    private void notifyMain_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ShowForm();
        }
    }

    private void menuExit_Click(object sender, EventArgs e)
    {
        Visible = false;
        Close();

        Application.Exit();
    }

    private void ShowForm()
    {
        if (WindowState == FormWindowState.Minimized || !Visible)
        {
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        txtMsgBox.ScrollToCaret();
        if (config.index >= 0 && config.index < lvServers.Items.Count)
        {
            lvServers.EnsureVisible(config.index); // workaround
        }

        // According to some sources these steps gurantee that an app will be brought to foreground.
        Activate();
        TopMost = true;
        TopMost = false;
        Focus();
    }

    private void HideForm()
    {
        Visible = false;
    }

    #endregion

    #region 后台测速

    private void SetTestResult(int k, string txt)
    {
        if (k < lvServers.Items.Count)
        {
            config.vmess[k].testResult = txt;
            lvServers.Items[k].SubItems["testResult"].Text = txt;
        }
    }

    private void ClearTestResult()
    {
        foreach (int s in lvSelecteds)
        {
            SetTestResult(s, "");
        }
    }

    private void UpdateSpeedtestHandler(int index, string msg)
    {
        lvServers.Invoke(
            (MethodInvoker)
                delegate
                {
                    SetTestResult(index, msg);
                }
        );
    }

    private void UpdateStatisticsHandler(
        ulong proxyUp,
        ulong proxyDown,
        ulong directUp,
        ulong directDown,
        List<ServerStatItem> statistics
    )
    {
        try
        {
            directUp /= (ulong)(config.statisticsFreshRate / 1000f);
            directDown /= (ulong)(config.statisticsFreshRate / 1000f);
            proxyUp /= (ulong)(config.statisticsFreshRate / 1000f);
            proxyDown /= (ulong)(config.statisticsFreshRate / 1000f);

            toolSslServerSpeed.Text = string.Format(
                $"Direct:{Misc.HumanFy(directUp),9}/s↑ | {Misc.HumanFy(directDown) + "/s↓",-13} Proxy:{Misc.HumanFy(proxyUp),9}/s↑ | {Misc.HumanFy(proxyDown) + "/s↓",-13}"
            );

            List<string[]> datas = new List<string[]>();
            for (int i = 0; i < config.vmess.Count; i++)
            {
                int index = statistics.FindIndex(item_ => item_.itemId == config.vmess[i].getItemId());
                if (index != -1)
                {
                    lvServers.Invoke(
                        (MethodInvoker)
                            delegate
                            {
                                lvServers.BeginUpdate();

                                lvServers.Items[i].SubItems["todayDown"].Text = Misc.HumanFy(
                                    statistics[index].todayDown
                                );
                                lvServers.Items[i].SubItems["todayUp"].Text = Misc.HumanFy(
                                    statistics[index].todayUp
                                );
                                lvServers.Items[i].SubItems["totalDown"].Text = Misc.HumanFy(
                                    statistics[index].totalDown
                                );
                                lvServers.Items[i].SubItems["totalUp"].Text = Misc.HumanFy(
                                    statistics[index].totalUp
                                );

                                lvServers.EndUpdate();
                            }
                    );
                }
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    #endregion

    #region 移动服务器

    private void menuMoveTop_Click(object sender, EventArgs e)
    {
        MoveServer(EMove.Top);
    }

    private void menuMoveUp_Click(object sender, EventArgs e)
    {
        MoveServer(EMove.Up);
    }

    private void menuMoveDown_Click(object sender, EventArgs e)
    {
        MoveServer(EMove.Down);
    }

    private void menuMoveBottom_Click(object sender, EventArgs e)
    {
        MoveServer(EMove.Bottom);
    }

    private void MoveServer(EMove eMove)
    {
        int index = GetLvSelectedIndex();
        if (index < 0)
        {
            MsgBox.Show(StringsRes.I18N("PleaseSelectServer"));
            return;
        }
        if (v2rayNConfigHandler.MoveServer(ref config, index, eMove) == 0)
        {
            //TODO: reload is not good.
            RefreshServers();
            //LoadV2ray();
        }
    }

    private void menuSelectAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvServers.Items)
        {
            item.Selected = true;
        }
    }

    #endregion

    #region 系统代理相关

    private void menuOpenHttp_Click(object sender, EventArgs e)
    {
        SetListenerType(ListenerType.openSystemProxyHttp);
    }

    private void menuOpenSocks_Click(object sender, EventArgs e)
    {
        SetListenerType(ListenerType.openSystemProxySocks);
    }

    private void menuCloseHttp_Click(object sender, EventArgs e)
    {
        SetListenerType(ListenerType.closeSystemProxy);
    }

    private void SetListenerType(ListenerType type)
    {
        config.listenerType = type;
        ChangeHttpProxyStatus(type);
    }

    private void ChangeHttpProxyStatus(ListenerType type)
    {
        SystemProxyHandler.Update(config);

        for (int k = 0; k < menuSysAgentMode.DropDownItems.Count; k++)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)menuSysAgentMode.DropDownItems[k]);
            item.Checked = ((int)type == k);
        }

        v2rayNConfigHandler.SaveConfig(ref config, false);
        DisplayToolStatus();
    }

    #endregion

    #region CheckUpdate

    private void askToDownload(DownloadHandler downloadHandle, string url)
    {
        if (MsgBox.ShowYesNo(string.Format(StringsRes.I18N("DownloadYesNo"), url)) == DialogResult.Yes)
        {
            if (httpProxyTest() > 0)
            {
                int httpPort = config.GetLocalPort(Global.InboundHttp);
                WebProxy webProxy = new WebProxy(Global.Loopback, httpPort);
                downloadHandle.DownloadFileAsync(url, webProxy, 600);
            }
            else
            {
                downloadHandle.DownloadFileAsync(url, null, 600);
            }
        }
    }

    private void tsbCheckUpdateN_Click(object sender, EventArgs e)
    {
        DownloadHandler downloadHandle = new DownloadHandler();
        downloadHandle.AbsoluteCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, string.Format(StringsRes.I18N("MsgParsingSuccessfully"), "v2rayN"));

                string url = args.Msg;
                Invoke(
                    (MethodInvoker)(
                        delegate
                        {
                            askToDownload(downloadHandle, url);
                        }
                    )
                );
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.UpdateCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, StringsRes.I18N("MsgDownloadV2rayCoreSuccessfully"));

                try
                {
                    string fileName = Misc.GetPath(downloadHandle.downloadFileName);
                    Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "v2rayUpgrade.exe",
                            Arguments = "\"" + fileName + "\"",
                            WorkingDirectory = Misc.StartupPath()
                        }
                    };
                    process.Start();
                    if (process.Id > 0)
                    {
                        menuExit_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    AppendText(false, ex.Message);
                }
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.Error += (sender2, args) =>
        {
            AppendText(true, args.GetException().Message);
        };

        AppendText(false, string.Format(StringsRes.I18N("MsgStartUpdating"), "v2rayN"));
        downloadHandle.CheckUpdateAsync(DownloadHandler.downloadType.v2rayN);
    }

    private void tsbCheckUpdateCore_Click(object sender, EventArgs e)
    {
        DownloadHandler downloadHandle = new DownloadHandler();
        downloadHandle.AbsoluteCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, string.Format(StringsRes.I18N("MsgParsingSuccessfully"), "v2rayCore"));

                string url = args.Msg;
                Invoke(
                    (MethodInvoker)(
                        delegate
                        {
                            askToDownload(downloadHandle, url);
                        }
                    )
                );
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.UpdateCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, StringsRes.I18N("MsgDownloadV2rayCoreSuccessfully"));
                AppendText(false, StringsRes.I18N("MsgUnpacking"));

                try
                {
                    CloseV2ray();

                    string fileName = downloadHandle.downloadFileName;
                    fileName = Misc.GetPath(fileName);
                    FileManager.ZipExtractToFile(fileName);

                    AppendText(false, StringsRes.I18N("MsgUpdateV2rayCoreSuccessfullyMore"));

                    Global.reloadV2ray = true;
                    LoadV2ray();

                    AppendText(false, StringsRes.I18N("MsgUpdateV2rayCoreSuccessfully"));
                }
                catch (Exception ex)
                {
                    AppendText(false, ex.Message);
                }
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.Error += (sender2, args) =>
        {
            AppendText(true, args.GetException().Message);
        };

        AppendText(false, string.Format(StringsRes.I18N("MsgStartUpdating"), "v2rayCore"));
        downloadHandle.CheckUpdateAsync(DownloadHandler.downloadType.v2rayCore);
    }

    private void tsbCheckUpdateDomainList_Click(object sender, EventArgs e)
    {
        DownloadHandler downloadHandle = new DownloadHandler();
        downloadHandle.AbsoluteCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, string.Format(StringsRes.I18N("MsgParsingSuccessfully"), "Domain list"));

                string url = args.Msg;
                Invoke(
                    (MethodInvoker)(
                        delegate
                        {
                            askToDownload(downloadHandle, url);
                        }
                    )
                );
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.UpdateCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, StringsRes.I18N("MsgDownloadDomainListSuccessfully"));

                try
                {
                    CloseV2ray();
                    Global.reloadV2ray = true;
                    LoadV2ray();

                    AppendText(false, StringsRes.I18N("MsgReplaceDomainListSuccessfully"));
                }
                catch (Exception ex)
                {
                    AppendText(false, ex.Message);
                }
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.Error += (sender2, args) =>
        {
            AppendText(true, args.GetException().Message);
        };

        AppendText(false, string.Format(StringsRes.I18N("MsgStartUpdating"), "Domain list"));
        downloadHandle.CheckUpdateAsync(DownloadHandler.downloadType.domainList);
    }

    private void tsbCheckUpdateIPList_Click(object sender, EventArgs e)
    {
        DownloadHandler downloadHandle = new DownloadHandler();
        downloadHandle.AbsoluteCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, string.Format(StringsRes.I18N("MsgParsingSuccessfully"), "IP list"));

                string url = args.Msg;
                Invoke(
                    (MethodInvoker)(
                        delegate
                        {
                            askToDownload(downloadHandle, url);
                        }
                    )
                );
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.UpdateCompleted += (sender2, args) =>
        {
            if (args.Success)
            {
                AppendText(false, StringsRes.I18N("MsgDownloadIPListSuccessfully"));

                try
                {
                    CloseV2ray();
                    Global.reloadV2ray = true;
                    LoadV2ray();

                    AppendText(false, StringsRes.I18N("MsgReplaceIPListSuccessfully"));
                }
                catch (Exception ex)
                {
                    AppendText(false, ex.Message);
                }
            }
            else
            {
                AppendText(false, args.Msg);
            }
        };
        downloadHandle.Error += (sender2, args) =>
        {
            AppendText(true, args.GetException().Message);
        };

        AppendText(false, string.Format(StringsRes.I18N("MsgStartUpdating"), "IP list"));
        downloadHandle.CheckUpdateAsync(DownloadHandler.downloadType.ipList);
    }

    #endregion

    #region Help


    private void tsbAbout_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", Global.AboutUrl);
    }

    private void tsbV2rayWebsite_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", Global.v2rayWebsiteUrl);
    }

    private void tsbPromotion_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", $"{Misc.Base64Decode(Global.PromotionUrl)}");
    }
    #endregion

    #region ScanScreen


    private void bgwScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        string ret = Utils.QRCode.ScanQRCodeFromScreen();
        bgwScan.ReportProgress(0, ret);
    }

    private void bgwScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        ShowForm();

        string result = Convert.ToString(e.UserState);
        if (Misc.IsNullOrEmpty(result))
        {
            Utils.MsgBox.ShowWarning(Utils.StringsRes.I18N("NoValidQRcodeFound"));
        }
        else
        {
            if (AddBatchServers(result) > 0)
            {
                Utils.MsgBox.Show(Utils.StringsRes.I18N("SuccessfullyImportedServerViaScan"));
            }
        }
    }

    #endregion

    #region 订阅
    private void tsbSubSetting_Click(object sender, EventArgs e)
    {
        SubSettingForm fm = new SubSettingForm();
        if (fm.ShowDialog() == DialogResult.OK)
        {
            RefreshServers();
        }
    }

    private void tsbSubUpdate_Click(object sender, EventArgs e)
    {
        UpdateSubscriptionProcess();
    }

    private void tsbSubUpdateAndPing_Click(object sender, EventArgs e)
    {
        UpdateSubscriptionProcess(true);
    }

    /// <summary>
    /// the subscription update process
    /// </summary>
    private void UpdateSubscriptionProcess(bool needSpeedtest = false)
    {
        AppendText(false, StringsRes.I18N("MsgUpdateSubscriptionStart"));

        if (config.subItem == null || config.subItem.Count <= 0)
        {
            AppendText(false, StringsRes.I18N("MsgNoValidSubscription"));
            return;
        }

        for (int k = 1; k <= config.subItem.Count; k++)
        {
            string id = config.subItem[k - 1].id.TrimEx();
            string url = config.subItem[k - 1].url.TrimEx();
            string protocolFilter = config.subItem[k - 1].protocolFilter.TrimEx();
            string hashCode = $"{k}->";
            if (config.subItem[k - 1].enabled == false)
            {
                continue;
            }
            if (Misc.IsNullOrEmpty(id) || Misc.IsNullOrEmpty(url))
            {
                AppendText(false, $"{hashCode}{StringsRes.I18N("MsgNoValidSubscription")}");
                continue;
            }

            DownloadHandler downloadHandle3 = new DownloadHandler();
            downloadHandle3.UpdateCompleted += (sender2, args) =>
            {
                if (args.Success)
                {
                    AppendText(false, $"{hashCode}{StringsRes.I18N("MsgGetSubscriptionSuccessfully")}");
                    string result = Misc.Base64Decode(args.Msg);
                    if (Misc.IsNullOrEmpty(result))
                    {
                        AppendText(false, $"{hashCode}{StringsRes.I18N("MsgSubscriptionDecodingFailed")}");
                        return;
                    }

                    v2rayNConfigHandler.RemoveServerViaSubid(ref config, id);
                    AppendText(false, $"{hashCode}{StringsRes.I18N("MsgClearSubscription")}");
                    RefreshServers();
                    if (AddBatchServers(result, id, protocolFilter) > 0) { }
                    else
                    {
                        AppendText(false, $"{hashCode}{StringsRes.I18N("MsgFailedImportSubscription")}");
                    }
                    AppendText(false, $"{hashCode}{StringsRes.I18N("MsgUpdateSubscriptionEnd")}");

                    if (needSpeedtest)
                        SpeedtestAll("realping");
                }
                else
                {
                    AppendText(false, args.Msg);
                }
            };
            downloadHandle3.Error += (sender2, args) =>
            {
                AppendText(true, args.GetException().Message);
            };
            WebProxy webProxy = null;
            if (config.listenerType == ListenerType.openSystemProxyHttp)
            {
                int httpPort = config.GetLocalPort(Global.InboundHttp);
                webProxy = new WebProxy(Global.Loopback, httpPort);
            }
            downloadHandle3.WebDownloadString(url, webProxy);
            AppendText(false, $"{hashCode}{StringsRes.I18N("MsgStartGettingSubscriptions")}");
        }
    }

    private void tsbQRCodeSwitch_CheckedChanged(object sender, EventArgs e)
    {
        bool bShow = tsbQRCodeSwitch.Checked;
        scMain.Panel2Collapsed = !bShow;
    }
    #endregion
}
