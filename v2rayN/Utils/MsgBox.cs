using System.Windows.Forms;

namespace v2rayN.Utils;

public class MsgBox
{
    public static void Show(string msg)
    {
        MessageBox.Show(msg, "v2rayN", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static void ShowWarning(string msg)
    {
        MessageBox.Show(msg, "v2rayN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static void ShowError(string msg)
    {
        MessageBox.Show(msg, "v2rayN", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static DialogResult ShowYesNo(string msg)
    {
        return MessageBox.Show(msg, "v2rayN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}

