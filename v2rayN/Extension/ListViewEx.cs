using System.Drawing;
using System.Windows.Forms;

namespace v2rayN.Extension
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
