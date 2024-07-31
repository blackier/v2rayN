using System;
using System.Windows.Forms;
using v2rayN.Config;
using v2rayN.Handlers;
using v2rayN.Utils;

namespace v2rayN.Forms;

public partial class ConfigShadowsocksForm : BaseServerForm
{
    public ConfigShadowsocksForm()
    {
        InitializeComponent();
    }

    private void AddServer3Form_Load(object sender, EventArgs e)
    {
        if (EditIndex >= 0)
        {
            vmessItem = config.vmess[EditIndex];
            BindingServer();
        }
        else
        {
            vmessItem = new ProfileItem();
            ClearServer();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void BindingServer()
    {
        txtAddress.Text = vmessItem.address;
        txtPort.Text = vmessItem.port.ToString();
        txtId.Text = vmessItem.id;
        cmbSecurity.Text = vmessItem.security;
        txtRemarks.Text = vmessItem.remarks;
    }

    /// <summary>
    /// 清除设置
    /// </summary>
    private void ClearServer()
    {
        txtAddress.Text = "";
        txtPort.Text = "";
        txtId.Text = "";
        cmbSecurity.Text = Global.DefaultSecurity;
        txtRemarks.Text = "";
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        string address = txtAddress.Text;
        string port = txtPort.Text;
        string id = txtId.Text;
        string security = cmbSecurity.Text;
        string remarks = txtRemarks.Text;

        if (Misc.IsNullOrEmpty(address))
        {
            MsgBox.Show(StringsRes.I18N("FillServerAddress"));
            return;
        }
        if (Misc.IsNullOrEmpty(port) || !Misc.IsNumberic(port))
        {
            MsgBox.Show(StringsRes.I18N("FillCorrectServerPort"));
            return;
        }
        if (Misc.IsNullOrEmpty(id))
        {
            MsgBox.Show(StringsRes.I18N("FillPassword"));
            return;
        }
        if (Misc.IsNullOrEmpty(security))
        {
            MsgBox.Show(StringsRes.I18N("PleaseSelectEncryption"));
            return;
        }

        vmessItem.address = address;
        vmessItem.port = Misc.ToInt(port);
        vmessItem.id = id;
        vmessItem.security = security;
        vmessItem.remarks = remarks;

        if (v2rayNConfigHandler.AddShadowsocksServer(ref config, vmessItem, EditIndex) == 0)
        {
            this.DialogResult = DialogResult.OK;
        }
        else
        {
            MsgBox.ShowWarning(StringsRes.I18N("OperationFailed"));
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
    }
}
