using System;
using System.Drawing;
using System.Windows.Forms;
using v2rayN.Config;

namespace v2rayN.Handlers;

class MainFormHandler
{
    private static MainFormHandler instance;

    //private DownloadHandle downloadHandle2;
    //private Config _config;
    //private V2rayHandler _v2rayHandler;
    //private List<int> _selecteds;
    //private Thread _workThread;
    //Action<int, string> _updateFunc;
    public static MainFormHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MainFormHandler();
            }
            return instance;
        }
    }

    public Icon GetNotifyIcon(Config.V2RayNConfig config, Icon def)
    {
        try
        {
            Color color = ColorTranslator.FromHtml("#3399CC");
            int index = (int)config.listenerType;
            if (index > 0)
            {
                color = (
                    new Color[]
                    {
                        Color.Red,
                        Color.Purple,
                        Color.DarkGreen,
                        Color.Orange,
                        Color.DarkSlateBlue,
                        Color.RoyalBlue
                    }
                )[index - 1];
                //color = ColorTranslator.FromHtml(new string[] { "#CC0066", "#CC6600", "#99CC99", "#666699" }[index - 1]);
            }

            int width = 128;
            int height = 128;

            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush drawBrush = new SolidBrush(color);

            graphics.FillEllipse(drawBrush, new Rectangle(0, 0, width, height));
            int zoom = 16;
            graphics.DrawImage(new Bitmap(Resources.Resources.notify, width - zoom, width - zoom), zoom / 2, zoom / 2);

            Icon createdIcon = Icon.FromHandle(bitmap.GetHicon());

            drawBrush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();

            return createdIcon;
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            return def;
        }
    }
}
