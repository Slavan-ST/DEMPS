using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AvaloniaApplicationTest.ViewModels;
using AvaloniaApplicationTest.Views;
using DEMPS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AvaloniaApplicationTest;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        DEMPS.AppConfig.StartApp(ApplicationLifetime);

        Navigation.Go(new UserControl1());

        base.OnFrameworkInitializationCompleted();
    }
}
