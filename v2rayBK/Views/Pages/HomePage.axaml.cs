using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.VisualTree;
using FluentAvalonia.UI.Controls;
using v2rayBK.ViewModels;
using v2rayBK.ViewModels.Pages;

namespace v2rayBK.Views.Pages;

public partial class HomePage : UserControl, IRecipient<MessageType.LogMessage>
{
    public HomePageViewModel ViewModel { get; }

    public HomePage()
    {
        ViewModel = App.GetRequiredService<HomePageViewModel>();
        DataContext = this;
        InitializeComponent();

        WeakReferenceMessenger.Default.Register<MessageType.LogMessage>(this);
    }

    private async void subscribe_settings_menuitem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new ContentDialog() { Title = "Subscribe Settings", PrimaryButtonText = "OK" };

        // In our case the Content is a UserControl, but can be anything.
        dialog.Content = new SubscribeSettingsPage()
        {
            DataContext = new SubscribeSettingsPageViewModel() { ServerGroup = ViewModel.v2RayBKConfig.ServerGroup }
        };
        await dialog.ShowAsync();
    }

    private void server_list_datagrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        log_textbox.Text = "";
        ViewModel.StartSeletedServer();
    }

    private async void check_update_xray_menuitem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string lastVersionUrl = await ViewModel.CheckUpdateXRayVersion();
        if (!string.IsNullOrEmpty(lastVersionUrl))
        {
            var dialog = new ContentDialog()
            {
                Title = "XRay-core Update",
                SecondaryButtonText = "Cancel",
                PrimaryButtonText = "OK"
            };

            // In our case the Content is a UserControl, but can be anything.
            dialog.Content = $"Download from {lastVersionUrl}";

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                ViewModel.UpdateXRay(lastVersionUrl);
            }
        }
    }

    private void system_proxy_NativeMenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.Get()?.tray_system_proxy_NativeMenuItem_Click(sender, e);
    }

    private void openurl_MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        switch ((OpenUrlType)((MenuItem)sender!).Tag!)
        {
            case OpenUrlType.XRayProject:
                Process.Start("explorer.exe", GlobalEx.XRayProjectUrl);
                break;
            case OpenUrlType.v2rayBK:
                Process.Start("explorer.exe", GlobalEx.v2rayBKUrl);
                break;
            case OpenUrlType.Promotion:
                Process.Start("explorer.exe", Utils.Base64Decode(GlobalEx.PromotionUrl));
                break;
        }
    }

    private ScrollViewer? _log_textbox_ScrollViewer;

    void IRecipient<MessageType.LogMessage>.Receive(MessageType.LogMessage message)
    {
        log_textbox.Text += Environment.NewLine + message.log;
        if (_log_textbox_ScrollViewer == null)
            _log_textbox_ScrollViewer = log_textbox.GetVisualDescendants().OfType<ScrollViewer>().FirstOrDefault();

        _log_textbox_ScrollViewer?.ScrollToEnd();
    }
}
