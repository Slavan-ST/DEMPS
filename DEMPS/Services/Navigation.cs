using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using DEMPS.ViewModels;
using ReactiveUI;

namespace DEMPS.Services
{
    public static class Navigation
    {
        public static Dictionary<string, ReactiveObject> Pages { get; set; } = new Dictionary<string, ReactiveObject>();
        public static MainNavigationPageViewModel? NavigationView { get; set; }
        public static void Go(string page)
        {
            var pageView = Pages[page];
            if (pageView == null)
            {
                NavigationView!.Page = (Pages.First().Value as ViewModelBase)!;
            }
            else
            {
                NavigationView!.Page = (ViewModelBase)pageView;
            }
        }
    }
}
