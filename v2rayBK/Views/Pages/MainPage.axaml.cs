using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Navigation;
using v2rayBK.ViewModels;

namespace v2rayBK.Views.Pages;

public partial class MainPage : UserControl
{
    class NavigationFactory : INavigationPageFactory
    {
        public Control GetPage(Type srcType)
        {
            if (srcType == typeof(HomePage))
                return App.GetRequiredService<HomePage>();
            if (srcType == typeof(SettingsPage))
                return App.GetRequiredService<SettingsPage>();
            return new TextBlock() { Text = $"Invalid Page Type {srcType}" };
        }

        public Control GetPageFromObject(object target)
        {
            throw new NotImplementedException();
        }
    }

    public MainPage()
    {
        InitializeComponent();

        // NOTE: Make sure the routing strategy is Direct
        AddHandler(Frame.NavigatingFromEvent, OnNavigatingFrom, RoutingStrategies.Direct);
        AddHandler(Frame.NavigatedFromEvent, OnNavigatedFrom, RoutingStrategies.Direct);
        AddHandler(Frame.NavigatedToEvent, OnNavigatedTo, RoutingStrategies.Direct);

        root_frame.NavigationPageFactory = new NavigationFactory();
        root_navigationview.SelectedItem = home_navitem;
    }

    private void OnNavigatingFrom(object sender, NavigatingCancelEventArgs args) { }

    private void OnNavigatedFrom(object sender, NavigationEventArgs args) { }

    private void OnNavigatedTo(object sender, NavigationEventArgs args) { }

    private void root_navigationview_SelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem == home_navitem)
            root_frame.Navigate(typeof(HomePage));
        else if (args.SelectedItem == settings_navitem)
            root_frame.Navigate(typeof(SettingsPage));
    }

    private void root_frame_Navigated(object? sender, NavigationEventArgs e) { }

    private void root_frame_Navigating(object? sender, NavigatingCancelEventArgs e) { }

    private void toggle_theme_CommandBarButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var theme = App.Get()!.ActualThemeVariant;
        if (theme == ThemeVariant.Dark)
        {
            theme = ThemeVariant.Light;
            App.Get()!.v2rayBKConfig.AppTheme = AppTheme.Light;
        }
        else if (theme == ThemeVariant.Light)
        {
            theme = ThemeVariant.Dark;
            App.Get()!.v2rayBKConfig.AppTheme = AppTheme.Dark;
        }
        App.Get()!.RequestedThemeVariant = theme;
    }
}
