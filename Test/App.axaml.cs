using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Test.ViewModels;
using Test.Views;

namespace Test;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); // сюда что-нибудь придумать
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var dataContext = new MainViewModel();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = dataContext
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = dataContext
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
