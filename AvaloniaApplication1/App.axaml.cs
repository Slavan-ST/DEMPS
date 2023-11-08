using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using DEMPS.Services.Message;
using DEMPS.Services.Navigation;
using ReactiveUI;

namespace AvaloniaApplication1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Test.OnFrameworkInitializationCompleted(ApplicationLifetime, new MainViewModel());
        Message.Show(text: "Hello");
    }
}
public class Test
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ApplicationLifetime">Собственно само приложение</param>
    /// <param name="firstView">первая страница </param>
    public static void OnFrameworkInitializationCompleted(IApplicationLifetime? ApplicationLifetime, ReactiveObject firstView)
    {
        Navigation.Pages.Add("main", firstView);

        var window = new DEMPS.Pages.Views.MainWindow();


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = window;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new DEMPS.Pages.Views.MainNavigationPageView();
        }

        Navigation.Go("main");
    }
}