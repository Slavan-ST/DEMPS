using Avalonia;
using Avalonia.Controls;
using DEMPS.Services.Navigation;

namespace DEMPS.Pages.Views
{
    public partial class MainNavigationPageView : UserControl
    {
        public MainNavigationPageView()
        {
            InitializeComponent();
            DataContext  = Navigation.NavigationView =  new ViewModels.MainNavigationPageViewModel();
        }
    }
}
