using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMPS.Services.Navigation;

namespace DEMPS.Pages.ViewModels
{
    public class MainNavigationPageViewModel:ViewModelBase
    {
        public MainNavigationPageViewModel() 
        {

        }
        [Reactive]
        public ViewModelBase Page { get; set; }
        [Reactive]
        public ViewModelBase? Message { get; set; }
    }
}
