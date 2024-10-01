using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DynamicData;

namespace v2rayBK.ViewModels;

public partial class RoutingRuleItem : ViewModelBase
{
    [ObservableProperty]
    private bool _enable = false;

    [ObservableProperty]
    private ObservableCollection<string> _domain = new();

    [JsonIgnore]
    public string DomainEdit
    {
        get { return string.Join(",\n", Domain); }
        set
        {
            Domain.Clear();
            Domain.AddRange(value.Split(',').Select(t => t.TrimEx()));
        }
    }
}
