using System;
using System.Windows.Forms;
using v2rayN.Handlers;
using v2rayN.Config;

namespace v2rayN.Forms
{
    public partial class ConfigTrojanForm : BaseServerForm
    {
        public ConfigTrojanForm()
        {
            InitializeComponent();
        }

        private void AddServer6Form_Load(object sender, EventArgs e)
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
            txtRequestHost.Text = vmessItem.requestHost;
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
            txtRequestHost.Text = "";
            txtRemarks.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text;
            string port = txtPort.Text;
            string id = txtId.Text;
            string requestHost = txtRequestHost.Text;
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

            vmessItem.address = address;
            vmessItem.port = Misc.ToInt(port);
            vmessItem.id = id;
            vmessItem.requestHost = requestHost.Replace(" ", "");
            vmessItem.remarks = remarks;

            if (v2rayNConfigHandler.AddTrojanServer(ref config, vmessItem, EditIndex) == 0)
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
}
