using Avalonia.Controls;
using AvaloniaApplicationTest.ViewModels;

namespace AvaloniaApplicationTest.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
