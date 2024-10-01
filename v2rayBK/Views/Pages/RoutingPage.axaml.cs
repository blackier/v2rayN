using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using v2rayBK.ViewModels;
using v2rayBK.ViewModels.Pages;

namespace v2rayBK.Views.Pages;

public partial class RoutingPage : UserControl
{
    public RoutingPageViewModel ViewModel { get; }

    public RoutingPage()
    {
        ViewModel = App.GetRequiredService<RoutingPageViewModel>();
        DataContext = this;
        InitializeComponent();
    }

    private void delete_rule_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ViewModel.v2RayBKConfig.RoutingDeleteRule((sender as Button).DataContext as RoutingRuleItem);
    }
}
