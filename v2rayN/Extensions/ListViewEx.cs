using System.Drawing;
using System.Windows.Forms;

namespace v2rayN.Extensions
{
    class ListViewEx : ListView
    {
        public ListViewEx()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

    }
}
