using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v2rayN
{
    partial class Utils
    {
        public static void SaveLog(string strContent)
        {
            SaveLog("info", new Exception(strContent));
        }
        public static void SaveLog(string strTitle, Exception ex)
        {
            try
            {
                string path = Path.Combine(StartupPath(), "guiLogs");
                string FilePath = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(FilePath))
                {
                    FileStream FsCreate = new FileStream(FilePath, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream FsWrite = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                StreamWriter SwWrite = new StreamWriter(FsWrite);

                string strContent = ex.ToString();

                SwWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "--------------------------------", strTitle, DateTime.Now.ToString("HH:mm:ss"), "--------------------------------"));
                SwWrite.Write(strContent);
                SwWrite.WriteLine(Environment.NewLine);
                SwWrite.WriteLine(" ");
                SwWrite.Flush();
                SwWrite.Close();
            }
            catch { }
        }
    }
}
