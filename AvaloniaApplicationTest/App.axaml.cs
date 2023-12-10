using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AvaloniaApplicationTest.ViewModels;
using AvaloniaApplicationTest.Views;

namespace AvaloniaApplicationTest;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        DEMPS.AppConfig.StartApp(ApplicationLifetime, new CaptchaTest());
        base.OnFrameworkInitializationCompleted();
    }
}
