using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationTest.ViewModels
{
    public class FirstViewModel : ReactiveObject, IRoutableViewModel
    {
        public FirstViewModel(IScreen screen) => HostScreen = screen;

        public string? UrlPathSegment { get; } = "FirstView";

        public IScreen HostScreen { get; set; }
    }
}
