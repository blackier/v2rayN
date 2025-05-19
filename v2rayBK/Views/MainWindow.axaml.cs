using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using FluentAvalonia.UI.Navigation;
using FluentAvalonia.UI.Windowing;
using v2rayBK.ViewModels;
using v2rayBK.Views.Pages;

namespace v2rayBK.Views;

public partial class MainWindow : AppWindow
{
    public MainWindowViewModel ViewModel { get; }

    public MainWindow()
    {
        ViewModel = App.GetRequiredService<MainWindowViewModel>();
        DataContext = this;
        InitializeComponent();

        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        ShowInTaskbar = false;

        TitleBar.Height = app_titlebar_grid.Height;
        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;

        main_root_frame.Navigate(typeof(MainPage));
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        base.OnClosing(e);
    }

    public override void Show() { }

    public void ShowWindow()
    {
        WindowState = WindowState.Normal;
        ShowInTaskbar = true;
        base.Show();
        Activate();
    }

    public void ShowLoading()
    {
        loading_contentcontrol.IsVisible = true;
    }

    public void HideLoading()
    {
        loading_contentcontrol.IsVisible = false;
    }

    private void main_root_frame_Navigated(object sender, NavigationEventArgs e) { }

    private void main_root_frame_Navigating(object sender, NavigatingCancelEventArgs e) { }
}
