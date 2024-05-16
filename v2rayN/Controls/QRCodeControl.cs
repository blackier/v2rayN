using System.Windows.Forms;
using v2rayN.Config;
using v2rayN.Handlers;
using v2rayN.Utils;

namespace v2rayN.Forms
{
    public partial class QRCodeControl : UserControl
    {
        public QRCodeControl()
        {
            InitializeComponent();
        }

        private void QRCodeControl_Load(object sender, System.EventArgs e)
        {
            txtUrl.MouseUp += txtUrl_MouseUp;
        }

        void txtUrl_MouseUp(object sender, MouseEventArgs e)
        {
            txtUrl.SelectAll();
        }

        public void showQRCode(int Index, Config.V2RayNConfig config)
        {
            if (Index >= 0)
            {
                string url = v2rayNConfigHandler.GetVmessQRCode(config, Index);
                if (Misc.IsNullOrEmpty(url))
                {
                    picQRCode.Image = null;
                    txtUrl.Text = string.Empty;
                    return;
                }
                txtUrl.Text = url;
                picQRCode.Image = QRCode.GetQRCode(url);
            }
        }
    }
}
