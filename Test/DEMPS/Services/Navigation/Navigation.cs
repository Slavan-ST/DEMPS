using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DEMPS.Pages.ViewModels;
using Test.ViewModels;

namespace Test.DEMPS.Services.Navigation
{
    public static class Navigation
    {
        public static Dictionary<string, object> Pages = new Dictionary<string, object>();
        public static MainNavigationPageViewModel? NavigationView { get; set; }
        public static void Go(string page)
        {
            var pageView = Pages.Where(p => p.Key == page).First().Value;
            if (pageView == null)
            {
                NavigationView!.Page = (Pages.First().Value as ViewModelBase)!;
            }
            else
            {
                NavigationView!.Page = (pageView as ViewModelBase)!;
            }
        }
    }
}
