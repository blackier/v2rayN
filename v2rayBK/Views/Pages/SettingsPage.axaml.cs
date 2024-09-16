using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using v2rayBK.Common;
using v2rayBK.ViewModels.Pages;

namespace v2rayBK.Views.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPageViewModel ViewModel { get; }
    public SettingsPage()
    {
        ViewModel = App.GetRequiredService<SettingsPageViewModel>();
        DataContext = this;
        InitializeComponent();
    }

    private void autostart_ToggleSwitch_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Misc.SetAutoRun(autostart_ToggleSwitch.IsChecked ?? false);
    }
}
