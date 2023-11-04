using Avalonia.Controls;
using Test.DEMPS.Services.Navigation;

namespace Test.DEMPS.Pages.Views
{
    public partial class MainNavigationPageView : UserControl
    {
        public MainNavigationPageView()
        {
            InitializeComponent();
            DataContext = Navigation.NavigationView = new DEMPS.Pages.ViewModels.MainNavigationPageViewModel();
        }
    }
}
