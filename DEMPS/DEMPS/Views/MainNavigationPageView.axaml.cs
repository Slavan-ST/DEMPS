using Avalonia;
using Avalonia.Controls;
using DEMPS.Services;
using DEMPS.ViewModels;

namespace DEMPS.Views
{
    public partial class MainNavigationPageView : UserControl
    {
        public MainNavigationPageView()
        {
            InitializeComponent();


            var vm = new MainNavigationPageViewModel();
            DataContext = vm;
            Navigation.ConfigNavigation(vm);
        }
    }
}
