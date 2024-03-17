using System.Drawing;
using System.Windows.Forms;

namespace v2rayN.Controls;

class ListViewControl : ListView
{
    public ListViewControl()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
    }
}
