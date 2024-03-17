using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace v2rayN.Utils;

public class QRCode
{
    public static Image GetQRCode(string strContent)
    {
        Image img = null;
        try
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                CharacterSet = "UTF-8",
                DisableECI = true, // Extended Channel Interpretation (ECI) 主要用于特殊的字符集。并不是所有的扫描器都支持这种编码。
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M, // 纠错级别
                Width = 500,
                Height = 500,
                Margin = 1
            };
            // options.Hints，更多属性，也可以在这里添加。

            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            Bitmap bmp = writer.Write(strContent);
            img = (Image)bmp;
            return img;
        }
        catch
        {
            return img;
        }
    }

    public static string ScanQRCodeFromScreen()
    {
        try
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                using (Bitmap fullImage = new Bitmap(screen.Bounds.Width,
                                                screen.Bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(fullImage))
                    {
                        g.CopyFromScreen(screen.Bounds.X,
                                         screen.Bounds.Y,
                                         0, 0,
                                         fullImage.Size,
                                         CopyPixelOperation.SourceCopy);
                    }
                    int maxTry = 10;
                    for (int i = 0; i < maxTry; i++)
                    {
                        int marginLeft = (int)((double)fullImage.Width * i / 2.5 / maxTry);
                        int marginTop = (int)((double)fullImage.Height * i / 2.5 / maxTry);
                        Rectangle cropRect = new Rectangle(marginLeft, marginTop, fullImage.Width - marginLeft * 2, fullImage.Height - marginTop * 2);
                        Bitmap target = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

                        double imageScale = (double)screen.Bounds.Width / (double)cropRect.Width;
                        using (Graphics g = Graphics.FromImage(target))
                        {
                            g.DrawImage(fullImage, new Rectangle(0, 0, target.Width, target.Height),
                                            cropRect,
                                            GraphicsUnit.Pixel);
                        }

                        BitmapLuminanceSource source = new BitmapLuminanceSource(target);
                        BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                        QRCodeReader reader = new QRCodeReader();
                        Result result = reader.decode(bitmap);
                        if (result != null)
                        {
                            string ret = result.Text;
                            return ret;
                        }
                    }
                }
            }
        }
        catch { }
        return string.Empty;
    }
}
