using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Test.DEMPS.Pages.Views;
using Test.DEMPS.Services.Navigation;
using Test.ViewModels;
using Test.Views;

namespace Test;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); // сюда что-нибудь придумать
    }

    public override void OnFrameworkInitializationCompleted()//и сюда
    {
        Navigation.Pages.Add("main", new MainViewModel());

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
        base.OnFrameworkInitializationCompleted();
    }
}
