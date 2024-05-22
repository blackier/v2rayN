using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace v2rayN.Controls;

class ListViewControl : ListView
{
    public int SortColumnIndex { get; set; } = -1;
    public SortOrder SortColumnOrder { get; set; } = SortOrder.None;

    public ListViewControl()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
        OwnerDraw = true;
        DrawColumnHeader += ListViewControl_DrawColumnHeader;
        DrawItem += ListViewControl_DrawItem;
        DrawSubItem += ListViewControl_DrawSubItem;
    }

    private void ListViewControl_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        // https://stackoverflow.com/questions/32424074/listview-align-vertical-grid-lines-with-headers-dividers-make-last-column-fi
        var state =
            e.State == ListViewItemStates.Selected
                ? VisualStyleElement.Header.Item.Hot
                : VisualStyleElement.Header.Item.Normal;
        var itemRenderer = new VisualStyleRenderer(state);
        var renderBounds = e.Bounds;
        renderBounds.X += 1;
        itemRenderer.DrawBackground(e.Graphics, renderBounds);
        //itemRenderer.DrawEdge(e.Graphics, renderBounds, Edges.Bottom, EdgeStyle.Etched, EdgeEffects.Soft);

        HorizontalAlignment hAlign = e.Header?.TextAlign ?? HorizontalAlignment.Left;
        TextFormatFlags flags =
            (hAlign == HorizontalAlignment.Left)
                ? TextFormatFlags.Left
                : ((hAlign == HorizontalAlignment.Center) ? TextFormatFlags.HorizontalCenter : TextFormatFlags.Right);
        flags |= TextFormatFlags.WordEllipsis | TextFormatFlags.VerticalCenter;
        renderBounds.Inflate(-4, 0);
        TextRenderer.DrawText(e.Graphics, e.Header?.Text, e.Font, renderBounds, e.ForeColor, flags);

        //Sorted Column
        if (SortColumnOrder == SortOrder.None)
            return;
        var sortOrder =
            SortColumnOrder == SortOrder.Ascending
                ? VisualStyleElement.Header.SortArrow.SortedUp
                : VisualStyleElement.Header.SortArrow.SortedDown;
        var sortRenderer = new VisualStyleRenderer(sortOrder);
        var d = SystemInformation.VerticalScrollBarWidth;
        if (e.ColumnIndex == SortColumnIndex)
            sortRenderer.DrawBackground(
                e.Graphics,
                new Rectangle(e.Bounds.Right - d, e.Bounds.Top, d, e.Bounds.Height)
            );
    }

    private void ListViewControl_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
    }

    private void ListViewControl_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;
    }
}
