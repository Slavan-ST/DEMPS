using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMPS.Services;
using Avalonia.Controls;
using System.Diagnostics;

namespace DEMPS.ViewModels
{
    public class MainNavigationPageViewModel : ReactiveObject
    {
        public MainNavigationPageViewModel()
        {

        }
        [Reactive]
        public ContentControl? Page{ get; set; }
        [Reactive]
        public ContentControl? Message { get; set; }
    }
}
