using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DEMPS.Services.Navigation;
using Test.ViewModels;

namespace Test.DEMPS.Pages.ViewModels
{
    public class MainNavigationPageViewModel:ViewModelBase
    {
        public MainNavigationPageViewModel() 
        {
            Page = new Test.ViewModels.MainViewModel();
        }
        [Reactive]
        public ViewModelBase Page { get; set; }
        [Reactive]
        public ViewModelBase? Message { get; set; }
    }
}
