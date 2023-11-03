using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.ViewModels
{
    public class NavigationViewModel:ViewModelBase
    {
        public NavigationViewModel() 
        {

        }
        [Reactive]
        public ViewModelBase Page { get; set; }
        [Reactive]
        public ViewModelBase? Message { get; set; }
    }
}
