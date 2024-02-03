using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using DEMPS.ViewModels;
using DEMPS.Views;
using ReactiveUI;

namespace DEMPS.Services
{
    public static class Navigation
    {
        private static MainNavigationPageViewModel _currentView = new MainNavigationPageViewModel();

        public static void ConfigNavigation(MainNavigationPageViewModel viewForNavigation)
        {
            _currentView = viewForNavigation;
        }
        public static void Go(ContentControl page)
        {
            _currentView!.Page = page;
        }

    }
}
