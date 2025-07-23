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


    void IRecipient<MessageType.LogMessage>.Receive(MessageType.LogMessage message)
    {
        if (log_ItemsControl.Items.Count > 999)
            log_ItemsControl.Items.Clear();

        log_ItemsControl.Items.Add(new SelectableTextBlock() {Text = message.log, TextWrapping = Avalonia.Media.TextWrapping.Wrap });
        log_ScrollViewer.ScrollToEnd();
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

    private async void check_update_xray_MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
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

    private void system_proxy_MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
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

    private void server_list_DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        log_ItemsControl.Items.Clear();
        ViewModel.StartSeletedServer();
    }


    private async void DataGrid_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        var dataGrid = (DataGrid)sender;
        if (!this.IsLoaded)
            await Task.Delay(100);
        dataGrid.ScrollIntoView(dataGrid.SelectedItem, null);
    }
}
