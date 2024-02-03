using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using DEMPS.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS
{
    public class AppConfig
    {
        public static void StartApp(IApplicationLifetime? ApplicationLifetime)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var window = new Views.MainWindow();
                desktop.MainWindow = window;
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new Views.MainNavigationPageView();
            }

        }
    }
}
