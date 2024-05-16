using System;
using System.Windows.Forms;
using v2rayN.Config;

namespace v2rayN.Forms
{
    public partial class BaseForm : Form
    {
        protected static Config.V2RayNConfig config;
        protected static System.Drawing.Icon icon;

        public BaseForm()
        {
            InitializeComponent();
            LoadCustomIcon();
        }

        private void LoadCustomIcon()
        {
            try
            {
                if (icon == null)
                {
                    string file = Misc.GetPath(Global.CustomIconName);
                    if (!System.IO.File.Exists(file))
                    {
                        return;
                    }
                    icon = new System.Drawing.Icon(file);
                }
                this.Icon = icon;
            }
            catch (Exception e)
            {
                Log.SaveLog($"Loading custom icon failed: {e.Message}");
            }
        }
    }
}
