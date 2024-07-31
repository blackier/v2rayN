using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using v2rayN.Extensions;
using v2rayN.Handlers;

namespace v2rayN.Forms;

class ComboItem
{
    public int ID { get; set; }
    public string Text { get; set; }
}

public partial class OptionSettingForm : BaseForm
{
    public OptionSettingForm()
    {
        InitializeComponent();
    }

    private void OptionSettingForm_Load(object sender, EventArgs e)
    {
        InitBase();

        InitRouting();

        InitKCP();

        InitGUI();
    }

    /// <summary>
    /// 初始化基础设置
    /// </summary>
    private void InitBase()
    {
        //日志
        chklogEnabled.Checked = config.logEnabled;
        cmbloglevel.Text = config.loglevel;

        //Mux
        chkmuxEnabled.Checked = config.muxEnabled;

        //本地监听
        if (config.inbound.Count > 0)
        {
            txtlocalPort.Text = config.inbound[0].localPort.ToString();
            cmbprotocol.Text = config.inbound[0].protocol.ToString();
            chkudpEnabled.Checked = config.inbound[0].udpEnabled;
            chksniffingEnabled.Checked = config.inbound[0].sniffingEnabled;
        }

        //remoteDNS
        txtremoteDNS.Text = config.remoteDNS;

        cmblistenerType.SelectedIndex = (int)config.listenerType;

        chkdefAllowInsecure.Checked = config.defAllowInsecure;
    }

    /// <summary>
    /// 初始化路由设置
    /// </summary>
    private void InitRouting()
    {
        //路由
        cmbdomainStrategy.Text = config.domainStrategy;
        cmbroutingMode.SelectedIndex = 0;

        txtUseragent.Text = Misc.List2String(config.useragent, true);
        txtUserdirect.Text = Misc.List2String(config.userdirect, true);
        txtUserblock.Text = Misc.List2String(config.userblock, true);
    }

    /// <summary>
    /// 初始化KCP设置
    /// </summary>
    private void InitKCP()
    {
        txtKcpmtu.Text = config.kcpItem.mtu.ToString();
        txtKcptti.Text = config.kcpItem.tti.ToString();
        txtKcpuplinkCapacity.Text = config.kcpItem.uplinkCapacity.ToString();
        txtKcpdownlinkCapacity.Text = config.kcpItem.downlinkCapacity.ToString();
        txtKcpreadBufferSize.Text = config.kcpItem.readBufferSize.ToString();
        txtKcpwriteBufferSize.Text = config.kcpItem.writeBufferSize.ToString();
        chkKcpcongestion.Checked = config.kcpItem.congestion;
    }

    /// <summary>
    /// 初始化v2rayN GUI设置
    /// </summary>
    private void InitGUI()
    {
        //开机自动启动
        chkAutoRun.Checked = Misc.IsAutoRun();

        chkAllowLANConn.Checked = config.allowLANConn;
        chkEnableStatistics.Checked = config.enableStatistics;
        chkKeepOlderDedupl.Checked = config.keepOlderDedupl;

        ComboItem[] cbSource = new ComboItem[]
        {
            new ComboItem { ID = (int)Global.StatisticsFreshRate.quick, Text = StringsRes.I18N("QuickFresh") },
            new ComboItem { ID = (int)Global.StatisticsFreshRate.medium, Text = StringsRes.I18N("MediumFresh") },
            new ComboItem { ID = (int)Global.StatisticsFreshRate.slow, Text = StringsRes.I18N("SlowFresh") },
        };
        cbFreshrate.DataSource = cbSource;

        cbFreshrate.DisplayMember = "Text";
        cbFreshrate.ValueMember = "ID";

        switch (config.statisticsFreshRate)
        {
            case (int)Global.StatisticsFreshRate.quick:
                cbFreshrate.SelectedItem = cbSource[0];
                break;
            case (int)Global.StatisticsFreshRate.medium:
                cbFreshrate.SelectedItem = cbSource[1];
                break;
            case (int)Global.StatisticsFreshRate.slow:
                cbFreshrate.SelectedItem = cbSource[2];
                break;
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (SaveBase() != 0)
        {
            return;
        }

        if (SaveRouting() != 0)
        {
            return;
        }

        if (SaveKCP() != 0)
        {
            return;
        }

        if (SaveGUI() != 0)
        {
            return;
        }

        if (v2rayNConfigHandler.SaveConfig(ref config) == 0)
        {
            DialogResult = DialogResult.OK;
        }
        else
        {
            MsgBox.ShowWarning(StringsRes.I18N("OperationFailed"));
        }
    }

    /// <summary>
    /// 保存基础设置
    /// </summary>
    /// <returns></returns>
    private int SaveBase()
    {
        //日志
        bool logEnabled = chklogEnabled.Checked;
        string loglevel = cmbloglevel.Text.TrimEx();

        //Mux
        bool muxEnabled = chkmuxEnabled.Checked;

        //本地监听
        string localPort = txtlocalPort.Text.TrimEx();
        string protocol = cmbprotocol.Text.TrimEx();
        bool udpEnabled = chkudpEnabled.Checked;
        bool sniffingEnabled = chksniffingEnabled.Checked;
        if (Misc.IsNullOrEmpty(localPort) || !Misc.IsNumberic(localPort))
        {
            MsgBox.Show(StringsRes.I18N("FillLocalListeningPort"));
            return -1;
        }
        if (Misc.IsNullOrEmpty(protocol))
        {
            MsgBox.Show(StringsRes.I18N("PleaseSelectProtocol"));
            return -1;
        }
        config.inbound[0].localPort = Misc.ToInt(localPort);
        config.inbound[0].protocol = protocol;
        config.inbound[0].udpEnabled = udpEnabled;
        config.inbound[0].sniffingEnabled = sniffingEnabled;

        //日志
        config.logEnabled = logEnabled;
        config.loglevel = loglevel;

        //Mux
        config.muxEnabled = muxEnabled;

        //remoteDNS
        config.remoteDNS = txtremoteDNS.Text.TrimEx();

        config.listenerType = (ListenerType)Enum.ToObject(typeof(ListenerType), cmblistenerType.SelectedIndex);

        config.defAllowInsecure = chkdefAllowInsecure.Checked;

        return 0;
    }

    /// <summary>
    /// 保存路由设置
    /// </summary>
    /// <returns></returns>
    private int SaveRouting()
    {
        //路由
        string domainStrategy = cmbdomainStrategy.Text;
        string routingMode = cmbroutingMode.SelectedIndex.ToString();

        string useragent = txtUseragent.Text.TrimEx();
        string userdirect = txtUserdirect.Text.TrimEx();
        string userblock = txtUserblock.Text.TrimEx();

        config.domainStrategy = domainStrategy;

        config.useragent = Misc.String2List(useragent);
        config.userdirect = Misc.String2List(userdirect);
        config.userblock = Misc.String2List(userblock);

        return 0;
    }

    /// <summary>
    /// 保存KCP设置
    /// </summary>
    /// <returns></returns>
    private int SaveKCP()
    {
        string mtu = txtKcpmtu.Text.TrimEx();
        string tti = txtKcptti.Text.TrimEx();
        string uplinkCapacity = txtKcpuplinkCapacity.Text.TrimEx();
        string downlinkCapacity = txtKcpdownlinkCapacity.Text.TrimEx();
        string readBufferSize = txtKcpreadBufferSize.Text.TrimEx();
        string writeBufferSize = txtKcpwriteBufferSize.Text.TrimEx();
        bool congestion = chkKcpcongestion.Checked;

        if (
            Misc.IsNullOrEmpty(mtu)
            || !Misc.IsNumberic(mtu)
            || Misc.IsNullOrEmpty(tti)
            || !Misc.IsNumberic(tti)
            || Misc.IsNullOrEmpty(uplinkCapacity)
            || !Misc.IsNumberic(uplinkCapacity)
            || Misc.IsNullOrEmpty(downlinkCapacity)
            || !Misc.IsNumberic(downlinkCapacity)
            || Misc.IsNullOrEmpty(readBufferSize)
            || !Misc.IsNumberic(readBufferSize)
            || Misc.IsNullOrEmpty(writeBufferSize)
            || !Misc.IsNumberic(writeBufferSize)
        )
        {
            MsgBox.Show(StringsRes.I18N("FillKcpParameters"));
            return -1;
        }
        config.kcpItem.mtu = Misc.ToInt(mtu);
        config.kcpItem.tti = Misc.ToInt(tti);
        config.kcpItem.uplinkCapacity = Misc.ToInt(uplinkCapacity);
        config.kcpItem.downlinkCapacity = Misc.ToInt(downlinkCapacity);
        config.kcpItem.readBufferSize = Misc.ToInt(readBufferSize);
        config.kcpItem.writeBufferSize = Misc.ToInt(writeBufferSize);
        config.kcpItem.congestion = congestion;

        return 0;
    }

    /// <summary>
    /// 保存GUI设置
    /// </summary>
    /// <returns></returns>
    private int SaveGUI()
    {
        //开机自动启动
        Misc.SetAutoRun(chkAutoRun.Checked);

        config.allowLANConn = chkAllowLANConn.Checked;

        bool lastEnableStatistics = config.enableStatistics;
        config.enableStatistics = chkEnableStatistics.Checked;
        config.statisticsFreshRate = (int)cbFreshrate.SelectedValue;
        config.keepOlderDedupl = chkKeepOlderDedupl.Checked;

        return 0;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void linkLabelRoutingDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start("explorer.exe", "https://www.v2fly.org/config/routing.html");
    }

    private void cmbroutingMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 预设路由规则
        var index = cmbroutingMode.SelectedIndex;
        if (index == 0)
        {
            return;
        }
        if (index == 1)
        {
            // 全局
            txtUseragent.Clear();
            txtUserdirect.Clear();
            txtUserblock.Clear();
            return;
        }
        var address = Global.presetRoutingRules[index - 2];
        switch (tabControl_Routing.SelectedIndex)
        {
            case 0:
                // 代理
                txtUseragent.Text = Misc.List2String(
                    Misc.String2List(txtUseragent.Text).Concat(new List<string>(address)).ToList(),
                    true
                );
                break;
            case 1:
                // 直连
                txtUserdirect.Text = Misc.List2String(
                    Misc.String2List(txtUserdirect.Text).Concat(new List<string>(address)).ToList(),
                    true
                );
                break;
            case 2:
                // 禁止
                txtUserblock.Text = Misc.List2String(
                    Misc.String2List(txtUserblock.Text).Concat(new List<string>(address)).ToList(),
                    true
                );
                break;
            default:
                break;
        }
    }
}
