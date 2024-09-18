using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using v2rayBK.ViewModels;
using v2rayBK.ViewModels.Pages;

namespace v2rayBK.Views.Pages;

public partial class SubscribeSettingsPage : UserControl
{
    public SubscribeSettingsPage()
    {
        InitializeComponent();
    }

    private void delete_subscribe_button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is SubscribeSettingsPageViewModel viewModel)
        {
            viewModel.DeleteSubscribe(((Button)sender).DataContext as ServerGroupInfo);
        }
    }
}
