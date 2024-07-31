using System;
using System.Windows.Forms;
using v2rayN.Config;

namespace v2rayN.Forms;

public partial class BaseServerForm : BaseForm
{
    public int EditIndex { get; set; }
    protected ProfileItem vmessItem = null;

    public BaseServerForm()
    {
        InitializeComponent();
    }
}
