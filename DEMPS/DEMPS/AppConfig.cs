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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicationLifetime"></param>
        /// <param name="firstView">Первая страница в приложении, дальнейшее обращение к данной странице возможно: Navigation.Pages["first"]
        /// все страницы необходимо добавлять в Navigation.Pages</param>
        public static void StartApp(IApplicationLifetime? ApplicationLifetime, ContentControl firstView)
        {
            Navigation.Add("first", firstView);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var window = new Views.MainWindow();
                desktop.MainWindow = window;
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new Views.MainNavigationPageView();
            }

            Navigation.Go("first");
        }
    }
}
